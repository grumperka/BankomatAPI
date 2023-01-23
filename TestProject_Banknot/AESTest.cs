using BibliotekaKlas.Classes;
using NUnit.Framework;
using BCrypt.Net;

namespace TestProject_Banknot
{
    public class AESTest
    {
        private string key;

        [SetUp]
        public void Setup()
        {
            key = "bankomatAplikacjaDotNetApiHash32";
        }

        [Test]
        public void EncriptionDecriptionString()
        {
            string pin = "1234";

            var encryptedString = AesOperation.EncryptString(key, pin.ToString());

            var decryptedString = AesOperation.DecryptString(key, encryptedString);

            Assert.IsTrue(pin.Equals(decryptedString));
        }

        /* https://github.com/neoKushan/BCrypt.Net-Core
        [Test]
        public void bcrypt() {

            string password = "1234";

            var hashedPass = BCrypt.Net.BCrypt.HashPassword(password);
            var hashedPass1 = BCrypt.Net.BCrypt.HashPassword(password);

            int length = hashedPass.Length;
            int length1 = hashedPass1.Length;

            bool validPassword = BCrypt.Net.BCrypt.Verify(password, hashedPass);
            bool validPassword1 = BCrypt.Net.BCrypt.Verify(password, hashedPass1);

            bool validPassword11 = BCrypt.Net.BCrypt.Verify("4321", hashedPass1);
            bool validPassword12 = BCrypt.Net.BCrypt.Verify("1243", hashedPass1);

        }*/
    }
}