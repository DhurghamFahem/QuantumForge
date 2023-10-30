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

To print an enumerable collection, you can use the `EnumerableDocument` class. Here's an example of printing a list of accounts:

```csharp
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
        Value = "Test Company"
    },
    TableFooter = new CellSettings
    {
        Background = "5d5555"
    }
};

var accountsDocument = new EnumerableDocument<AccountModel>(accounts, settings);
accountsDocument.GeneratePdf();

