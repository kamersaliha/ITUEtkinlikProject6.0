using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Controllers
{
    [AllowAnonymous]
    public class YayinTalebiController : Controller
    {
        IYayinTalebiService _yayinTalebiService;
        ISalonService _salonService;
        IKategoriService _kategoriService;
        IKampusService _kampusService;
        public YayinTalebiController(ISalonService salonService, IKategoriService kategoriService, IYayinTalebiService yayinTalebiService, IKampusService kampusService)
        {
            _yayinTalebiService = yayinTalebiService;
            _salonService = salonService;
            _kategoriService = kategoriService;
            _kampusService = kampusService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new YayinTalebiViewModel();

            List<Kampus> kampusler = _kampusService.TGetList();

            model.Kampusler = kampusler;

            List<Kategori> kategoriler = _kategoriService.TGetList();

            model.Kategoriler = kategoriler;

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(YayinTalebiViewModel p)
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
            var filtrelenmisSalonlar = _salonService.TGetList().Where(x => x.KampusId == Convert.ToInt32(kampusId)).ToList();

            return Json(filtrelenmisSalonlar);
        }
    }
}
