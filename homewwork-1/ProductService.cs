using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace homewwork_1
{
    public class ProductService
    {
        private const string FilePath = "example.txt";

        public void Create(Product product)
        {
            var products = GetAll();
            products.Add(product);
            File.WriteAllText(FilePath, JsonSerializer.Serialize(products));
        }

        public Product Get(int id)
        {
            var products = GetAll();
            return products.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Product not found.");
        }

        public List<Product> GetAll()
        {
            if (!File.Exists(FilePath)) return new List<Product>();

            var fileContent = File.ReadAllText(FilePath);
            return string.IsNullOrEmpty(fileContent)
                ? new List<Product>()
                : JsonSerializer.Deserialize<List<Product>>(fileContent);
        }

        public void Delete(int id)
        {
            var products = GetAll();
            var productToRemove = products.FirstOrDefault(p => p.Id == id);
            if (productToRemove == null) throw new Exception("Product not found.");

            products.Remove(productToRemove);
            File.WriteAllText(FilePath, JsonSerializer.Serialize(products));
        }

    }
}
