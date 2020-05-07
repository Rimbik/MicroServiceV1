using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemService.Model;
using ItemService.NotificationHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ItemService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllItems")]
        public IEnumerable<Item> Get()
        {
           var itemList = new List<Item>()
           {
             new Item() { Id =0, ItemName = "Mens Jeans", InStock = 100, ItemPrice = 1000.99},
             new Item() { Id =0, ItemName = "Mens T-Shirt", InStock = 100 , ItemPrice = 600.99},
             new Item() { Id =0, ItemName = "Mens Trouser", InStock = 100, ItemPrice = 800.99 },
             new Item() { Id =0, ItemName = "Mens Causal" , InStock = 100, ItemPrice = 1500.99},
             new Item() { Id =0, ItemName = "Mens Cap" , InStock = 100, ItemPrice = 500.99},
             new Item() { Id =0, ItemName = "Mens Tracking Shoe", InStock = 100 , ItemPrice = 2000.99}
           };

            return itemList;
        }

        [HttpPost]
        [Route("blockitem")]
        //[ResponseType(typeof(void))]
        public void BlockItem(List<int> itemsIds)
        {

            System.Diagnostics.Debugger.Launch();
            foreach(var itemId in itemsIds)
            {
                //1: Block the item for 10 minutes
                //Code ...

                //2: Notify
                MessageHandler.Publish("Item Blocked: "+itemId);
            }
        }
    }
}
