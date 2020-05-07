using System;
using ItemService.NotificationHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPublishCatalog()
        {
            MessageHandler.Publish("Ok working...");
        }
    }
}
