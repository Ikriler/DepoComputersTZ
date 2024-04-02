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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DepoComputersTZ
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoOrganizationsWindowButton_Click(object sender, RoutedEventArgs e)
        {
            OrganizationsWindow organizationsWindow = new OrganizationsWindow();
            organizationsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            organizationsWindow.Show();
            this.Close();
        }

        private void GoWorkersWindowButton_Click(object sender, RoutedEventArgs e)
        {
            WorkersWindow workersWindow = new WorkersWindow();
            workersWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            workersWindow.Show();
            this.Close();
        }
    }
}
