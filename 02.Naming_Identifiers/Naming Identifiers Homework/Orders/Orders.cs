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
                        .OrderByDescending(product => product.UnitPrice)
                        .Take(5)
                        .Select(product => product.Name);

            Console.WriteLine(string.Join(Environment.NewLine, first));
            Console.WriteLine(new string('-', 10));

            // Number of products in each Category
            var second = allProducts
                        .GroupBy(product => product.CatID)
                        .Select(group => new { Category = allCategories.First(c => c.ID == group.Key).Name, Count = group.Count() })
                        .ToList();
            foreach (var item in second)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by Order quantity)
            var third = allOrders
                        .GroupBy(o => o.ProductID)
                        .Select(group => new { Product = allProducts.First(p => p.ID == group.Key).Name, Quantities = group.Sum(grpgrp => grpgrp.Quant) })
                        .OrderByDescending(q => q.Quantities)
                        .Take(5);
            foreach (var item in third)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable Category
            var category = allOrders
                            .GroupBy(order => order.ProductID)
                            .Select(group => new { catId = allProducts.First(p => p.ID == group.Key).CatID, price = allProducts.First(p => p.ID == group.Key).UnitPrice, quantity = group.Sum(p => p.Quant) })
                            .GroupBy(categ => categ.catId)
                            .Select(goup => new { category_name = allCategories.First(c => c.ID == goup.Key).Name, total_quantity = goup.Sum(g => g.quantity * g.price) })
                            .OrderByDescending(group => group.total_quantity)
                            .First();
            Console.WriteLine("{0}: {1}", category.category_name, category.total_quantity);
        }
    }
}
