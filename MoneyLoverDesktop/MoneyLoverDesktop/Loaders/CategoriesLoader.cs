using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace MoneyLoverDesktop
{
    public class CategoriesLoader : BaseEntityLoader
    {
        public override string entityName
        {
            get { return "categories"; }
        }

        public override void RowIteration(Dictionary<string, string> columnsAndValues)
        {
            db.categories.Add(getCategoryFromColumnsAndValues(columnsAndValues));
        }

        private categories getCategoryFromColumnsAndValues(Dictionary<string, string> columnsAndValues)
        {

            categories category = new categories();

            category.id = long.Parse(columnsAndValues["id"]);
            category.name = columnsAndValues["name"];
            category.type = int.Parse(columnsAndValues["type"]);
            category.user_id = int.Parse(columnsAndValues["user_id"]);
            category.group_id = int.Parse(columnsAndValues["group_id"]);
            category.icon = columnsAndValues["icon"];

            return category;

        }

        public override void CleanDataBase()
        {
            db.categories.Clear();
        }
    }
}
