using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroADO_NET
{ //Khai bao lop entity cho Product 
    public class Product{ 
        public int ProductID { get; set; } 
        public string ProductName { get; set; }
        public double UnitPrice { get; set; } 
        public int Quantity { get; set; } 
    } 
} 
