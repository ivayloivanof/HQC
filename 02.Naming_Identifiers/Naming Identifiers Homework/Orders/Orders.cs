namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    internal class Orders
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var filePaths = new DataMapper();
            var allCategories = filePaths.GetAllCategories();
            var allProducts = filePaths.GetAllProducts();
            var allOrders = filePaths.GetAllOrders();

            // Names of the 5 most expensive products
            var first = allProducts
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, first));

            Console.WriteLine(new string('-', 10));

            // Number of products in each Category
            var second = allProducts
                .GroupBy(p => p.CatID)
                .Select(grp => new { Category = allCategories.First(c => c.ID == grp.Key).Name, Count = grp.Count() })
                .ToList();
            foreach (var item in second)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by Order quantity)
            var third = allOrders
                .GroupBy(o => o.ProductID)
                .Select(grp => new { Product = allProducts.First(p => p.ID == grp.Key).Name, Quantities = grp.Sum(grpgrp => grpgrp.Quant) })
                .OrderByDescending(q => q.Quantities)
                .Take(5);
            foreach (var item in third)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable Category
            var category = allOrders
                .GroupBy(o => o.ProductID)
                .Select(g => new { catId = allProducts.First(p => p.ID == g.Key).CatID, price = allProducts.First(p => p.ID == g.Key).UnitPrice, quantity = g.Sum(p => p.Quant) })
                .GroupBy(gg => gg.catId)
                .Select(grp => new { category_name = allCategories.First(c => c.ID == grp.Key).Name, total_quantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.total_quantity)
                .First();
            Console.WriteLine("{0}: {1}", category.category_name, category.total_quantity);
        }
    }
}
