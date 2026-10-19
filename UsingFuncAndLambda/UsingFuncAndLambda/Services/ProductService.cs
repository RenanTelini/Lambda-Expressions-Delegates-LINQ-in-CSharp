using UsingFuncAndLambda.Entities;

namespace UsingFuncAndLambda.Services
{
    class ProductService
    {
        public double FilteredSum(List<Product> list, Func<Product, bool> criteria)
        {
            double sum = 0;
            foreach (Product p in list)
            {
                if (criteria(p))
                    sum += p.Price;
            }

            return sum;
        }
    }
}