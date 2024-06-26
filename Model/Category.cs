using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product_git.Model.Abstract;

namespace Product_git.Model
{
    public class Category : CommonProp
    {
        List<Product>? Products { get; set; }
    }
}