
using QuantumFroge.Attributes;

namespace PrintEnumerablesExample;

public class AccountModel
{
    [QuantumFrogeName(displayName: "Account number")] // To display the attribute value in the generated document.
    public int Id { get; set; }
    [QuantumFrogeName(displayName: "Account name")]
    [QuantumFrogeWidth(width: 200)] // To set the column width in the generated document.
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public DateTime Birthdate { get; set; }
    [QuantumFrogeCanSum] // If the column is numeric you can set QuantumForgeCanSum to display the summation of the column in the table footer.
    [QuantumFrogeSummationText(summationText: "Balance", reverse: true)] // You can change the summation text to any thing.
    public decimal Balance { get; set; }
    [QuantumFrogeIgnore] // To ignore the columns to be generated in the document.
    public bool Active { get; set; }
}

public class InvoiceDataSource
{
    public static List<AccountModel> GetAccounts()
    {
        return Enumerable
             .Range(1, 10)
             .Select(i => GenerateTestAccount(i))
             .ToList();
    }



    private static AccountModel GenerateTestAccount(int id)
    {
        var now = DateTime.Now;
        return new AccountModel
        {
            Id = id,
            Name = $"Test Account {id}",
            Active = id % 2 == 0,
            Balance = id * 1000,
            Birthdate = new DateTime(now.Year, id, id),
            Phone = $"123{id}"
        };
    }
}
