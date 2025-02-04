using Task5.Model;
using Task5.Repository;

namespace Task5
{
    public class QueryBuilder
    {
        ProductRepository productRepository;

        public QueryBuilder(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public List<Product> Filter(Func<Product, bool> predicate)
        {
            List<Product> filterList = new List<Product>();

            foreach (var product in productRepository.GetProductList())
            {
                if (predicate(product))
                    filterList.Add(product);
            }

            return filterList;
        }

        public List<Product> SortBy(Func<Product, string> predicate)
        {
            foreach (Product product in productRepository.GetProductList())
            {
                if (predicate(product) == product.ProductName)
                {
                    List<Product> filterList = productRepository.GetProductList().OrderBy(p => p.ProductName).ToList();
                    return filterList;
                }
                else if (predicate(product) == product.ProductId.ToString())
                {
                    List<Product> filterList = productRepository.GetProductList().OrderBy(p => p.ProductId).ToList();
                    return filterList;
                }
                else if (predicate(product) == product.ProductPrice.ToString())
                {
                    List<Product> filterList = productRepository.GetProductList().OrderBy(p => p.ProductPrice).ToList();
                    return filterList;
                }
                else if (predicate(product) == product.ProductCategory.ToString())
                {
                    List<Product> filterList = productRepository.GetProductList().OrderBy(p => p.ProductId).ToList();
                    return filterList;
                }
            }

            return new List<Product>();
        }
    }
}