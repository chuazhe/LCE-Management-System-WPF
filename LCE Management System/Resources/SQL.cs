using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

namespace LCE_Management_System.Resources
{
    class SQL
    {
        private static string connString = @"Data Source=40NY1G2\SQLEXPRESS;Initial Catalog = LCE; Integrated Security = True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        string[] companyDetails;
        bool isDbOnline;

        public bool CheckDb()
        {
            try
            {
                con = new SqlConnection(connString);
                con.Open();
                isDbOnline = true;


            }

            catch (Exception e)
            {
                isDbOnline = false;
                MessageBox.Show("Database is not connected!");
                MessageBox.Show("Error:" + e);
            }
            finally
            {
                con.Close();

            }
            return isDbOnline;
        }


        public SqlDataAdapter ShowAllInvoice()
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("select InvoiceId, FORMAT(InvoiceDate,'%d-MM-yyyy') As DateA,Company.CompanyName As NameCompany,InvoicePrice, FORMAT(InvoiceDueDate,'%d-MM-yyyy') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId", con);
                con.Open();
                da = new SqlDataAdapter(cmd);
            }
            finally
            {
                con.Close();
                cmd.Dispose();

            }
            return da;
        }

        public SqlDataAdapter ShowAllInvoiceWithDate(string FromDate, string ToDate)
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("select InvoiceId, FORMAT(InvoiceDate, '%d-MM-yyyy') As DateA, Company.CompanyName As NameCompany, InvoicePrice, FORMAT(InvoiceDueDate, '%d-MM-yyyy') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId = Company.CompanyId WHERE(InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", con);
                con.Open();
                da = new SqlDataAdapter(cmd);
            }
            finally
            {

                con.Close();
                cmd.Dispose();

            }
            return da;
        }


        public SqlDataAdapter ShowPaidInvoice()
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("select InvoiceId, FORMAT(InvoiceDate,'%d-MM-yyyy') As DateA,Company.CompanyName As NameCompany,InvoicePrice, FORMAT(InvoiceDueDate,'%d-MM-yyyy') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='Y'", con);
                con.Open();
                da = new SqlDataAdapter(cmd);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return da;
        }

        public SqlDataAdapter ShowPaidInvoiceWithDate(string FromDate, string ToDate)
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("select InvoiceId, FORMAT(InvoiceDate, '%d-MM-yyyy') As DateA, Company.CompanyName As NameCompany, InvoicePrice, FORMAT(InvoiceDueDate, '%d-MM-yyyy') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId = Company.CompanyId WHERE StatusPaid = 'Y' AND(InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", con);
                con.Open();
                da = new SqlDataAdapter(cmd);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return da;
        }

        public SqlDataAdapter ShowUnpaidInvoice()
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("select InvoiceId, FORMAT(InvoiceDate, '%d-MM-yyyy') As DateA, Company.CompanyName As NameCompany, InvoicePrice, FORMAT(InvoiceDueDate, '%d-MM-yyyy') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId = Company.CompanyId WHERE StatusPaid = 'N'", con);
                con.Open();
                da = new SqlDataAdapter(cmd);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return da;
        }

        public SqlDataAdapter ShowUnpaidInvoiceWithDate(string FromDate, string ToDate)
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("select InvoiceId, FORMAT(InvoiceDate,'%d-MM-yyyy') As DateA,Company.CompanyName As NameCompany,InvoicePrice, FORMAT(InvoiceDueDate,'%d-MM-yyyy') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='N' AND (InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", con);
                con.Open();
                da = new SqlDataAdapter(cmd);
            }
            finally
            {

                con.Close();
                cmd.Dispose();
            }
            return da;
        }


        public SqlDataAdapter ShowAllCompany()
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("SELECT CompanyId, CompanyName FROM Company", con);
                con.Open();
                da = new SqlDataAdapter(cmd);
            }
            finally
            {

                con.Close();
                cmd.Dispose();

            }
            return da;

        }

        public void PayInvoice(string InvoiceId)
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("UPDATE Invoice SET StatusPaid=@Yes WHERE InvoiceId=@Id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Yes", "Y");
                cmd.Parameters.AddWithValue("@Id", InvoiceId);
                //add whatever parameters you required to update here
                int result = cmd.ExecuteNonQuery();
                ShowSQLMessageBox(result);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }

        }

        public double ReturnSum()
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("SELECT SUM(InvoicePrice) FROM Invoice WHERE StatusPaid=@No", con);
                con.Open();
                cmd.Parameters.AddWithValue("@No", "N");
                //add whatever parameters you required to update here
                double mySum = Convert.ToDouble(cmd.ExecuteScalar());
                return mySum;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        public string ReturnCountOfInvoice()
        {
            string countOfInvoice = string.Empty;
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("SELECT COUNT(*) FROM INVOICE WHERE MONTH(InvoiceDate) = @currentMonth AND YEAR(InvoiceDate)=@currentYear; ", con);
                con.Open();
                string sMonth = DateTime.Now.ToString("MM");
                string sYear = DateTime.Now.ToString("yyyy");
                cmd.Parameters.AddWithValue("@currentMonth", sMonth);
                cmd.Parameters.AddWithValue("@currentYear", sYear);
                //add whatever parameters you required to update here
                countOfInvoice = (cmd.ExecuteScalar()).ToString();
                
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                
            }
            return countOfInvoice;

        }

        public string ReturnBusiness()
        {
            string countOfInvoice = string.Empty;
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("SELECT SUM(InvoicePrice) FROM INVOICE WHERE MONTH(InvoiceDate) = @currentMonth AND YEAR(InvoiceDate)=@currentYear; ", con);
                con.Open();
                string sMonth = DateTime.Now.ToString("MM");
                string sYear = DateTime.Now.ToString("yyyy");
                cmd.Parameters.AddWithValue("@currentMonth", sMonth);
                cmd.Parameters.AddWithValue("@currentYear", sYear);
                //add whatever parameters you required to update here
                countOfInvoice= (cmd.ExecuteScalar()).ToString();

            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return countOfInvoice;
        }

        public SqlDataAdapter ShowCompanyInvoices(string companyId)
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("select InvoiceId, FORMAT(InvoiceDate, '%d-MM-yyyy') As DateA, Company.CompanyName As NameCompany, InvoicePrice, FORMAT(InvoiceDueDate, '%d-MM-yyyy') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId = Company.CompanyId WHERE Invoice.CompanyId = @CompanyId", con);
                con.Open();
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                da = new SqlDataAdapter(cmd);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return da;
        }



        public string[] GetCompanyDetails(string companyId)
        {
            try
            {
                con = new SqlConnection(connString);
                cmd = new SqlCommand("select CompanyId, CompanyName, CompanyAddressOne, CompanyAddressTwo, CompanyAddressThree FROM Company WHERE CompanyId = @CompanyId", con);
                con.Open();
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
             SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read()) {
              
                companyDetails =new string[5] { reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)};
                  }
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return companyDetails;
        }

        public void ShowSQLMessageBox(int result)
        {
            if (result == 0)
            {
                MessageBox.Show("Fail!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Not updated.
            else
            {
                MessageBox.Show("Successful!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }



    }
}
