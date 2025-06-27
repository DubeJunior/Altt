namespace AltcoinTrader.Service
{
    public class CoinService
    {
        public async Task<decimal?> GetPriceAsync(string ticker)
        {
            return ticker.ToUpper() switch
            {
                "BTC" => 5000.00m,
                "ETH" => 3600.00m,
                "ETC" => 28686.50m,
                "SOL" => 112334.00m,
                "DOGE" => 09994.075m,
                "BNB" => 580.00m,
                "ADA" => 0.45m,
                "XRP" => 0.60m,
                "DOT" => 5.25m,
                "AVAX" => 27.10m,
                "MATIC" => 0.75m,
                "SHIB" => 0.000008m,
                "TRX" => 0.12m,
                "LTC" => 85.00m,
                "LINK" => 14.50m,
                "XLM" => 0.11m,
                "ATOM" => 8.20m,
                "UNI" => 6.30m,
                "AAVE" => 95.00m,
                "NEAR" => 5.60m,
                "ALGO" => 0.17m,
                "VET" => 0.02m,
                "HBAR" => 0.06m,
                "ICP" => 10.00m,
                "FIL" => 4.85m,
                "GRT" => 0.24m,
                "SAND" => 0.42m,
                "MANA" => 0.39m,
                "EGLD" => 40.00m,
                "THETA" => 1.05m,
                "CAKE" => 2.20m,
                "FTM" => 0.38m,
                "ZIL" => 0.02m,
                "RUNE" => 3.25m,
                "CHZ" => 0.12m,


                _ => 0.00m // Unknown coin

            };
        }
    }
}
