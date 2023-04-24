using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casestudy.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }

        public int Stock { get; set; }
    }
}