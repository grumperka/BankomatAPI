using Microsoft.EntityFrameworkCore;

namespace BankomatAPI.DAL
{
    public class BankomatDBContextProvider: IBankomatDBContextProvider
    {
        public BankomatContext GetBankomatDBContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankomatContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new BankomatContext(optionsBuilder.Options);
        }

    }
}
