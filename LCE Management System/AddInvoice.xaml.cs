using LCE_Management_System.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace LCE_Management_System
{
    /// <summary>
    /// Interaction logic for AddInvoice.xaml
    /// </summary>
    public partial class AddInvoice : Window
    {
        DataSet ds = new DataSet();
        SQL ob = new SQL();

        public AddInvoice()
        {
            InitializeComponent();
            PopulateComboBoxData();
           
        }

        public WindowStartupLocation StartupLocation { get; internal set; }

        public void PopulateComboBoxData()
        {
            ob.ShowAllCompany().Fill(ds,"Company");
            comboBox.ItemsSource = ds.Tables[0].DefaultView;
            comboBox.DisplayMemberPath = ds.Tables[0].Columns["CompanyName"].ToString();
            comboBox.SelectedValuePath = ds.Tables[0].Columns["CompanyId"].ToString();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Selected CompanyName=" + comboBox.Text + " and CompanyId=" + comboBox.SelectedValue.ToString());
            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.ToString());

            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.ToString());

            }
        }
    }
}
