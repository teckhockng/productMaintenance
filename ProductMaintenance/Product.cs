using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaintenance
{
    public class Product
    {
        //fields
        private string code;
        private string description;
        private decimal price;

        public Product()
        {

        }

        /// <summary>
        /// The constructor sets the values of the fields
        /// </summary>
        /// <param name="code">The code of the product</param>
        /// <param name="description">The description of the product</param>
        /// <param name="price">The price of the product</param>
        public Product(string code, string description, decimal price)
        {
            Code = code;
            this.Description = description;
            Price = price;
        }

        //properties - getters and setters
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                if(value.Length != 4)
                {
                    throw new ArgumentException("Code must be 4 characters.");
                }
                code = value;
            }
        }

        //self bodied property - by default a private instance variable is created by description
        public string Description { get; set; }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        //method
        public string GetDisplay(string sep)
        {
            //use the getters
            return Code + sep + Description + sep + Price.ToString("c");
        }


    }
}
