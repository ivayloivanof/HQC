using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Orders
{
    class Orders
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var filePaths = new dataMapper();
            var allCategories = filePaths.getAllCategories();
            var allProducts = filePaths.getAllProducts();
            var allOrders = filePaths.getAllOrders();

            // Names of the 5 most expensive products
            var first = allProducts
                .OrderByDescending(p => p.unit_price)
                .Take(5)
                .Select(p => p.nome);
            Console.WriteLine(string.Join(Environment.NewLine, first));

            Console.WriteLine(new string('-', 10));

            // Number of products in each Category
            var second = allProducts
                .GroupBy(p => p.catId)
                .Select(grp => new { Category = allCategories.First(c => c.Id == grp.Key).NAME, Count = grp.Count() })
                .ToList();
            foreach (var item in second)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by Order quantity)
            var third = allOrders
                .GroupBy(o => o.product_id)
                .Select(grp => new { Product = allProducts.First(p => p.id == grp.Key).nome, Quantities = grp.Sum(grpgrp => grpgrp.quant) })
                .OrderByDescending(q => q.Quantities)
                .Take(5);
            foreach (var item in third)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable Category
            var category = allOrders
                .GroupBy(o => o.product_id)
                .Select(g => new { catId = allProducts.First(p => p.id == g.Key).catId, price = allProducts.First(p => p.id == g.Key).unit_price, quantity = g.Sum(p => p.quant) })
                .GroupBy(gg => gg.catId)
                .Select(grp => new { category_name = allCategories.First(c => c.Id == grp.Key).NAME, total_quantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.total_quantity)
                .First();
            Console.WriteLine("{0}: {1}", category.category_name, category.total_quantity);
        }
    }
}
