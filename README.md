# MultiPrint

MultiPrint is a versatile C# utility for printing enumerables and data grids directly. It allows you to easily visualize and work with tabular data in your applications.

## Features

- **Print Enumerables**: Effortlessly print collections and enumerables.

- **Print DataGrids**: Effortlessly print DataGrids directly.

## Installation

To use MultiPrint in your C# application, you can choose one of the following methods:

### NuGet Package

You can install the MultiPrint library via [NuGet](https://www.nuget.org/).

```bash
dotnet add package MultiPrint
```

## Usage

MultiPrint makes it easy to print enumerables and data grids in a user-friendly format. Below are examples of how to use the package's features:

### Printing Enumerables

To print an enumerable collection, you can use the `MultiPrintService` class. Here's an example of printing a list of accounts:

```csharp
using MultiPrint.Services;

var accounts = InvoiceDataSource.GetAccounts();
MultiPrintService.GeneratePdf(accounts);
```
### Printing WinForms DataGridView

To print a DataGridView content, you can use the `MultiPrintService` class. Here's an example of printing a DataGridView content:

```csharp
using MultiPrint.Services;

var accounts = InvoiceDataSource.GetAccounts();
MultiPrintService.GeneratePdf(accounts);
```

### Printing WPF DataGrid

To print a DataGrid content, you can use the `MultiPrintService` class. Here's an example of printing a DataGrid content:

```csharp
using MultiPrint.Services;
namespace PrintWinFormsDataGridViewExample;

MultiPrintService.GeneratePdf<AccountModel>(dataGridView1.DataSource);
```

You can easily tailor the printing output to meet their specific needs by adjusting various settings within the MultiPrint package. To control the appearance of your printed content, you can customize header and footer content, allowing you to include additional information or branding elements. Furthermore, you have the flexibility to set the width and height of the printed pages to match your preferred paper size or layout. You can adjust table settings, such as column alignment, column widths, and cell formatting, to ensure the printed data grid reflects your desired presentation. This level of customization empowers you to create professional and tailored printouts that seamlessly integrate with your application's style and requirements.

```csharp
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
```

