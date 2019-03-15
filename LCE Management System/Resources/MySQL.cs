using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace LCE_Management_System.Resources
{
    class MySQL
    {
        private static string connString = "Server=localhost;Uid=root;Pwd=cHz&XF$aSKmJ;database=testing_server";
        private MySqlConnection conn = new MySqlConnection(connString);



        public MySqlDataAdapter ShowAllInvoice()
        {
            using (conn)
            {
                conn.Open();
                using (MySqlCommand cmd =
                   new MySqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId", conn))
                {
                    // create data adapter
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Dispose();
                    conn.Close();
                    return da;
                }
            }
        }

        public MySqlDataAdapter ShowAllInvoiceWithDate(string FromDate, string ToDate)
        {
            using (conn)
            {
                conn.Open();
                using (MySqlCommand cmd =
                   new MySqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE (InvoiceDate between '"+ FromDate +"' AND '"+ ToDate+"')", conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Dispose();
                    conn.Close();
                    return da;
                }
            }
        }


        public MySqlDataAdapter ShowPaidInvoice()
        {
            using (conn)
            {
                conn.Open();
                using (MySqlCommand cmd =
                    new MySqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='Y'", conn))
                {
                    // create data adapter
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Dispose();
                    conn.Close();
                    return da;
                }
            }
        }

        public MySqlDataAdapter ShowPaidInvoiceWithDate(string FromDate, string ToDate)
        {
            using (conn)
            {
                conn.Open();
                using (MySqlCommand cmd =
                   new MySqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='Y' AND (InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Dispose();
                    conn.Close();
                    return da;
                }
            }
        }

        public MySqlDataAdapter ShowUnpaidInvoice()
        {
            using (conn)
            {
                conn.Open();
                using (MySqlCommand cmd =
                    new MySqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='N'", conn))
                {
                    // create data adapter
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Dispose();
                    conn.Close();
                    return da;
                }
            }
        }

        public MySqlDataAdapter ShowUnpaidInvoiceWithDate(string FromDate, string ToDate)
        {
            using (conn)
            {
                conn.Open();
                using (MySqlCommand cmd =
                   new MySqlCommand("select InvoiceId, DATE_FORMAT(InvoiceDate,'%d-%m-%y') As DateA,Company.CompanyName As NameCompany,InvoicePrice, DATE_FORMAT(InvoiceDueDate,'%d-%m-%y') AS DateB, StatusPaid FROM Invoice INNER JOIN Company ON Invoice.CompanyId=Company.CompanyId WHERE StatusPaid='N' AND (InvoiceDate between '" + FromDate + "' AND '" + ToDate + "')", conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Dispose();
                    conn.Close();
                    return da;
                }
            }
        }


        public MySqlDataAdapter ShowAllCompany()
        {
            using (conn)
            {
                conn.Open();
                using (MySqlCommand cmd =
                    new MySqlCommand("SELECT CompanyId,CompanyName from Company", conn))
                {
                    // create data adapter
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Dispose();
                    conn.Close();
                    return da;
                }
            }
        }

        public void PayInvoice(string InvoiceId)
        {
            using (conn)
            {
                conn.Open();
                using (MySqlCommand cmd =
                    new MySqlCommand("UPDATE Invoice SET StatusPaid=@Yes WHERE InvoiceId=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Yes", "Y");
                    cmd.Parameters.AddWithValue("@Id", InvoiceId);
                    //add whatever parameters you required to update here
                    int result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    ShowSQLMessageBox(result);
                }
            }
            

        }

        public double ReturnSum()
        {
            using (conn)
            {
                conn.Open();
                using (MySqlCommand cmd =
                    new MySqlCommand("SELECT SUM(InvoicePrice) FROM Invoice WHERE StatusPaid=@No", conn))
                {
                    cmd.Parameters.AddWithValue("@No", "N");
                    //add whatever parameters you required to update here
                    double mySum = Convert.ToDouble(cmd.ExecuteScalar());
                    cmd.Dispose();
                    conn.Close();
                    return mySum;

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
