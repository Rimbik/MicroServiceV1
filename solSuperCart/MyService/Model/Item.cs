using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Model
{
    public class Category
    {

    }
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public string Currency { get; set; } = "₹";
        public Uri ItemPic { get; set; }
        public int InStock { get; set; }
    }
}
