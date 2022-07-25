using FinancePerDICK.HttpRequest;
using Microsoft.AspNetCore.Mvc;

namespace FinancePerDICK.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
