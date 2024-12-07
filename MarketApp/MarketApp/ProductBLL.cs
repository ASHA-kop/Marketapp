using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
    class ProductBLL
    {
        public Product GetProductData()
        {
            Product x = new Product();
            Console.WriteLine("Enter Product Id: ");
            x.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Name:");
            x.Name = Console.ReadLine();
            Console.WriteLine("Enter Qty: ");
            x.Qty = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            x.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Status:");
            x.Status = int.Parse(Console.ReadLine());
            return x;
        }
    }
}
