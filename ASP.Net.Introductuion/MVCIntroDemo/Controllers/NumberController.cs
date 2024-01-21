using Microsoft.AspNetCore.Mvc;

namespace MVCIntroDemo.Controllers
{
    public class NumberController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Npage()
        {
            
            return View("1ToNpage");
        }
    }
}
