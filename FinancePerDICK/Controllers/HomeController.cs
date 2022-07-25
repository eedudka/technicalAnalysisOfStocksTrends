using FinancePerDICK.HttpRequest;
using Microsoft.AspNetCore.Mvc;

namespace FinancePerDICK.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var yHoo = new YahooFinanceHttp("https://finance.yahoo.com/quote/YNDX.ME/")
                           .CreateData()
                           .Result;

            return View();
        }
    }
}
