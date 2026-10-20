using LINQExampleProblem.Entities;
using System.Globalization;

namespace LINQExampleProblem
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter full file path: ");
                string path = Console.ReadLine();

                List<Product> listProduct = new List<Product>();

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        listProduct.Add(new Product(name, price));
                    }
                }

                double avg = listProduct.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
                Console.WriteLine("Average price: " + avg.ToString("F2", CultureInfo.InvariantCulture));

                var names = listProduct.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);

                foreach (var p in names)
                {
                    Console.WriteLine(p);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}