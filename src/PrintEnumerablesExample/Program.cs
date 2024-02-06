using QuantumForge.Services;
using QuantumForge.Settings;
using PrintEnumerablesExample;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

var accounts = InvoiceDataSource.GetAccounts();

var settings = new QuantumForgePageSettings
{
    Background = "#739072"
};

settings.Header.Value = "Test company header";
settings.Header.Settings = new()
{
    Background = "#3A4D39",
    TextStyle = TextStyle.Default.FontColor("#ECE3CE")
                                  .FontSize(18)
};
settings.Header.Height = 50;

settings.TableHeader = new()
{
    Background = "#4F6F52",
    TextStyle = TextStyle.Default.FontColor("#ECE3CE")
                                 .FontSize(14)
};

settings.TableContent.Background = "#739072";
settings.TableContent.TextStyle = TextStyle.Default.FontColor("#ECE3CE");

settings.TableFooter.Background = "#739072";
settings.TableFooter.TextStyle = TextStyle.Default.FontColor("#ECE3CE");

settings.Footer.Value = "Test company footer";
settings.Footer.Settings = new()
{
    Background = "#3A4D39",
    TextStyle = TextStyle.Default.FontColor("#ECE3CE")
                                 .FontSize(10)
};


QuantumForgeService.GeneratePdfAndShow<AccountModel>(accounts, settings);