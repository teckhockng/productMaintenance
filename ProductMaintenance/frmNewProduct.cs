using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductMaintenance
{
    public partial class frmNewProduct : Form
    {

        private Product p;

        public frmNewProduct()
        {
            InitializeComponent();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.isPresent(txtCode) && Validator.isPresent(txtDescription) && Validator.isPresent(txtPrice)
                && Validator.isDecimal(txtPrice) && Validator.IsWithinRange(txtPrice, 0, 1000))
            {
                try
                {
                    p = new Product(txtCode.Text, txtDescription.Text, Convert.ToDecimal(txtPrice.Text));
                    this.Close();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Product GetNewProduct()
        {
            return p;
        }
    }
}
