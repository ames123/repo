using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logika;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Dane;
namespace Testy
{
    [TestClass()]
    public class ModelApiTest
    {
        [TestMethod()]
        public void GeneralModelApiTest()
        {
            AbstractDataApi dataApi = AbstractDataApi.CreateApi();
            AbstractLogicApi logicApi = AbstractLogicApi.CreateApi(dataApi);
            AbstractModelApi modelApi = AbstractModelApi.CreateApi(logicApi);
            modelApi.Enable(10);
            ObservableCollection<Kolo> collection = modelApi.GetAllKola();
            Assert.IsNotNull(collection);
            Assert.AreEqual(10, collection.Count);
        }
    }
}
