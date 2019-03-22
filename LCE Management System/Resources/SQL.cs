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
                cmd = new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId", con);
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
                cmd = new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate, '%d-%m-%y') As DateA, Company.CompanyName As NameCompany, InvoicePrice, DATE_FORMAT(InvoiceDueDate, '%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId = Company.CompanyId WHERE(InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", con);
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
                cmd = new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='Y'", con);
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
                cmd = new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate, '%d-%m-%y') As DateA, Company.CompanyName As NameCompany, InvoicePrice, DATE_FORMAT(InvoiceDueDate, '%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId = Company.CompanyId WHERE StatusPaid = 'Y' AND(InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", con);
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
                cmd = new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate, '%d-%m-%y') As DateA, Company.CompanyName As NameCompany, InvoicePrice, DATE_FORMAT(InvoiceDueDate, '%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId = Company.CompanyId WHERE StatusPaid = 'N'", con);
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
                cmd = new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='N' AND (InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", con);
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
                string countOfInvoice = (cmd.ExecuteScalar()).ToString();
                return countOfInvoice;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        public string ReturnBusiness()
        {
            try
            {
                string sMonth = DateTime.Now.ToString("MM");
                string sYear = DateTime.Now.ToString("yyyy");
                cmd.Parameters.AddWithValue("@currentMonth", sMonth);
                cmd.Parameters.AddWithValue("@currentYear", sYear);
                //add whatever parameters you required to update here
                string countOfInvoice = (cmd.ExecuteScalar()).ToString();
                cmd.Dispose();
                con.Close();
                return countOfInvoice;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
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
