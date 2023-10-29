namespace PrintEnumerablesExample;

public class AccountModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public DateTime Birthdate { get; set; }
    public decimal Balance { get; set; }
    public bool Active { get; set; }
}

public class InvoiceDocumentDataSource
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
