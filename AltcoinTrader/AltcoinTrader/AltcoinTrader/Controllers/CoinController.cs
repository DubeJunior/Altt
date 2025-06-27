using AltcoinTrader.Data;
using AltcoinTrader.Models;
using AltcoinTrader.Models.ViewModels;
using AltcoinTrader.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AltcoinTrader.Controllers
{
    public class CoinController : Controller
    {
        private readonly CoinService _coinService;
        private readonly ApplicationDBcontext _dbcontext;

        public CoinController(ApplicationDBcontext dbcontext, CoinService coinService)
        {
            _dbcontext = dbcontext;
            _coinService = coinService;
        }

        
        [HttpGet]
        public IActionResult CoinForm()
        {
            var model = new CornViewModel
            {
                ShowCoins = _dbcontext.Coins.OrderByDescending(c => c.CoinVote).ToList()
            };
            return View(model);
        }

       
        [HttpPost]
        public async Task<IActionResult> CoinForm(CornViewModel model)
        {
            if (model.CoinName == null || model.CoinName == "" || model.CoinTicker == null || model.CoinTicker == "")
            {
                model.Errormessage = "Oops! You missed some info.";
                model.ShowCoins = _dbcontext.Coins.ToList();
                return View(model);
            }

            bool exists = _dbcontext.Coins.Any(c => c.CoinTicker.ToUpper() == model.CoinTicker.ToUpper());
            if (exists)
            {
                model.Errormessage = "Coin already requested.";
                model.ShowCoins = _dbcontext.Coins.ToList();
                return View(model);
            }

            var price = await _coinService.GetPriceAsync(model.CoinTicker);

            var newCoin = new Coin
            {
                CoinName = model.CoinName,
                CoinTicker = model.CoinTicker.ToUpper(),
                CoinPrice = price ?? 0,
                CoinVote = 0
            };

            _dbcontext.Coins.Add(newCoin);
            await _dbcontext.SaveChangesAsync();

            return RedirectToAction("CoinForm");
        }

        
        [HttpPost]
        public async Task<IActionResult> Upvote(int id)
        {
            var coin = await _dbcontext.Coins.FindAsync(id);
            if (coin != null)
            {
                coin.CoinVote++;
                await _dbcontext.SaveChangesAsync();
            }

            return RedirectToAction("CoinForm");
        }
    }
}
