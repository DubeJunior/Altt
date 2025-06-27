namespace AltcoinTrader.Models
{
    public class Coin
    {
        public int CoinID { get; set; } 
        public string CoinName { get; set; }
        public string CoinTicker { get; set; }
        public decimal CoinPrice { get; set; }
        public int CoinVote { get; set; } = 0;
    }
}
