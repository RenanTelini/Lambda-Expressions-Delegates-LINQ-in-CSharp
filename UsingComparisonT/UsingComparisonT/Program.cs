using UsingComparisonT.Entities;

class Program
{
    static void Main(string[] args)
    {
        List<Product> list = new List<Product>();

        list.Add(new Product("TV", 900));
        list.Add(new Product("Notebook", 1200));
        list.Add(new Product("Tablet", 450));

        list.Sort();

        foreach(Product p in list)
        {
            Console.WriteLine(p);
        }
    }
}