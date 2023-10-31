using MultiPrint.Services;
using MultiPrint.Settings;
using PrintEnumerablesExample;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

var accounts = InvoiceDataSource.GetAccounts();

var settings = new MultiPrintPageSettings();

settings.Background = "#739072";

settings.Header.Value = "Test company header";
settings.Header.Settings = new();
settings.Header.Settings.Background = "#3A4D39";
settings.Header.Settings.TextStyle = TextStyle.Default.FontColor("#ECE3CE")
                                                      .FontSize(18);
settings.Header.Height = 50;

settings.TableHeader = new();
settings.TableHeader.Background = "#4F6F52";
settings.TableHeader.TextStyle = TextStyle.Default.FontColor("#ECE3CE")
                                                  .FontSize(14);

settings.TableContent.Background = "#739072";
settings.TableContent.TextStyle = TextStyle.Default.FontColor("#ECE3CE");

settings.TableFooter.Background = "#739072";
settings.TableFooter.TextStyle = TextStyle.Default.FontColor("#ECE3CE");

settings.Footer.Value = "Test company footer";
settings.Footer.Settings = new();
settings.Footer.Settings.Background = "#3A4D39";
settings.Footer.Settings.TextStyle = TextStyle.Default.FontColor("#ECE3CE")
                                                      .FontSize(10);
MultiPrintService.GeneratePdf(accounts, settings);