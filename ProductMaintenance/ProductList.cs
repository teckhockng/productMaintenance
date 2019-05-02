using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaintenance
{
    public class ProductList
    {
        //fields 
        private List<Product> products;

        public delegate void ChangeHandler(ProductList products); //type definition of a reference to a method
        public event ChangeHandler Changed;

        /// <summary>
        /// The constructor creates a List object to store information of products in the inventory
        /// </summary>
        public ProductList()
        {
            products = new List<Product>();
        }

        public int Count => products.Count;

        //indexer
        public Product this[int i]
        {
            get
            {
                if ((i < 0) || (i >= products.Count))
                    throw new ArgumentException("Product at the position does not exist");
                return products[i];
            }
            set
            {
                products[i] = value;
                Changed(this);
            }
        }

        public Product this[string code]
        {
            get
            {
                foreach (Product p in products)
                {
                    if (p.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase))
                        return p;
                }

                return null;
            }

        }

        public void Fill() => products = ProductDB.GetProducts();
        public void Save() => ProductDB.SaveProducts(products);

        /// <summary>
        /// This method adds a product to the list of products
        /// </summary>
        /// <param name="p">The product to be added</param>
        public void Add(Product p)
        {
            if (p != null)
            {
                products.Add(p);
                Changed(this);
            }
        }



        /// <summary>
        /// Overload the Add method
        /// </summary>
        /// <param name="code">The code of the product</param>
        /// <param name="description">The description of the product</param>
        /// <param name="price">The price of the product</param>
        public void Add(string code, string description, decimal price)
        {
            Product p = new Product(code, description, price);
            products.Add(p);
            Changed(this);
        }

        public bool Remove(Product p)
        {
            if(p != null)
            {
                products.Remove(p);
                Changed(this);
                return true;
            }

            return false;
        }


        //operator overloading
        public static ProductList operator +(ProductList p1, Product p)
        {
            p1.Add(p);
            return p1;
        }


        public static ProductList operator -(ProductList p1, Product p)
        {
            bool flag = p1.Remove(p);
            return p1;
        }

        public static implicit operator bool(ProductList v)
        {
            throw new NotImplementedException();
        }
    }
}
