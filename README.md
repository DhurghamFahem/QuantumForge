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
using PrintEnumerablesExample;

var accounts = InvoiceDocumentDataSource.GetAccounts();
MultiPrintService.GeneratePdf(accounts);
```

To print a DataGrid content, you can use the `MultiPrintService` class. Here's an example of printing a DataGrid content:

```csharp
using MultiPrint.Services;
using PrintEnumerablesExample;

var accounts = InvoiceDocumentDataSource.GetAccounts();
MultiPrintService.GeneratePdf(accounts);
```

You can easily tailor the printing output to meet their specific needs by adjusting various settings within the MultiPrint package. To control the appearance of your printed content, you can customize header and footer content, allowing you to include additional information or branding elements. Furthermore, you have the flexibility to set the width and height of the printed pages to match your preferred paper size or layout. You can adjust table settings, such as column alignment, column widths, and cell formatting, to ensure the printed data grid reflects your desired presentation. This level of customization empowers you to create professional and tailored printouts that seamlessly integrate with your application's style and requirements.

