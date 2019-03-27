using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LCE_Management_System.Resources;
using System.Data;

namespace LCE_Management_System
{
    /// <summary>
    /// Interaction logic for CompanyInvoice.xaml
    /// </summary>
    public partial class CompanyInvoice : Window
    {
        DataTable dataTable = new DataTable();
        SQL ob = new SQL();
        private string cellValue;
        private string[] companyDetails;

        /*
        public CompanyInvoice()
        {
            InitializeComponent();
        }
        */

        public CompanyInvoice(string cellValue)
        {
            InitializeComponent();
            this.cellValue = cellValue;
            ShowTable();

            companyDetails = ob.GetCompanyDetails(cellValue);

            companyName.Content = companyDetails[1];
            companyId.Content = "Company Id: "+companyDetails[0];
            companyAddress1.Content = companyDetails[2];
            companyAddress2.Content = companyDetails[3];
            companyAddress3.Content = companyDetails[4];
        }

        private void ShowTable()
        {
            ob.ShowCompanyInvoices(cellValue).Fill(dataTable);
            dataGrid2.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding { Source = dataTable });
            (dataGrid2.ItemsSource as DataView).Sort = "InvoiceId DESC";

        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid2.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            string statusPaid = dataRow.Row.ItemArray[5].ToString();

            if (string.Equals(statusPaid, "N"))
            {
                MessageBoxResult result;
                result = MessageBox.Show("Paid?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ob.PayInvoice(cellValue);
                    ClearDataGrid();
                    ShowTable();
                }

                else
                { //If no
                }
            }
        }

        private void ClearDataGrid()
        {

            dataGrid2.ItemsSource = null;
            dataGrid2.Items.Clear();
            dataGrid2.Items.Refresh();
            dataTable.Clear();
        }
    }
}
