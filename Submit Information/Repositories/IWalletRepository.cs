using Submit_Information.Entity;

namespace Submit_Information.Repositories
{
    public interface IWalletRepository
    {
        Wallet UpdateWallet(Wallet wallet);
        IEnumerable<Wallet> GetWallets();
        Wallet GetWallet(int id);
    }
}
