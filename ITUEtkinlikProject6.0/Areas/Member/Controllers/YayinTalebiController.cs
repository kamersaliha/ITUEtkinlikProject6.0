using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Areas.Member.Controllers
{
    [Area("Member")]
    public class YayinTalebiController : Controller
    {

        public IActionResult CurrentYayinTalebi()
        {
            return View();
        }
        public IActionResult OldYayinTalebi()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewYayinTalebi()
        {

            return View();
        }
        [HttpPost]
        public IActionResult NewYayinTalebi(YayinTalebi p)
        {
            return View();
        }
    }
}
