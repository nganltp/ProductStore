using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace IntroADO_NET
{
    public class ProductData
    {
        string strConnection;
        public ProductData()
        {
            getConnectionString();
        }
        //Khai bao ham lay chuoi ket not to tap tin App.config 
        public string getConnectionString()
        {
            strConnection = ConfigurationManager.ConnectionStrings["SaleDB"].ConnectionString;
            return strConnection;
        }
        //Khai bao phuong thuc lay cac product 
        public DataTable GetProducts()
        {
            string SQL = "select ' from Products";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtProduct = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dtProduct);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally { cnn.Close(); }
            return dtProduct;
        }
        public bool AddProduct(Product p)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert Products values(@ID,@Name,@Price,@Quantity)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", p.ProductID);
            cmd.Parameters.AddWithValue("@Name", p.ProductName);
            cmd.Parameters.AddWithValue("@Price", p.UnitPrice);
            cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool updateProduct(Product p)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Update Products set ProductName=@Name,UnitPrice=@Price," + "Quantity=@Quantity where ProductlD=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", p.ProductID);
            cmd.Parameters.AddWithValue("@Name", p.ProductName);
            cmd.Parameters.AddWithValue("@Price", p.UnitPrice);
            cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
            try
            {
                if (cnn.State == ConnectionState.Closed) { cnn.Open(); }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return result;
        }
        public bool DeleteProduct(int ProductID)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Delete Products where ProductlD=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", ProductID);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}

