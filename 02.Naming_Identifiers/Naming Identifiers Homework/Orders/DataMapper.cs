using System.Collections.Generic;
using System.Linq;
using Orders;
using System.IO;

namespace Orders
{
    public class dataMapper
    {
        private string categoriesFileName;
        private string productsFileName;
        private string ordersFileName;

        private const string categoriesPath = "../../Data/categories.txt";
        private const string productsPath = "../../Data/products.txt";
        private const string ordersPath = "../../Data/orders.txt";

        public dataMapper()
        {
            this.categoriesFileName = categoriesPath;
            this.ordersFileName = ordersPath;
            this.productsFileName = productsPath;
        }

        public IEnumerable<Category> getAllCategories()
        {
            List<string> cat = readFileLines(this.categoriesFileName, true);

            return cat
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    ID = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });
        }

        public IEnumerable<Product> getAllProducts()
        {
            var products = readFileLines(this.productsFileName, true);
            return products
                .Select(product => product.Split(','))
                .Select(product => new Product
                {
                    ID = int.Parse(product[0]),
                    Name = product[1],
                    CatID = int.Parse(product[2]),
                    UnitPrice = decimal.Parse(product[3]),
                    UnitsInStock = int.Parse(product[4]),
                });
        }

        public IEnumerable<Order> getAllOrders()
        {
            var orders = readFileLines(this.ordersFileName, true);
            return orders
                .Select(order => order.Split(','))
                .Select(order => new Order
                {
                    ID = int.Parse(order[0]),
                    ProductID = int.Parse(order[1]),
                    Quant = int.Parse(order[2]),
                    Discount = decimal.Parse(order[3]),
                });
        }

        private List<string> readFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}
