using MultiPrint.Services;

namespace PrintWinFormsDataGridViewExample;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        var accounts = InvoiceDataSource.GetAccounts();
        dataGridView1.DataSource = accounts;
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        MultiPrintService.Print<AccountModel>(dataGridView1.DataSource);
    }

    private void btnGeneratePdf_Click(object sender, EventArgs e)
    {
        MultiPrintService.GeneratePdf<AccountModel>(dataGridView1.DataSource);
    }

    private void btnGenerateXbs_Click(object sender, EventArgs e)
    {
        MultiPrintService.GenerateXps<AccountModel>(dataGridView1.DataSource);
    }
}
