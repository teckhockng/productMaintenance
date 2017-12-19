using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductMaintenance
{
    public static class Validator
    {
        private static string title ;  //can remove this definition since has a self bodied property
        public static string Title { get; set; }

        public static bool IsPresent(TextBox textBox)
        {
            Title = " Entry Error";
            Title = textBox.Tag + Title;

            if(textBox.Text == String.Empty)
                {
                MessageBox.Show(textBox.Tag + " is a required field...cannot be left blank.", Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;

            }
            return true;


        }

        public static bool IsDecimal(TextBox textBox)
        {
            decimal number = 0;

            Title = " Non Numeric Error";
            Title = textBox.Tag + Title;

            if(Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }

            MessageBox.Show(textBox.Tag + " must be a decimal value.", Title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox.SelectAll();
            textBox.Focus();
            return false;

        }

        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            Title = " Out Of Range Error";
            Title = textBox.Tag + Title;

            decimal number = Convert.ToDecimal(textBox.Text);

            if (number > min && number <= max)
                return true;

            MessageBox.Show(textBox.Tag + " must be a decimal value > " + min + " and <= " + max, Title,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox.SelectAll();
            textBox.Focus();
            return false;

        }






    }
}
