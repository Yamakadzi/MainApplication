
using ProductAccounting;
using System.Windows.Controls;
using System.Windows;
using NUnit.Framework;
using static ProductAccounting.RegistrationWindow;
using Assert = NUnit.Framework.Assert;

namespace TestProject1
{
    [TestFixture]
    public class MainWindowTests
    {
        [TestCase("", "", "", "�� ����������� ���� ����������������")] 
        [TestCase(null, null, null,  "�� ����������� ���� �� ����������������")] 
        [TestCase("123456789123456789123456789123456789123456789123456", "1", null,  "51 ������ � ������")] 
        [TestCase("yami", "123456789123456789123456789123456789123456789123456", null,  "51 ������ � ������")]
        [TestCase("yami2", "1", "123456789123456789123456789123456789123456789123456", "51 ������ � �����")] 
        [TestCase("login", "1", "login@gmail.com", "��� ���� ��������� �����(�����������)")] 
       
        public void Authorization_ValidUser_LoginAndRegSuccessful(string? login, string? password, string? email, string message)
        {
            var valid_result = Validation_User(login, password, email);
            Assert.That(valid_result.Item2, Is.True, message);
        }

    }
}