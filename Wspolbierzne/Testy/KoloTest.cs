using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;

using Dane;
using Logika;
using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy
{
    [TestClass()]
    public class KoloTest
    {
        [TestMethod]
        public void KoloTests()
        {
            Kulka o = new Kulka(3, 4,5);
            KulkaLogika kulka = new KulkaLogika(o);
            Kolo kolo = new Kolo(kulka);
            Assert.AreEqual(kulka.X, kolo.X);
            Assert.AreEqual(kulka.Y, kolo.Y);
        }
    }
}