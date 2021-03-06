﻿using System;
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

        public MoneyLoverPcEntities db
        {
            get
            {
                return (MoneyLoverPcEntities)App.Current.Properties["db"];
            }
        }

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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            transactions newTrans = new transactions();
            newTrans.amount = decimal.Parse(tbxAmount.Text);
            newTrans.name = tbxDescription.Text;
            newTrans.displayed_date = dtRecord.SelectedDate.Value;
            newTrans.type = 2;
            newTrans.cat_id = db.categories.Find(c => c.name.Equals(tbxCategory.Text)).id;

            db.transactions.Add(newTrans);
            MessageBox.Show("New transaction Added!");
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelectedDate();
            LoadSourceData();
            this.Title = String.Format("{0} transactions loaded!", db.transactions.Count.ToString());
        }
    }
}
