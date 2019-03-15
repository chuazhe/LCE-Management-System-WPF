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

        public bool CheckDb()
        {
            bool isDbOnline;
            try
            {
                using (SqlConnection myCon = new SqlConnection(connString))
                {
                    myCon.Open();
                    myCon.Close();
                    isDbOnline = true;

                }
            }
            catch (Exception e)
            {
                isDbOnline = false;
                MessageBox.Show("Database is not connected!");
                MessageBox.Show("Error:" + e);
            }
            return isDbOnline;
        }


        public SqlDataAdapter ShowAllInvoice()
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                   new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId", myCon))
                {
                    // create data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Dispose();
                    myCon.Close();
                    return da;

                }
            }
        }

        public SqlDataAdapter ShowAllInvoiceWithDate(string FromDate, string ToDate)
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                   new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE (InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", myCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Dispose();
                    myCon.Close();
                    return da;
                }
            }
        }


        public SqlDataAdapter ShowPaidInvoice()
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                    new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='Y'", myCon))
                {
                    // create data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Dispose();
                    myCon.Close();
                    return da;
                }
            }
        }

        public SqlDataAdapter ShowPaidInvoiceWithDate(string FromDate, string ToDate)
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                   new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='Y' AND (InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", myCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Dispose();
                    myCon.Close();
                    return da;
                }
            }
        }

        public SqlDataAdapter ShowUnpaidInvoice()
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                    new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='N'", myCon))
                {
                    // create data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Dispose();
                    myCon.Close();
                    return da;
                }
            }
        }

        public SqlDataAdapter ShowUnpaidInvoiceWithDate(string FromDate, string ToDate)
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                   new SqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='N' AND (InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", myCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Dispose();
                    myCon.Close();
                    return da;
                }
            }
        }


        public SqlDataAdapter ShowAllCompany()
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                    new SqlCommand("SELECT CompanyId,CompanyName FROM Company", myCon))
                {
                    // create data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Dispose();
                    myCon.Close();
                    return da;
                }
            }
        }

        public void PayInvoice(string InvoiceId)
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Invoice SET StatusPaid=@Yes WHERE InvoiceId=@Id", myCon))
                {
                    cmd.Parameters.AddWithValue("@Yes", "Y");
                    cmd.Parameters.AddWithValue("@Id", InvoiceId);
                    //add whatever parameters you required to update here
                    int result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    myCon.Close();
                    ShowSQLMessageBox(result);
                }
            }


        }

        public double ReturnSum()
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                    new SqlCommand("SELECT SUM(InvoicePrice) FROM Invoice WHERE StatusPaid=@No", myCon))
                {
                    cmd.Parameters.AddWithValue("@No", "N");
                    //add whatever parameters you required to update here
                    double mySum = Convert.ToDouble(cmd.ExecuteScalar());
                    cmd.Dispose();
                    myCon.Close();
                    return mySum;

                }
            }

        }

        public string ReturnCountOfInvoice()
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                    new SqlCommand("SELECT COUNT(*) FROM INVOICE WHERE MONTH(InvoiceDate) = @currentMonth AND YEAR(InvoiceDate)=@currentYear; ", myCon))
                {
                    string sMonth = DateTime.Now.ToString("MM");
                    string sYear = DateTime.Now.ToString("yyyy");
                    cmd.Parameters.AddWithValue("@currentMonth", sMonth);
                    cmd.Parameters.AddWithValue("@currentYear", sYear);
                    //add whatever parameters you required to update here
                    string countOfInvoice = (cmd.ExecuteScalar()).ToString();
                    cmd.Dispose();
                    myCon.Close();
                    return countOfInvoice;

                }
            }

        }

        public string ReturnBusiness()
        {
            using (SqlConnection myCon = new SqlConnection(connString))
            {
                myCon.Open();
                using (SqlCommand cmd =
                    new SqlCommand("SELECT SUM(InvoicePrice) FROM INVOICE WHERE MONTH(InvoiceDate) = @currentMonth AND YEAR(InvoiceDate)=@currentYear; ", myCon))
                {
                    string sMonth = DateTime.Now.ToString("MM");
                    string sYear = DateTime.Now.ToString("yyyy");
                    cmd.Parameters.AddWithValue("@currentMonth", sMonth);
                    cmd.Parameters.AddWithValue("@currentYear", sYear);
                    //add whatever parameters you required to update here
                    string countOfInvoice = (cmd.ExecuteScalar()).ToString();
                    cmd.Dispose();
                    myCon.Close();
                    return countOfInvoice;

                }
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
