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
                    Id = int.Parse(c[0]),
                    NAME = c[1],
                    Description = c[2]
                });
        }

        public IEnumerable<Product> getAllProducts()
        {
            var prod = readFileLines(this.productsFileName, true);
            return prod
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    id = int.Parse(p[0]),
                    nome = p[1],
                    catId = int.Parse(p[2]),
                    unit_price = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4]),
                });
        }

        public IEnumerable<Order> getAllOrders()
        {
            var ord = readFileLines(this.ordersFileName, true);
            return ord
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    ID = int.Parse(p[0]),
                    product_id = int.Parse(p[1]),
                    quant = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
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
