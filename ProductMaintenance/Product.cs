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
        //private string description;  //has a self bodies property
        private decimal price;


        /// <summary>
        /// This constructor create a Product object with default values
        /// </summary>
        public Product()
        {

        }
        /// <summary>
        /// This constructor creates an object with defined/passed values
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        public Product(string code, string description, decimal price)
        {
          
            Code = code;  //invoking the set method of Code property
            Description = description;
            Price = price;

        }

        //properties
        /// <summary>
        /// The property to set and get the code. The code is validated
        /// and must be f length 4
        /// </summary>
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                if (value.Length != 4)
                    throw new ArgumentException("Code has to be of length 4");
                code = value;
            }

        }

        //self bodied property- the associated field 'description' is automatically defined
        //the only way to access that field description is through this property
        public string Description { get;  set; }
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
        /// <summary>
        /// This method returns the product information for displaying purposes
        /// </summary>
        /// <param name="sep">The separator between the fields</param>
        /// <returns></returns>
       // public string GetDisplayText(string sep)

       // {
            // string cc = Code; //invoking the get method
          //  return Code + sep + Description + sep + Price.ToString("c");
       // }


        //self bodied method using lambda operator

        public string GetDisplayText(string sep) => Code + sep + Description + sep + Price.ToString("c");
            
        /// <summary>
        /// Overloaded method - This method returns the product information for displaying purposes
        /// </summary>
        /// <returns></returns>
        public string GetDisplayText()

        {
            // string cc = Code; //invoking the get method
            return Code + "\t" + Description + "\t" + Price.ToString("c");
        }
    }
}
