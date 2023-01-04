using BibliotekaKlas.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_Banknot
{
    public class BanknotTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void isValue()
        {
            Banknot banknot = new Banknot(10);

            bool isValueT = banknot.isValue(10);

            bool isValueF = banknot.isValue(5);

            bool isValueFF = banknot.isValue(7);

            bool isValueFFF = banknot.isValue(13);

            Assert.IsTrue(isValueT == true && isValueF == false && isValueFF == false && isValueFFF == false);

        }

    }
}
