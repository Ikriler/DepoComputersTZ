using CsvHelper.Configuration.Attributes;
using CsvHelper;
using DepoComputersTZ.DataSet1TableAdapters;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static DepoComputersTZ.DataSet1;

namespace DepoComputersTZ.Services
{
    public class OrgaizationsService
    {
        public void InsertOrganization(string name, string inn, string uraddress, string factaddress)
        {
            organizationsTableAdapter organizationsTableAdapter = new organizationsTableAdapter();
            organizationsTableAdapter.InsertOrganization(name, inn, uraddress, factaddress);
        }

        public organizationsDataTable GetOrganizationsDataTable()
        {
            organizationsTableAdapter organizationsTableAdapter = new organizationsTableAdapter();
            organizationsDataTable organizationsRows = new organizationsDataTable();
            organizationsTableAdapter.Fill(organizationsRows);
            return organizationsRows;
        }

        class OrganizationsLoadData
        {
            [Name("name")]
            public string Name { get; set; }
            [Name("inn")]
            public string Inn { get; set; }
            [Name("uraddress")]
            public string Uraddress { get; set; }
            [Name("factaddress")]
            public string Factaddress { get; set; }
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
                            IEnumerable organizations = csvReader.GetRecords<OrganizationsLoadData>();
                            foreach (OrganizationsLoadData organization in organizations)
                            {
                                InsertOrganization(organization.Name, organization.Inn, organization.Uraddress, organization.Factaddress);
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
                    foreach (organizationsRow organization in GetOrganizationsDataTable())
                    {
                        csv.WriteRecord<OrganizationsLoadData>(new OrganizationsLoadData() { Name = organization.name, Inn = organization.inn, Uraddress = organization.uraddress, Factaddress = organization.factaddress });
                        csv.NextRecord();
                    }
                }
            }
        }
    }
}
