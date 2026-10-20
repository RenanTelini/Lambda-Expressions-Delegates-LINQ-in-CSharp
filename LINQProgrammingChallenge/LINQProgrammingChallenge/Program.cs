using LINQProgrammingChallenge.Entities;
using System.Globalization;

namespace LINQProgrammingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter full file path: ");
                string path = Console.ReadLine();
                
                List<Employee> listProduct = new List<Employee>();

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        listProduct.Add(new Employee(name, email, salary));
                    }

                    Console.Write("Enter salary: ");
                    double salaryToCompare = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    IEnumerable<string> emailFiltered = 
                        listProduct
                        .Where(p => p.Salary > salaryToCompare)
                        .OrderBy(p => p.Name)
                        .Select(p => p.Email);

                    Console.WriteLine("Email of people whose salary is more than {0}:", salaryToCompare.ToString("F2", CultureInfo.InvariantCulture));
                    foreach (string p in emailFiltered)
                    {
                        Console.WriteLine(p);
                    }

                    double salarySum = listProduct
                        .Where(p => p.Name[0] == 'M')
                        .Sum(p => p.Salary);

                    Console.WriteLine("Sum of salary of people whose name starts with 'M': " + salarySum.ToString("F2", CultureInfo.InvariantCulture));
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
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