using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MoneyLoverDesktop
{
    public class BudgetsLoader : BaseEntityLoader
    {
        public override string entityName
        {
            get { return "budgets"; }
        }

        public override void RowIteration(Dictionary<string, string> columnsAndValues)
        {
            db.budgets.Add(getBudgetFromColumnsAndValues(columnsAndValues));
        }

        private budgets getBudgetFromColumnsAndValues(Dictionary<string, string> columnsAndValues)
        {

            budgets budget = new budgets();

            budget.id = long.Parse(columnsAndValues["id"]);
            budget.amount = decimal.Parse(columnsAndValues["amount"], System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            budget.start_date = DateTime.Parse(columnsAndValues["start_date"]);
            budget.end_date = DateTime.Parse(columnsAndValues["end_date"]);
            budget.user_id = int.Parse(columnsAndValues["user_id"]);
            budget.group_id = int.Parse(columnsAndValues["group_id"]);
            budget.cat_id = int.Parse(columnsAndValues["cat_id"]);
            budget.time_mode = int.Parse(columnsAndValues["time_mode"]);
            budget.repeat_status = int.Parse(columnsAndValues["repeat_status"]);
            budget.warning_percent = double.Parse(columnsAndValues["warning_percent"]);
            budget.notification_status = int.Parse(columnsAndValues["notification_status"]);

            return budget;

        }

        public override void CleanDataBase()
        {
            db.budgets.Clear();
        }

    }
}
