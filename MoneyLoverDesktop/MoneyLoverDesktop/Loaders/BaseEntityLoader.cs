using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.IO;

namespace MoneyLoverDesktop
{
    public abstract class BaseEntityLoader
    {
        #region Constructors

        public BaseEntityLoader()
        {
    
        }

        #endregion

        #region Properties

        public MoneyLoverPcEntities db
        {
            get { return (MoneyLoverPcEntities)App.Current.Properties["db"]; }
        }

        public XPathDocument doc { get; set; }

        public abstract string entityName { get; }

        private string DataFileDirectory = @"D:\DROPBOX\Dropbox\Apps\Money Lover\";

        #endregion

        private string GetFullPathOfLastDataFile()
        {
            string fullPathOfLastFile = string.Empty;

            VerifyIfDirectoryExists();

            DirectoryInfo oDirInfo = new System.IO.DirectoryInfo(DataFileDirectory);

            FileInfo[] files = oDirInfo.GetFiles("*.money");

            DateTime currentMaxDate = DateTime.MinValue;
            FileInfo lastFile = null;

            foreach (FileInfo item in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(item.FullName);

                DateTime dateOfFile;

                if (DateTime.TryParse(fileName, out dateOfFile))
                {
                    if (dateOfFile > currentMaxDate)
                    {
                        currentMaxDate = dateOfFile;
                        lastFile = item;
                    }

                }
            }

           if(lastFile != null)
               fullPathOfLastFile = lastFile.FullName;

           return fullPathOfLastFile;
        }

        private void VerifyIfDirectoryExists()
        {
            if (!Directory.Exists(DataFileDirectory))
                throw new Exception(String.Format("{0} not exists!", DataFileDirectory));
        }

        public virtual void LoadData()
        {
            XPathDocument document;

            document = new XPathDocument(GetFullPathOfLastDataFile());
            XPathNavigator rowNavigator = document.CreateNavigator();

            XPathExpression expression = rowNavigator.Compile(String.Format("/export-database/table[@name='{0}']/row", this.entityName));
            XPathNodeIterator rowIterator = rowNavigator.Select(expression);

            try
            {
                while (rowIterator.MoveNext())
                {
                    Dictionary<string, string> columnsAndValues = new Dictionary<string, string>();

                    XPathNodeIterator columnsIterator = rowIterator.Current.Clone().SelectChildren("col", string.Empty);

                    while (columnsIterator.MoveNext())
                    {
                        string columnName = columnsIterator.Current.GetAttribute("name", string.Empty);
                        string columnValue = columnsIterator.Current.Value;

                        columnsAndValues.Add(columnName, columnValue);

                    }

                    this.RowIteration(columnsAndValues);
                }
            }
            catch (Exception)
            {

            }
        }

        public abstract void RowIteration(Dictionary<string, string> columnsAndValues);

        public abstract void CleanDataBase();
    }
}
