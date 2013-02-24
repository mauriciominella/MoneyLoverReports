using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace MoneyLoverDesktop.Excel
{
    public class ExcelReport
    {
        public MoneyLoverPcEntities db
        {
            get { return (MoneyLoverPcEntities)App.Current.Properties["db"]; }
        }

        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        private const string templatePath = @"D:\Pessoal\Finanças\Controle de Gastos\MoneyLoverPC\MoneyLoverDesktop\MoneyLoverDesktop\Excel\template\reportTemplate.xlsx";
        private const string outputPath = @"D:\Pessoal\Finanças\Controle de Gastos\MoneyLoverPC\MoneyLoverDesktop\MoneyLoverDesktop\Excel";


        public ExcelReport(DateTime? _beginDate, DateTime? _endDate)
        {
            this.BeginDate = _beginDate;
            this.EndDate = _endDate;
        }

        private FileInfo CreateNewFileByTemplate()
        {
            string fileName = CreateNewFileName();
            string outputFileFullPath = outputPath + @"\" + fileName;

            System.IO.File.Copy(templatePath, outputFileFullPath);

            FileInfo newFile = new FileInfo(outputFileFullPath);
            return newFile;
        }

        private string CreateNewFileName()
        {
            DateTime currentDate = DateTime.Now;
            string fileNameWithoutExtension = currentDate.ToString("dd_mm_yyyy-hh_mm_ss");

            string fileName = fileNameWithoutExtension + ".xlsx";
            return fileName;
        }

        public string Generate()
        {
            FileInfo newFile = CreateNewFileByTemplate();

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                WriteWorksheetDespesas(package);
                WriteWorksheetDespesas_por_categoria(package);
                WriteWorksheetReceitas(package);
                WriteWorksheetFechamentoMensal(package);

                // save our new workbook and we are done!
                package.Save();

            }

            return newFile.FullName;
        }


        private void WriteWorksheetDespesas(ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Despesas"];

            int rowIndex = 2;

            foreach (transactions item in getCurrentMonthExpenses())
            {
                worksheet.Cells[rowIndex, 1].Value = item.created_date.ToString("dd/MM/yyyy");
                worksheet.Cells[rowIndex, 2].Value = db.categories.Find(x => x.id == item.cat_id).name;
                worksheet.Cells[rowIndex, 3].Value = item.name;
                worksheet.Cells[rowIndex, 4].Value = item.amount;

                rowIndex++;
            }
        }

        private void WriteWorksheetDespesas_por_categoria(ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Despesas por categoria"];

            int rowIndex = 2;

            foreach (CategoryAndValue item in getCurrentMonthExpensesByCategory())
            {
                worksheet.Cells[rowIndex, 1].Value = item.name;
                worksheet.Cells[rowIndex, 2].Value = item.amount;

                rowIndex++;
            }
            
        }

        private void WriteWorksheetReceitas(ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Receitas"];

            int rowIndex = 2;

            foreach (transactions item in getCurrentMonthReceipts())
            {
                worksheet.Cells[rowIndex, 1].Value = item.created_date.ToString("dd/MM/yyyy");
                worksheet.Cells[rowIndex, 2].Value = db.categories.Find(x => x.id == item.cat_id).name;
                worksheet.Cells[rowIndex, 3].Value = item.name;
                worksheet.Cells[rowIndex, 4].Value = item.amount;

                rowIndex++;
            }
        }

        private void WriteWorksheetFechamentoMensal(ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Fechamento Mensal"];

            int rowIndex = 2;

            foreach (transactions item in getCurrentPeriodReceiptsByMonth())
            {
                worksheet.Cells[rowIndex, 1].Value = item.displayed_date;
                worksheet.Cells[rowIndex, 2].Value = item.amount;

                rowIndex++;
            }

            rowIndex = 2;

            foreach (transactions item in getCurrentPeriodExpensesByMonth())
            {
                worksheet.Cells[rowIndex, 3].Value = item.amount;

                rowIndex++;
            }
        }


        private List<transactions> getCurrentMonthExpenses()
        {    
            List<transactions> currentMonthTransactions = (from trans in db.transactions
                                                           where trans.displayed_date >= BeginDate && trans.displayed_date <= EndDate && trans.type == 2
                                                           select trans).ToList<transactions>();

            return currentMonthTransactions;
        }

        private List<transactions> getCurrentMonthReceipts()
        {
            List<transactions> currentMonthTransactions = (from trans in db.transactions
                                                           where trans.displayed_date >= BeginDate && trans.displayed_date <= EndDate && trans.type == 1
                                                           select trans).ToList<transactions>();

            return currentMonthTransactions;
        }


        private List<transactions> getCurrentPeriodExpensesByMonth()
        {
            List<transactions> currentMonthExpenses = getCurrentMonthExpenses();

            List<transactions> currentMonthExpensesByCategory = new List<transactions>();

            var grouped = from p in currentMonthExpenses
                          group p by new { month = p.displayed_date.Month, year = p.displayed_date.Year } into d
                          select new { month = d.Key.month, year = d.Key.year, dt = string.Format("{0}/{1}", d.Key.month, d.Key.year), amount = d.Sum(a => a.amount) };


            foreach (var item in grouped)
            {
                transactions groupTransaction = new transactions();
                groupTransaction.amount = item.amount;
                groupTransaction.displayed_date = new DateTime(item.year, item.month, 1);
                currentMonthExpensesByCategory.Add(groupTransaction);
            }


            return currentMonthExpensesByCategory;
        }

        private List<transactions> getCurrentPeriodReceiptsByMonth()
        {
            List<transactions> currentMonthExpenses = getCurrentMonthReceipts();

            List<transactions> currentMonthExpensesByCategory = new List<transactions>();

            var grouped = from p in currentMonthExpenses
                          group p by new { month = p.displayed_date.Month, year = p.displayed_date.Year } into d
                          select new { month = d.Key.month, year = d.Key.year, dt = string.Format("{0}/{1}", d.Key.month, d.Key.year), amount = d.Sum(a => a.amount) };


            foreach (var item in grouped)
            {
                transactions groupTransaction = new transactions();
                groupTransaction.amount = item.amount;
                groupTransaction.displayed_date = new DateTime(item.year, item.month, 1);
                currentMonthExpensesByCategory.Add(groupTransaction);
            }


            return currentMonthExpensesByCategory;
        }


        private List<CategoryAndValue> getCurrentMonthExpensesByCategory()
        {
            List<transactions> currentMonthExpenses = getCurrentMonthExpenses();

            List<CategoryAndValue> currentMonthExpensesByCategory = new List<CategoryAndValue>();

            var query = (from trans in currentMonthExpenses
                         group trans by new { trans.cat_id, trans.categories.name } into cat
                         select new
                         {
                             id = cat.Key.cat_id,
                             name = db.categories.Find(x => x.id == cat.Key.cat_id).name,
                             amount = cat.Sum(c => c.amount)
                         }).OrderBy(x => x.name);

            foreach (var item in query)
            {
                CategoryAndValue expenseByCategory = new CategoryAndValue();
                expenseByCategory.id = item.id;
                expenseByCategory.name = item.name;
                expenseByCategory.amount = item.amount;
                currentMonthExpensesByCategory.Add(expenseByCategory);
            }


            return currentMonthExpensesByCategory;

        }

        private List<budgets> getCurrentMonthBudgets()
        {
            List<budgets> currentMonthBudgets = (from bud in db.budgets
                                                 where bud.start_date >= BeginDate && bud.start_date <= EndDate
                                                           select bud).ToList<budgets>();

            return currentMonthBudgets;
        }

        private List<BudgetValue> getCurrentMonthExpensesWithBudget()
        {
            List<BudgetValue> currentMonthExpensesWithBudget = new List<BudgetValue>();

            List<CategoryAndValue> currentMonthExpensesByCategory = getCurrentMonthExpensesByCategory();
            List<budgets> currentMonthBudgets = getCurrentMonthBudgets();

            var query = (from cat in currentMonthExpensesByCategory
                         join bud in currentMonthBudgets on cat.id equals bud.cat_id
                         select new { cat.id, cat.name, cat.amount, budamount = bud.amount }
                         );

            foreach (var item in query)
            {
                BudgetValue expenseByCategory = new BudgetValue();
                expenseByCategory.id = item.id;
                expenseByCategory.name = item.name;
                expenseByCategory.amount = item.amount;
                expenseByCategory.budgetAmount = decimal.Parse(item.budamount.ToString());
                currentMonthExpensesWithBudget.Add(expenseByCategory);
            }


            return currentMonthExpensesWithBudget;

        }

        public DateTime FirstDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        
    }

    public class CategoryAndValue
    {
        public long id { get; set; }
        public string name { get; set; }
        public decimal amount { get; set; }
        public decimal budgetAmount { get; set; }
    }

    public class BudgetValue
    {
        public long id { get; set; }
        public string name { get; set; }
        public decimal amount { get; set; }
        public decimal budgetAmount { get; set; }

        public decimal usedPercent {
            get
            {
                return amount / budgetAmount;
            }
        }

        public decimal percentOfMonth {
            get
            {
                return DateTime.Now.Day / Convert.ToDecimal(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            }
        }

        public decimal remainingAmount
        {
            get
            {
                return budgetAmount - amount;
            }
        }

    }
}
