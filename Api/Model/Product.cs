using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product_git.Model.Abstract;

namespace Product_git.Model
{
    public class Product : CommonProp
    {
        public int Stock { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}