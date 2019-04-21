using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Repository
{
    public class ProductRepository
    {
        private ObservableCollection<Product> products;

        public ProductRepository()
        {
            products = new ObservableCollection<Product>
            {
                new Product {Id=1, Description="Samsung", Price=100 },
                new Product {Id=2, Description="Sony", Price=20 },
                new Product {Id=3, Description="Lg", Price=40 },
                new Product {Id=4, Description="Huawai", Price=50 },
                new Product {Id=5, Description="Test", Price=40}

            };
        }

        public ObservableCollection<Product> GetProducts()
        {
            return products;
        }
    }
}
