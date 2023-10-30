using MultiPrint.Documents;
using MultiPrint.Settings;
using PrintEnumerablesExample;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

var accounts = InvoiceDocumentDataSource.GetAccounts();

var settings = new MultiPrintPageSettings
{
    Header = new HeaderSettings
    {
        Value = "علاوي الغالي"
    }
};

var accountsDocument = new EnumerableDocument<AccountModel>(accounts, settings);
using var stream = new MemoryStream();
accountsDocument.GeneratePdf(stream);
stream.Seek(0, SeekOrigin.Begin);
accountsDocument.ShowInPreviewer();