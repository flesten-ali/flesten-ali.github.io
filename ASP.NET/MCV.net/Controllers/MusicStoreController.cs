using Microsoft.AspNetCore.Mvc;

namespace MCV.net.Controllers
{
    public class MusicStoreController : Controller
    {
    

        public IActionResult Index()
        {

            return View();
        }
    }
}
