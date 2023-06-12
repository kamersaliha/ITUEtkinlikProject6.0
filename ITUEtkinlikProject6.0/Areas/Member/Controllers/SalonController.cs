using BusinessLayer.Abstract;
using ITUEtkinlikProject6._0.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class SalonController : Controller
    {
        ISalonService _salonService;

        SalonController(ISalonService salonService)
        {
            salonService = _salonService;
        }

        [HttpGet]
        public IActionResult NewSalon()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult NewSalon(SalonViewModel p)
        //{
        //    RedirectToAction("CurrentSalon");
        //}

        public IActionResult CurrentSalon()
        {
            return View();
        }
    }
}
