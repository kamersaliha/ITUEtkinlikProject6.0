using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Controllers
{
	[AllowAnonymous]
	public class EtkinlikController : Controller
    {
        IEtkinlikService _etkinlikService;
        public EtkinlikController(IEtkinlikService etkinlikService)
        {
            _etkinlikService = etkinlikService;
        }

        public IActionResult Index()
        {
            var values = _etkinlikService.TGetList();
      
            return View(values);
        }
        [HttpGet]
        public IActionResult EtkinlikDetaylari(int id) 
        {
            var values = _etkinlikService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EtkinlikDetaylari(Etkinlik p) 
        {
            return View();
        }
    }
}
