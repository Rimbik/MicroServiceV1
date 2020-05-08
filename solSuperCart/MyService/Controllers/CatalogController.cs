using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogService.Model;
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
            var itemList = CatalogItem.Items;

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

                var item = CatalogItem.Items.FirstOrDefault(i => i.Id == itemId);
                item.InStock -= 1;

                //1: Block the item for 10 minutes
                //Code ...

                //2: Notify
                MessageHandler.Publish(string.Format("{0},ItemBooked", itemId));
            }
        }
    }
}
