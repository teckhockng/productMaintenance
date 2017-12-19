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
    public partial class frmMain : Form
    {

        private List<Product> products = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmNewProduct newProductForm = new frmNewProduct();
            newProductForm.ShowDialog();
            Product product = newProductForm.GetNewProduct();
            if(product != null)
                {
                products.Add(product);
                ProductDB.SaveProducts(products);
                FillProductListBox();

                
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            products = ProductDB.GetProducts();
            FillProductListBox();

        }

        private void FillProductListBox()
        {
            lstProducts.Items.Clear();
            foreach (Product product in products)
            {
                lstProducts.Items.Add(product.GetDisplayText("\t"));
            }
            
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int i = lstProducts.SelectedIndex;

            if(i != -1)
            {
                DialogResult confirm = MessageBox.Show("Sure you want to delete this product?",
                    "Confirm DDelete", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
               Product product = products[i];
                if(confirm == DialogResult.Yes)
                {
                   // products.RemoveAt(i);
                    products.Remove(product);
                    ProductDB.SaveProducts(products);
                    FillProductListBox();
                }

            }
            else
            {
                MessageBox.Show("Please select the product to be deleted",
                    "Unsuccessful Delete", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
