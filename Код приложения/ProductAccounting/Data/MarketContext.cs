using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProductAccounting.Models;

namespace ProductAccounting.Data;

public partial class MarketContext : DbContext
{
    public MarketContext()
    {
    }

    public MarketContext(DbContextOptions<MarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ShoppingList> ShoppingLists { get; set; }

    public virtual DbSet<StoredProduct> StoredProducts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-GURUASM;initial catalog =practice;persist security info=True; user id=admin;password=admin;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShoppingList>(entity =>
        {
            entity.HasKey(e => e.IdShopingList);

            entity.ToTable("ShoppingList");

            entity.Property(e => e.IdShopingList).HasColumnName("idShopingList");
            entity.Property(e => e.Count).HasDefaultValueSql("((1))");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingList_Users1");
        });

        modelBuilder.Entity<StoredProduct>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Count).HasDefaultValueSql("((1))");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShelfLife)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.StoredProducts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoredProducts_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.HasIndex(e => e.Email, "Uq_Email").IsUnique();

            entity.HasIndex(e => e.Login, "Uq_Login").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
