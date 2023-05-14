using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Logika;
using System;
using Dane;
namespace Testy
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void GeneralLogicApiTest()
        {
            bool v = false;
            try
            {
                AbstractLogicApi api = AbstractLogicApi.CreateApi();
            }
            catch(NotImplementedException)
            {
                v = true;
            }
            Assert.IsTrue(true);
            AbstractDataApi dataApi = AbstractDataApi.CreateApi();
            AbstractLogicApi logicApi = AbstractLogicApi.CreateApi(dataApi);
            logicApi.Enable(500, 250, 5);
            Assert.AreEqual(5, logicApi.GetKulki().Count);
        }

    }
}