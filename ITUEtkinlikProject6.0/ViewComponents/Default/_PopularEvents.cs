using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.ViewComponents.Default
{
    public class _PopularEvents : ViewComponent
    {
        EtkinlikManager etkinlikManager = new EtkinlikManager(new EfEtkinlikDal());
        public IViewComponentResult Invoke()
        {
            var values = etkinlikManager.TGetList();
            return View(values);
        }
    }
}

