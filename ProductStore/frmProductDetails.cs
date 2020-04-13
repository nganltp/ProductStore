using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductStore
{
    public partial class frmProductDetails : Form
    {
        public frmProductDetails()
        {
            InitializeComponent();
        }
        //Khai bao bien de luu trang thai cap nhat hay them moi 
        private bool addOrEdit; //Khai bao properties de nhan action : true = them moi, false : cap nhat 
        public Product ProductAddOrEdit { get; set; }

        public frmProductDetails(bool flag, ProductStore p) : this()
        {
            addOrEdit = flag;
            ProductAddOrEdit = p;
            InitData();
        }

        //Khai bao phuong thuc dung de hien thi du lieu 
        private void InitData() {
            txtProductID.Text = ProductAddOrEdit.ProductID.ToString();
            txtProductName.Text = ProductAddOrEdit.ProductName;
            txtUnitPrice.Text = ProductAddOrEdit.UnitPrice.ToString();
            txtQuantity.Text = ProductAddOrEdit.Quantity.ToString();
        }

        private void btnSave Click(object sender, EventArgs e)
        {
            bool flag;
            ProductAddOrEdit.ProductID = int.Parse(txtProductID.Text);
            ProductAddOrEdit.ProductName = txtProductName.Text;
            ProductAddOrEdit.UnitPrice = double.Parse(txtUnitPrice.Text);
            ProductAddOrEdit.Quantity = int.Parse(txtQuantity.Text);
            ProductData proData = new ProductData();
            //Neu action la them moi product 
            if (addOrEdit == true) {
                flag = proData.AddProduct(ProductAddOrEdit);
            } //neu action la cap nhat product 
            else {
                flag = proData.UpdateProduct(ProductAddOrEdit);
            } //Xuat thong bao 
            if (flag == true) MessageBox.Show("Save successful.");
            else MessageBox.Show("Save fail.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
