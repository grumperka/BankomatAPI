using BibliotekaKlas;
using NUnit.Framework;

namespace TestProject_Banknot
{
    public class Tests
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
    }
}