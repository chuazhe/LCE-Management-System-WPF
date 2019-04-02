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

namespace LCE_Management_System
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : UserControl
    {
        SQL ob = new SQL();
        DataTable dataTable = new DataTable();
        private int index = 0;


        public Invoice()
        {
            InitializeComponent();
            Refresh(); 
        }

        public void CheckInvoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    ob.ShowAllInvoice().Fill(dataTable);
                    break;
                case 1:
                    ob.ShowPaidInvoice().Fill(dataTable);
                    break;
                case 2:
                    ob.ShowUnpaidInvoice().Fill(dataTable);
                    break;
                case 3:
                    ob.ShowAllInvoiceWithDate(FromDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd"), ToDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd")).Fill(dataTable);
                    break;
                case 4:
                    ob.ShowPaidInvoiceWithDate(FromDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd"), ToDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd")).Fill(dataTable);
                    break;
                case 5:
                    ob.ShowUnpaidInvoiceWithDate(FromDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd"), ToDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd")).Fill(dataTable);
                    break;
            }
            dataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding { Source = dataTable });
        }

        private void comboBoxShow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            index = comboBoxShow.SelectedIndex;
            if (dataGrid != null)
            {
                ClearDataGrid();

                if (FromDate.SelectedDate != null && ToDate.SelectedDate != null)
                {
                    index += 3;
                }
                CheckInvoice(index);
            }

        }

        //SELECT * FROM Orders WHERE ORDERDATE='1996-07-08';
        //SELECT * FROM Orders WHERE (ORDERDATE between'1996-07-08' AND '1996-07-10');

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid.SelectedItem;
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
                    CheckInvoice(index);
                }

                else
                { //If no
                }
            }
        }

        private void FromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ToDate.SelectedDate != null)
            {
                index = comboBoxShow.SelectedIndex + 3;
                ClearDataGrid();
                CheckInvoice(index);
            }

        }

        private void ToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FromDate.SelectedDate != null)
            {
                index = comboBoxShow.SelectedIndex + 3;
                ClearDataGrid();
                CheckInvoice(index);
            }

        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            if(searchText.Text !=null)
            {
                DataView dv = dataTable.DefaultView;
                dv.RowFilter = string.Format("NameCompany like '%{0}%'", searchText.Text.Trim());
                dataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding { Source = dv.ToTable() });
            }


        }

        private void ClearDataGrid()
        {
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.Items.Refresh();
            dataTable.Clear();
        }

        private void Refresh()
        {
            ob.ShowAllInvoice().Fill(dataTable);
            dataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding { Source = dataTable });
            (dataGrid.ItemsSource as DataView).Sort = "InvoiceId DESC";
            FromDate.SelectedDate = null;
            ToDate.SelectedDate = null;
            comboBoxShow.SelectedIndex=0;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dataTable.DefaultView.RowFilter = string.Empty;
            ClearDataGrid();
            Refresh();
            searchText.Text = string.Empty;
        }

        private void btnAddInvoice_Click(object sender, RoutedEventArgs e)
        {
            AddInvoice wnd = new AddInvoice();
            wnd.Owner = Window.GetWindow(this);
            wnd.StartupLocation = WindowStartupLocation.CenterOwner;
            wnd.Show();

        }
    }
}






