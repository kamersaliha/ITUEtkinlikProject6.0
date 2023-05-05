using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.ViewComponents.Default
{
    public class _Statistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Etkinlikler.Count();
            ViewBag.v2 = "267";
            ViewBag.v3 = "34";
            return View();
        }
    }
}
