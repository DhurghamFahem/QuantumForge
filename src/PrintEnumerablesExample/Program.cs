using MultiPrint.Services;
using PrintEnumerablesExample;

var accounts = InvoiceDataSource.GetAccounts();
MultiPrintService.GeneratePdf(accounts);