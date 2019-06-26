using System;
using System.Collections.Generic;
using System.Linq;
using BOL;
using BLL;


namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Product> products = ProductManager.GetSoldOutProducts();
           List<Product> products = ProductManager.GetAllProductsFromDatabase();
            // Product p = ProductManager.GetFirstProduct();
           foreach( Product p in products)
             {
             Console.WriteLine("{0}", p.Title);
            }

            Console.ReadLine();
        }
    }
}
