using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductMaintenance
{
    public class Validator
    {
        private static string title;

        public static string Title { get; set;}

        //method to check if the input is provided
        public static bool isPresent(TextBox textBox)
        {
            if (textBox.Text == String.Empty)
            {
                Title = " Entry Error";
                Title = textBox.Tag + Title;
                MessageBox.Show(textBox.Tag + " is a required field...cannot be blank", Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;
            }
            return true;
        }

        //this method checks if the input is a decimal number
        public static bool isDecimal(TextBox textBox)
        {
            decimal number = 0m;

            if (Decimal.TryParse(textBox.Text, out number))
                return true;
            else
            {
                Title = " Entry Error";
                Title = textBox.Tag + Title;
                MessageBox.Show(textBox.Tag + " must be a decimal value", Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Select();
                textBox.Focus();
                return false;
            }
        }

        //check if price is within range
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);

            if (number >= min && number <= max)
                return true;

            Title = " Entry Error";
            Title = textBox.Tag + Title;
            MessageBox.Show(textBox.Tag + " must be between" + min + "and" + max, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox.SelectAll();
            textBox.Focus();
            return false;
        }
    }
}
