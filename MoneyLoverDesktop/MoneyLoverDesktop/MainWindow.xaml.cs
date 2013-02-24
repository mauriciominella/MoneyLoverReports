using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Xml.XPath;
using MoneyLoverDesktop.Excel;

namespace MoneyLoverDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties

        public DateTime selectedBeginDate { get; set; }
        public DateTime selectedEndDate { get; set; }

        #endregion


        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            App.Current.Properties.Add("db", new MoneyLoverPcEntities());
        }

        #endregion

        private static void LoadSourceData()
        {
            CategoriesLoader oCategoryLoader = new CategoriesLoader();
            TransactionsLoader oTransLoader = new TransactionsLoader();
            BudgetsLoader oBudLoader = new BudgetsLoader();

            oTransLoader.CleanDataBase();
            oCategoryLoader.CleanDataBase();
            oBudLoader.CleanDataBase();

            oCategoryLoader.LoadData();
            oTransLoader.LoadData();
            oBudLoader.LoadData();
        }

        private void GenerateAndOpenXLSReport()
        {
            ExcelReport report = new ExcelReport(selectedBeginDate, selectedEndDate);
            string fullName = report.Generate();
            System.Diagnostics.Process.Start(fullName);
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Processing...";

            UpdateSelectedDate();
            LoadSourceData();
            GenerateAndOpenXLSReport();

            this.Title = "Done!";
        }

        private void beginDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectedDate();
        }

        private void endDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectedDate();
        }

        private void UpdateSelectedDate()
        {
            if(beginDate.SelectedDate.HasValue)
                selectedBeginDate = beginDate.SelectedDate.Value;

            if(endDate.SelectedDate.HasValue)
                selectedEndDate = endDate.SelectedDate.Value;
        }

        private void cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
