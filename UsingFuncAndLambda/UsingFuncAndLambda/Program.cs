using UsingFuncAndLambda.Entities;
using UsingFuncAndLambda.Services;
using System.Globalization;

namespace UsingFuncAndLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.0));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            ProductService productService = new ProductService();

            double sum = productService.FilteredSum(list, p => p.Name[0] == 'T');

            Console.WriteLine("Sum: " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}