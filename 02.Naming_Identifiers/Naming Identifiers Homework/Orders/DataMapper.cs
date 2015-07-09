namespace Orders
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DataMapper
    {
        private const string CategoriesPath = "../../Data/categories.txt";
        private const string ProductsPath = "../../Data/products.txt";
        private const string OrdersPath = "../../Data/orders.txt";

        private string categoriesFileName;
        private string productsFileName;
        private string ordersFileName;

        public DataMapper()
        {
            this.categoriesFileName = CategoriesPath;
            this.ordersFileName = OrdersPath;
            this.productsFileName = ProductsPath;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            List<string> categories = this.ReadFileLines(this.categoriesFileName, true);

            return categories
                .Select(category => category.Split(','))
                .Select(category => new Category
                {
                    ID = int.Parse(category[0]),
                    Name = category[1],
                    Description = category[2]
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            List<string> products = this.ReadFileLines(this.productsFileName, true);

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

        public IEnumerable<Order> GetAllOrders()
        {
            List<string> orders = this.ReadFileLines(this.ordersFileName, true);

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

        private List<string> ReadFileLines(string filename, bool hasHeader)
        {
            //TODO hasHeader do not use
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
