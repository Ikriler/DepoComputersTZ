using CsvHelper;
using CsvHelper.Configuration.Attributes;
using DepoComputersTZ.DataSet1TableAdapters;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static DepoComputersTZ.DataSet1;

namespace DepoComputersTZ.Services
{
    public class WorkerService
    {
        public void InsertWorker(string firstname, string lastname, string patronymic, DateTime? birthday, string seriapass, string numberpass)
        {
            workersTableAdapter workersTableAdapter = new workersTableAdapter();
            workersTableAdapter.InsertWorker(firstname, lastname, patronymic, birthday, seriapass, numberpass);
        }

        public workersDataTable GetWorkersDataTable()
        {
            workersTableAdapter workersTableAdapter = new workersTableAdapter();
            workersDataTable workersRows = new workersDataTable();
            workersTableAdapter.Fill(workersRows);
            return workersRows;
        }

        class WorkersLoadData
        {
            [Name("firstname")]
            public string FirstName { get; set; }
            [Name("lastname")]
            public string LastName { get; set; }
            [Name("patronymic")]
            public string Patronymic { get; set; }
            [Name("birthday")]
            public DateTime BirthDay { get; set; }
            [Name("seriapass")]
            public string Seriapass { get; set; }
            [Name("numberpass")]
            public string Numberpass { get; set; }
        }

        public void Import()
        {
            OpenFileDialog csvFileDialog = new OpenFileDialog();
            csvFileDialog.Filter = "CSV|*.csv";
            if (csvFileDialog.ShowDialog() == true)
            {
                string csvPath = csvFileDialog.FileName;
                try
                {
                    using (StreamReader streamReader = new StreamReader(csvPath))
                    {
                        using (CsvReader csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture))
                        {
                            IEnumerable workers = csvReader.GetRecords<WorkersLoadData>();
                            foreach (WorkersLoadData worker in workers)
                            {
                                InsertWorker(worker.FirstName, worker.LastName, worker.Patronymic, worker.BirthDay, worker.Seriapass, worker.Numberpass);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        public void Export()
        {
            SaveFileDialog csvFileDialog = new SaveFileDialog();
            csvFileDialog.Filter = "CSV|*.csv";
            if (csvFileDialog.ShowDialog() == true)
            {
                string csvPath = csvFileDialog.FileName;
                using (var writer = new StreamWriter(csvPath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (workersRow worker in GetWorkersDataTable())
                    {
                        csv.WriteRecord<WorkersLoadData>(new WorkersLoadData() { FirstName = worker.firstname, LastName = worker.lastname, Patronymic = worker.patronymic, BirthDay = worker.birthday, Seriapass = worker.seriapass, Numberpass = worker.numberpass });
                        csv.NextRecord();
                    }
                }
            }
        }
    }
}
