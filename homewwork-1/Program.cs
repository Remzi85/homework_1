namespace homewwork_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. All Products");
                Console.WriteLine("2. Get Product");
                Console.WriteLine("3. Create Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out var option) || option == 5) break;

                switch (option)
                {
                    case 1:
                        var products = productService.GetAll();
                        if (products.Count == 0)
                        {
                            Console.WriteLine("No products found.");
                        }
                        else
                        {
                            foreach (var product in products)
                            {
                                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, CostPrice: {product.CostPrice}, SalePrice: {product.SalePrice}");
                            }
                        }
                        break;

                    case 2:
                        Console.Write("Enter Product ID: ");
                        if (int.TryParse(Console.ReadLine(), out var id))
                        {
                            try
                            {
                                var product = productService.Get(id);
                                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, CostPrice: {product.CostPrice}, SalePrice: {product.SalePrice}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case 3:
                        try
                        {
                            var product = new Product();
                            Console.Write("Enter Product Name: ");
                            product.Name = Console.ReadLine();
                            Console.Write("Enter CostPrice: ");
                            product.CostPrice = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter SalePrice: ");
                            product.SalePrice = decimal.Parse(Console.ReadLine());
                            productService.Create(product);
                            Console.WriteLine("Product created successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Product ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            try
                            {
                                productService.Delete(id);
                                Console.WriteLine("Product deleted successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}