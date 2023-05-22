using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Areas.Member.Controllers
{
    public class MessageController : Controller
    {

        YayinTalebiManager YayinTalebiManager = new YayinTalebiManager(new EfYayinTalebiDal());

        public IActionResult Index()
        {
            return View();
        }
    }
}
