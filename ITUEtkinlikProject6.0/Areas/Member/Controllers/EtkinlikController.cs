using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Areas.Member.Controllers
{
    [AllowAnonymous]
    [Area("Member")]
    public class EtkinlikController : Controller
    {
        EtkinlikManager etkinlikManager = new EtkinlikManager(new EfEtkinlikDal());

        public IActionResult Index()
        {
            var values = etkinlikManager.TGetList();
            return View(values);
        }
    }
}
