namespace dz10
{
    internal class Program
    {
        class Product
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Name { get; set; }
            public double Price { get; set; }
            public string Category { get; set; }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            List<Product> products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 25000, Category = "Electronics" },
                new Product { Name = "Smartphone", Price = 15000, Category = "Electronics" },
                new Product { Name = "Refrigerator", Price = 30000, Category = "Home Appliances" },
                new Product { Name = "Iron", Price = 2000, Category = "Home Appliances" },
                new Product { Name = "Book", Price = 500, Category = "Books" },
                new Product { Name = "Headphones", Price = 3000, Category = "Electronics" }
            };

            Console.WriteLine("All products:");
            products.ForEach(p => Console.WriteLine($"{p.Id} | {p.Name} | {p.Price} UAH | {p.Category}"));

            Console.Write("Enter product name to search: ");
            string searchName = Console.ReadLine();
            var foundProduct = products.FirstOrDefault(p => p.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(foundProduct != null ? $"Found: {foundProduct.Name} - {foundProduct.Price} UAH" : "Product not found");

            Console.Write("Enter category to filter by: ");
            string searchCategory = Console.ReadLine();
            var filteredProducts = products.Where(p => p.Category.Equals(searchCategory, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Products in this category:");
            foreach (var product in filteredProducts)
                Console.WriteLine($"{product.Name} - {product.Price} UAH");

            var mostExpensive = products.OrderByDescending(p => p.Price).First();
            Console.WriteLine($"Most expensive product: {mostExpensive.Name} - {mostExpensive.Price} UAH");

            Console.Write("Enter product Id to delete: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid deleteId))
            {
                var productToRemove = products.FirstOrDefault(p => p.Id == deleteId);
                if (productToRemove != null)
                {
                    products.Remove(productToRemove);
                    Console.WriteLine("Product deleted!");
                }
                else Console.WriteLine("Product not found!");
            }

            Console.WriteLine("Products sorted by price ascending:");
            foreach (var product in products.OrderBy(p => p.Price))
                Console.WriteLine($"{product.Name} - {product.Price} UAH");

            Console.Write("Enter product Id to change price: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid editId))
            {
                var productToEdit = products.FirstOrDefault(p => p.Id == editId);
                if (productToEdit != null)
                {
                    Console.Write("Enter new price: ");
                    if (double.TryParse(Console.ReadLine(), out double newPrice))
                    {
                        productToEdit.Price = newPrice;
                        Console.WriteLine("Price updated!");
                    }
                    else Console.WriteLine("Invalid price value!");
                }
                else Console.WriteLine("Product not found!");
            }
            Console.ReadLine();
        }
    }
}
