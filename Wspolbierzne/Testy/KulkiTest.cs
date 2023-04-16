using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;

namespace Testy
{
    [TestClass]
    public class KulkiTest
    {
        Kulka kulka = new Kulka(5, 10);

        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(5, kulka.X);
            Assert.AreEqual(10, kulka.Y);
        }

        [TestMethod]
        public void SetterTest()
        {
            kulka.X = 10;
            kulka.Y = 15;

            Assert.AreEqual(10, kulka.X);
            Assert.AreEqual(15, kulka.Y);
        }
    }
}