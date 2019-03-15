using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LCE_Management_System.Resources;

namespace LCE_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string VERSION = "1.02";
        Home homeUserControl = new Home();
        Invoice invoiceUserControl = new Invoice();
        Company companyUserControl = new Company();
        SQL ob = new SQL();


        public MainWindow()
        {
            InitializeComponent();
            CheckDb();
            frameDisplay.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            frameDisplay.Navigate(homeUserControl);
            
        }

        private void CheckDb()
        {
            if (ob.CheckDb())
            {
                dbStatus.Foreground = Brushes.LightGreen;
            }

        }

        private void Home_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frameDisplay.Navigate(homeUserControl);
        }

        private void Info_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Version= "+ VERSION+"\n"+"Made by Chua Wei Zhe", "Info");
        }

        private void Invoice_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frameDisplay.Navigate(invoiceUserControl);
        }

        private void Company_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            frameDisplay.Navigate(companyUserControl);
        }
    }
    
}
