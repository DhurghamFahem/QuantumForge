using MultiPrint.Documents;
using MultiPrint.Settings;
using PrintEnumerablesExample;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

var accounts = InvoiceDocumentDataSource.GetAccounts();

var settings = new MultiPrintPageSettings
{
    RightRoLeft = true,
    Header = new HeaderSettings
    {
        Value = "علاوي الغالي"
    }
};

var accountsDocument = new EnumerableDocument<AccountModel>(accounts, settings);
using var stream = new MemoryStream();
accountsDocument.ShowInPreviewer();