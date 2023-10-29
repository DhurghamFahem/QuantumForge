
using MultiPrint;
using MultiPrint.Documents;
using PrintEnumerablesExample;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

var accounts = InvoiceDocumentDataSource.GetAccounts();

var accountsDocument = new EnumerableDocument<AccountModel>(accounts);
accountsDocument.GeneratePdf();