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
        private ProductList products;

        public frmMain()
        {

            products = new ProductList();
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            products.Changed += new ProductList.ChangeHandler(HandleChange);
            products.Fill();
            FillProductListBox();
        }

        private void HandleChange(ProductList products)
        {
            products.Save();
            FillProductListBox();
        }

        private void FillProductListBox()
        {
            Product p;

            lstProducts.Items.Clear();
            for(int i = 0; i < products.Count; i++)
            {
                p = products[i];
                lstProducts.Items.Add(p.GetDisplay("\t"));
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstProducts.SelectedIndex;
            Product p;
            bool flag = false;

            if(selectedIndex != -1)
            {
                DialogResult confirm = MessageBox.Show("Do you want this selected product?", "Confirm Delete", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (confirm == DialogResult.Yes)
                {
                    p = products[selectedIndex];
                    // products.Remove(p);
                    flag = products - p; // overloaded operator -
                    if (flag)
                        MessageBox.Show("Product deleted");
                    else
                        MessageBox.Show("Product is not deleted");
                    
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmNewProduct newProduct = new frmNewProduct();
            newProduct.ShowDialog();
            Product p = newProduct.GetNewProduct();

            if(p != null)
            {
                products += p;
            }
        }
    }
}
