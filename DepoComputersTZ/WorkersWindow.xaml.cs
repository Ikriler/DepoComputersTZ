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
    public partial class WorkersWindow : Window
    {
        private WorkerService workerService;
        public WorkersWindow()
        {
            InitializeComponent();
            InitServices();
            InitWorkersList();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void InitServices()
        {
            workerService = new WorkerService();
        }

        private void InitWorkersList()
        {
            this.WorkersList.ItemsSource = workerService.GetWorkersDataTable();
        }

        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            string firstname = firstnameTextBox.Text.Trim();
            string lastname = lastnameTextBox.Text.Trim();
            string patronymic = patronymicTextBox.Text.Trim();
            DateTime? birthday = birthdayDatePicker.SelectedDate;
            string seriapass = seriapassTextBox.Text.Trim();
            string numberpass = numberpassTextBox.Text.Trim();

            try
            {
                workerService.InsertWorker(firstname, lastname, patronymic, birthday, seriapass, numberpass);
                MessageBox.Show("Сотрудник добавлен");
                RefreshFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshFields()
        { 
            firstnameTextBox.Text = "";
            lastnameTextBox.Text = "";
            patronymicTextBox.Text = "";
            seriapassTextBox.Text = "";
            numberpassTextBox.Text = "";

            InitWorkersList();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                workerService.Import();
                InitWorkersList();
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
                workerService.Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
