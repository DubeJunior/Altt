namespace AltcoinTrader.Models.ViewModels
{
    public class CornViewModel
    {
        public string CoinName { get; set; }
        public string CoinTicker { get; set; }
        public string Errormessage { get; set; }
        public List<Coin> ShowCoins { get; set; }
    }
}
