using DepoComputersTZ.Services;
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
using System.Windows.Shapes;

namespace DepoComputersTZ
{
    public partial class OrganizationsWindow : Window
    {
        private OrgaizationsService orgaizationsService;
        public OrganizationsWindow()
        {
            InitializeComponent();
            InitServices();
            InitOrganizationsList();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void InitServices()
        {
            orgaizationsService = new OrgaizationsService();
        }

        private void InitOrganizationsList()
        {
            this.OrganizationsList.ItemsSource = orgaizationsService.GetOrganizationsDataTable();
        }

        private void AddOrganization_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string inn = innTextBox.Text.Trim();
            string uraddress = uraddressTextBox.Text.Trim();
            string factaddress = factaddressTextBox.Text.Trim();

            try
            {
                orgaizationsService.InsertOrganization(name, inn, uraddress, factaddress);
                MessageBox.Show("Организация добавлена");
                RefreshFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshFields()
        {
            nameTextBox.Text = "";
            innTextBox.Text = "";
            uraddressTextBox.Text = "";
            factaddressTextBox.Text = "";

            InitOrganizationsList();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orgaizationsService.Import();
                InitOrganizationsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orgaizationsService.Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
