using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITUEtkinlikProject6._0.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    
    public class YayinTalebiController : Controller
    {
        // Alt taraftaki yaptığımız olayın adı dependency injection denilir.
        // Design patternin adı, reverse of dependency; uygulamanmasının yöntemi, dependency injection.
        
        IYayinTalebiService _yayinTalebiService;
        ISalonService _salonService;
        IKategoriService _kategoriService;
        IKampusService _kampusService;
        IEtkinlikService _etkinlikService;
        public YayinTalebiController(ISalonService salonService, IKategoriService kategoriService, IYayinTalebiService yayinTalebiService, IKampusService kampusService, IEtkinlikService etkinlikService)
        {
            _yayinTalebiService = yayinTalebiService; // Program.cs'de yaptığımız IoC container'a dependency injection yapılacak olan interface'leri atarak bu yöntem tamamlanmış olur.
            // IoC => Inversion of Control container'ı.
            _salonService = salonService;
            _kategoriService = kategoriService;
            _kampusService  = kampusService;
            _etkinlikService = etkinlikService;
        }
        public IActionResult CurrentYayinTalebi()
        {
            var values = _etkinlikService.TGetList();
            return View(values);
        }
        public IActionResult OldYayinTalebi()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewYayinTalebi()
        {
            var model = new YayinTalebiViewModel();

            List<Kampus> kampusler = _kampusService.TGetList();

            model.Kampusler = kampusler;

            List<Kategori> kategoriler = _kategoriService.TGetList();
            
            model.Kategoriler = kategoriler;

            return View(model);
        }

        [HttpPost]
        public IActionResult NewYayinTalebi(YayinTalebiViewModel p)
        {

            foreach (var salon in _salonService.TGetList())
            {
                if (salon.SalonId == p.YayinTalebi.SalonId)
                {
                    p.YayinTalebi.KampusId = salon.KampusId;
                    break;
                }
            }
            
            _yayinTalebiService.Tadd(p.YayinTalebi);

            return RedirectToAction("CurrentYayinTalebi");
        }

        [HttpPost]
        public JsonResult SalonlariGetir(string kampusId)
        {
            var filtrelenmisSalonlar = _salonService.TGetList().Where(x=> x.KampusId == Convert.ToInt32(kampusId)).ToList();

            return Json(filtrelenmisSalonlar);
        }

    }
}
