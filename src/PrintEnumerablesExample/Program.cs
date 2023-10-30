using MultiPrint.Documents;
using MultiPrint.Settings;
using PrintEnumerablesExample;
using QuestPDF.Previewer;

var accounts = InvoiceDocumentDataSource.GetAccounts();

var settings = new MultiPrintPageSettings
{
    RightRoLeft = true,
    Header = new HeaderSettings
    {
        Value = "شركة اليقين للبيع بالتجزئة"
    },
    TableFooter = new CellSettings
    {
        Background = "5d5555"
    }
};

var accountsDocument = new EnumerableDocument<AccountModel>(accounts, settings);
using var stream = new MemoryStream();
accountsDocument.ShowInPreviewer();