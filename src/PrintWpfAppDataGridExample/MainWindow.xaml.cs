using MultiPrint.Services;
using System.Windows;
using System.Windows.Controls;

namespace PrintWpfAppDataGridExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var accounts = InvoiceDataSource.GetAccounts();
            dataGrid.ItemsSource = accounts;
        }

        private void btnGeneratePdf_Click(object sender, RoutedEventArgs e)
        {
            MultiPrintService.GeneratePdfAndShow<AccountModel>(dataGrid.ItemsSource);
        }

        private void btnGenerateXbs_Click(object sender, RoutedEventArgs e)
        {
            MultiPrintService.GeneratePdfAndShow<AccountModel>(dataGrid.ItemsSource);
        }
    }
}