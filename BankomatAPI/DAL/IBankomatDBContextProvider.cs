namespace BankomatAPI.DAL
{
    public interface IBankomatDBContextProvider
    {
        BankomatContext GetBankomatDBContext(string connectionString);
    }
}
