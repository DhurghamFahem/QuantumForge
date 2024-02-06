# QuantumFroge

QuantumFrogePDF is a versatile NuGet package designed for easy generation of PDFs and XPS documents from enumerables, DataGridViews in Windows Forms, and DataGrids in WPF. It provides customization options for column settings using attributes, allowing users to get a byte array, save to a file path, and even display the generated PDF in the browser.

## Installation

You can install QuantumFroge using the NuGet Package Manager:

```bash
dotnet add package QuantumFroge
```

## Features

- Generate PDFs from enumerables.
- Generate PDFs from DataGridViews in Windows Forms.
- Generate PDFs from DataGrids in WPF.
- Generate XPS from enumerables.
- Generate XPS from DataGridViews in Windows Forms.
- Generate XPS from DataGrids in WPF.
- Customize column settings using attributes.
- Include headers and footers with flexible font families and colors in the generated PDF.
- Get a byte array of the generated document.
- Save the document to a specified file path.
- Save the document to a Stream.
- Display the generated PDF directly in the browser.

## Usage

### Customization Options
- Customize the Class columns
```csharp
public class AccountModel // Test class 
{
    [QuantumForgeName(displayName: "Account number")] // To display the attribute value in the generated document.
    public int Id { get; set; }
    [QuantumForgeName(displayName: "Account name")]
    [QuantumForgeWidth(width: 200)] // To set the column width in the generated document.
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public DateTime Birthdate { get; set; }
    [QuantumForgeCanSum] // If the column is numeric you can set QuantumForgeCanSum to display the summation of the column in the table footer.
    [QuantumForgeSummationText(summationText: "Balance", reverse: true)] // You can change the summation text to any thing.
    public decimal Balance { get; set; }
    [QuantumForgeIgnore] // To ignore the columns to be generated in the document.
    public bool Active { get; set; }
}
```
- Customize Header and Footer
```csharp
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
```
### Getting Byte Array
- Getting Byte Array from Enumerables
```csharp
var accounts = InvoiceDataSource.GetAccounts();
var bytes = QuantumForgeService.GeneratePdf<AccountModel>(accounts);
```
- Getting Byte Array DataGridViews (Windows Forms)
```csharp
var bytes = QuantumForgeService.GeneratePdf<AccountModel>(dataGridView1.DataSource);
```
- Getting Byte Array DataGrids (WPF)
```csharp
var bytes = QuantumForgeService.GeneratePdf<AccountModel>(dataGrid.ItemsSource);
```

### Saving to File Path
- Saving to File Path from Enumerables
```csharp
var filePath = "[YOUR PATH]";
var accounts = InvoiceDataSource.GetAccounts();
QuantumForgeService.GeneratePdf<AccountModel>(accounts, filePath);
```
- Saving to File Path DataGridViews (Windows Forms)
```csharp
var filePath = "[YOUR PATH]";
QuantumForgeService.GeneratePdf<AccountModel>(dataGridView1.DataSource, filePath);
```
- Saving to File Path DataGrids (WPF)
```csharp
var filePath = "[YOUR PATH]";
QuantumForgeService.GeneratePdf<AccountModel>(dataGrid.ItemsSource, filePath);
```

### Saving to Stream
- Saving to Stream Path from Enumerables
```csharp
var accounts = InvoiceDataSource.GetAccounts();
using var stream = new MemoryStream();
QuantumForgeService.GeneratePdf<AccountModel>(accounts, stream);
```
- Saving to Stream Path DataGridViews (Windows Forms)
```csharp
using var stream = new MemoryStream();
QuantumForgeService.GeneratePdf<AccountModel>(dataGridView1.DataSource, stream);
```
- Saving to Stream Path DataGrids (WPF)
```csharp
using var stream = new MemoryStream();
QuantumForgeService.GeneratePdf<AccountModel>(dataGrid.ItemsSource, stream);
```

### Displaying generated document
- Displaying generated document from Enumerables
```csharp
QuantumForgeService.GeneratePdfAndShow<AccountModel>(accounts);
```
- Displaying generated document DataGridViews (Windows Forms)
```csharp
QuantumForgeService.GeneratePdfAndShow<AccountModel>(dataGridView1.DataSource);
```
- Displaying generated document DataGrids (WPF)
```csharp
QuantumForgeService.GeneratePdfAndShow<AccountModel>(dataGrid.ItemsSource);
```

## License

- This project is licensed under the MIT License.
