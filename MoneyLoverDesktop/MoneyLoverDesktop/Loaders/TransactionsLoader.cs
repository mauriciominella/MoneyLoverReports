using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MoneyLoverDesktop
{
    public class TransactionsLoader : BaseEntityLoader
    {
        public override string entityName
        {
            get { return "transactions"; }
        }

        public override void RowIteration(Dictionary<string, string> columnsAndValues)
        {
            db.transactions.Add(getTransactionFromColumnsAndValues(columnsAndValues));
        }

        private transactions getTransactionFromColumnsAndValues(Dictionary<string, string> columnsAndValues)
        {
            transactions transaction = new transactions();

            transaction.id = long.Parse(columnsAndValues["id"]);
            transaction.name = columnsAndValues["name"];
            transaction.amount = decimal.Parse(columnsAndValues["amount"], System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            transaction.type = int.Parse(columnsAndValues["type"]);
            transaction.created_date = DateTime.Parse(columnsAndValues["created_date"]);
            transaction.displayed_date = DateTime.Parse(columnsAndValues["displayed_date"]);
            transaction.cat_id = int.Parse(columnsAndValues["cat_id"]);
            transaction.with_person = columnsAndValues["with_person"];
            //transaction.remind_date = DateTime.Parse(columnsAndValues["remind_date"]);
            transaction.remind_num = int.Parse(columnsAndValues["remind_num"]);
            transaction.note = columnsAndValues["note"];
            transaction.status = int.Parse(columnsAndValues["status"]);
            transaction.user_id = int.Parse(columnsAndValues["user_id"]);

            return transaction;

        }

        public override void CleanDataBase()
        {
            db.transactions.Clear();

        } 
    }
}
