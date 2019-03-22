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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LCE_Management_System.Resources;


namespace LCE_Management_System
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        MySQL ob = new MySQL();
        public Home()
        {
            InitializeComponent();
            SumOfInvoicePriceColumn();
            CountCurrentMonthInvoice();
            CountCurrentMonthBusiness();
        }

        public void CountCurrentMonthBusiness()
        {
            string business = ob.ReturnBusiness();
            if (String.IsNullOrEmpty(business))
            {
                business = "0";
            }
            DisplayBusiness.Text = "RM "+business;
        }

        public void CountCurrentMonthInvoice()
        {
            DisplayCountOfInvoice.Text = ob.ReturnCountOfInvoice();

        }


        public void SumOfInvoicePriceColumn()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {

                    Title = "Unpaid Invoice",
                    Values = new ChartValues<double> { ob.ReturnSum()},
                    DataLabels=false,
                    
                    
                }
};

            /*
            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });
            
            //also adding values updates and animates the chart automatically
            SeriesCollection[1].Values.Add(48d);
            */

            //Formatter = value => value.ToString("N");
            Labels = new[] { "Total Amount of Unpaid Invoice"};


            DataContext = this;
        }
    

public SeriesCollection SeriesCollection { get; set; }
public string[] Labels { get; set; }
public Func<double, string> Formatter { get; set; }

    }
}
