using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using LCE_Management_System.Resources;
using System.Data.SqlClient;
using System.Threading;

namespace LCE_Management_System
{
    /// <summary>
    /// Interaction logic for Company.xaml
    /// </summary>
    public partial class Company : UserControl
    {
        private DataTable dataTable = new DataTable();
        SQL ob = new SQL();

        public Company()
        {
            InitializeComponent();
            // this will query your database and return the result to your datatable
            ob.ShowAllCompany().Fill(dataTable);
            dataGrid3.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding { Source = dataTable });
        }


        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid3.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            CompanyInvoice w2 = new CompanyInvoice(cellValue);
            w2.Show();

        }
    }

}
