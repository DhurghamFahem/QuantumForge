using MultiPrint.Services;
using System.Windows;

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

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            MultiPrintService.Print<AccountModel>(dataGrid.ItemsSource);
        }

        private void btnGeneratePdf_Click(object sender, RoutedEventArgs e)
        {
            MultiPrintService.GeneratePdf<AccountModel>(dataGrid.ItemsSource);
        }

        private void btnGenerateXbs_Click(object sender, RoutedEventArgs e)
        {
            MultiPrintService.GenerateXps<AccountModel>(dataGrid.ItemsSource);
        }
    }
}