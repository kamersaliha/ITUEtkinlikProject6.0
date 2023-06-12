using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using ITUEtkinlikProject6._0.Areas.Member.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class KampusController : Controller
    {
        IKampusService _kampusService;
        public KampusController(IKampusService kampusService)
        {
            _kampusService = kampusService;
        }

        [HttpGet]
        public IActionResult NewKampus()
        {
            var model = new KampusViewModel();
            List<Kampus> kampusler = _kampusService.TGetList();
            model.Kampusler = kampusler;
            model.KampusIsAdd = "Ekle";

            return View(model);
        }

        [HttpPost]
        public IActionResult NewKampus(KampusViewModel p)
        {
            var kampus = new Kampus();
            kampus.KampusId = p.KampusId;
            kampus.KampusAdi = p.KampusAdi;
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
            }
            _kampusService.Tadd(kampus);
            return RedirectToAction("CurrentKampus");
        }

        public IActionResult CurrentKampus()
        {
            var model = new List<KampusViewModel>();
            var kampusler = _kampusService.TGetList();

            foreach (var item in kampusler)
            {
                var kampus = new KampusViewModel()
                {
                    Kampusler = kampusler,
                    KampusId = item.KampusId,
                    KampusAdi = item.KampusAdi
                };
                model.Add(kampus);
            }
            return View(model);
        }

        public IActionResult DeleteKampus(int kampusId)
        {
            Kampus kampus = _kampusService.TGetList().FirstOrDefault(x => x.KampusId == kampusId);
            if (kampus != null)
            {
                _kampusService.TDelete(kampus);
            }
            return RedirectToAction("CurrentKampus");
        }

        [HttpGet]
        public IActionResult UpdateKampus(int KampusId)
        {
            var kampusService = _kampusService.TGetById(KampusId);

            var model = new KampusViewModel()
            {
                KampusId = kampusService.KampusId,
                KampusAdi = kampusService.KampusAdi
            };
            model.KampusIsAdd = "Düzenle";

            return View("NewKampus", model);
        }

        [HttpPost]
        public IActionResult UpdateKampus(KampusViewModel kampusCommand)
        {
            var kampus = _kampusService.TGetList().FirstOrDefault(x => x.KampusId == kampusCommand.KampusId);
            kampus.KampusAdi = kampusCommand.KampusAdi;
            _kampusService.TUpdate(kampus);
            return RedirectToAction("CurrentKampus");
        }




    }
}
