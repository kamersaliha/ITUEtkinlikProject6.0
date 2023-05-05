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
        EtkinlikManager etkinlikManager = new EtkinlikManager(new EfEtkinlikDal());
        public IActionResult Index()
        {
            var values = etkinlikManager.TGetList();
      
            return View(values);
        }
        [HttpGet]
        public IActionResult EtkinlikDetaylari(int id) 
        {
            var values = etkinlikManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EtkinlikDetaylari(Etkinlik p) 
        {
            return View();
        }
    }
}
