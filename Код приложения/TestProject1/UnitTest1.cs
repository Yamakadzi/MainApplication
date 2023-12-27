
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
        [TestCase("", "", "", "не заполненные поля инициализированы")] 
        [TestCase(null, null, null,  "не заполненные поля не инециализированы")] 
        [TestCase("123456789123456789123456789123456789123456789123456", "1", null,  "51 символ в логине")] 
        [TestCase("yami", "123456789123456789123456789123456789123456789123456", null,  "51 символ в пароле")]
        [TestCase("yami2", "1", "123456789123456789123456789123456789123456789123456", "51 символ в почте")] 
        [TestCase("login", "1", "login@gmail.com", "все поля заполнены верно(регистрация)")] 
       
        public void Authorization_ValidUser_LoginAndRegSuccessful(string? login, string? password, string? email, string message)
        {
            var valid_result = Validation_User(login, password, email);
            Assert.That(valid_result.Item2, Is.True, message);
        }

    }
}