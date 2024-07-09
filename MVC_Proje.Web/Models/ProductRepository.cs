namespace MVC_Proje.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            //new() { Id = 1, productName = "Kalem", Price = 23, Stock = 32 },
            //new() { Id = 2, productName = "Mürekkep", Price = 38, Stock = 88 },
            //new() { Id = 3, productName = "Defter", Price = 12, Stock = 43 },
            //new() { Id = 4, productName = "Cüzdan", Price = 56, Stock = 62 },
        };
        // static ile class ismi kullanılarak erişim sağlanabilir.


      

        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);

            if(hasProduct == null)
            {
                throw new Exception($"Bu id '({id})' ye sahip ürün bulunmamaktadır.");

            }
           
             _products.Remove(hasProduct);
            
        }


        public void Update(Product updateProduct)
        {

            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id '({updateProduct.Id})' ye sahip ürün bulunmamaktadır.");

            }

            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;


            var index = _products.FindIndex(x => x.Id == updateProduct.Id);
            _products[index] = hasProduct;
        }


    }


}
