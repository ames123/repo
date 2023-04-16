using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;

namespace Testy
{
    [TestClass]
    public class ScenaTest
    {
        Scena scene = new Scena(500, 250, 5);
        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(250, scene.Height);
            Assert.AreEqual(5, scene.Kulka.Count);
            Assert.AreEqual(500, scene.Width);
            Assert.IsFalse(scene.Enabled);
        }

        [TestMethod]
        public void SetterTest()
        {
            scene.Enabled = true;

            Assert.IsTrue(scene.Enabled);
        }
    }
}
