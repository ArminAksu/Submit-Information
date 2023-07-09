using Submit_Information.Data;
using Submit_Information.Entity;

namespace Submit_Information.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DataContext _dataContext;
        public WalletRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Wallet GetWallet(int id)
        {
            var result = _dataContext.Wallets.Find(id);
            return result;

        }

        public IEnumerable<Wallet> GetWallets()
        {
            return _dataContext.Wallets.ToList();
        }

        public Wallet UpdateWallet(Wallet wallet)
        {
            var result = _dataContext.Wallets.Update(wallet).Entity;
            return result;
        }
    }
}
