using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Controllers
{
    public class DefaultController : Controller
    {
		[AllowAnonymous]
		public IActionResult Index()
        {
            return View();
        }
    }
}
