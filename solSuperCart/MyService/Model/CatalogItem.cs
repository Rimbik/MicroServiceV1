using ItemService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Model
{
    //This will be Database in real world (using stub data for PUC purpose)
    public static class CatalogItem
    {
        static CatalogItem()
        {
           Items = new List<Item>()
           {
             new Item() { Id =1234, ItemName = "Mens Jeans", InStock = 100, ItemPrice = 1000.99},
             new Item() { Id =2234, ItemName = "Mens T-Shirt", InStock = 100 , ItemPrice = 600.99},
             new Item() { Id =3234, ItemName = "Mens Trouser", InStock = 100, ItemPrice = 800.99 },
             new Item() { Id =4234, ItemName = "Mens Causal" , InStock = 100, ItemPrice = 1500.99},
             new Item() { Id =5234, ItemName = "Mens Cap" , InStock = 100, ItemPrice = 500.99},
             new Item() { Id =6234, ItemName = "Mens Tracking Shoe", InStock = 100 , ItemPrice = 2000.99}
           };

        }
        public static List<ItemService.Model.Item> Items { get; set; }

        
    }
}
