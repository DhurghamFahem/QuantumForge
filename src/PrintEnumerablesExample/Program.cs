using MultiPrint.Documents;
using MultiPrint.Settings;
using PrintEnumerablesExample;
using QuestPDF.Fluent;

var accounts = InvoiceDocumentDataSource.GetAccounts();

var settings = new MultiPrintPageSettings
{
    RightRoLeft = true,
    Header = new HeaderSettings
    {
        Value = "Test Company"
    },
    TableFooter = new CellSettings
    {
        Background = "5d5555"
    }
};

var accountsDocument = new EnumerableDocument<AccountModel>(accounts, settings);
accountsDocument.GeneratePdf();