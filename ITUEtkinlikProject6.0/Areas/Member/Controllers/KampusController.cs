using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using ITUEtkinlikProject6._0.Areas.Member.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ITUEtkinlikProject6._0.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    [Route("Member/[controller]/[action]")]
    public class KampusController : Controller
    {
        IKampusService _kampusService;
        IToastNotification _toast;
        public KampusController(IKampusService kampusService, IToastNotification toast)
        {
            _kampusService = kampusService;
            _toast = toast;
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
            kampus.KampusAdiEn = p.KampusAdiEn;
            if (kampus==null)
            {
                _toast.AddErrorToastMessage("Kampüs eklenemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _kampusService.Tadd(kampus);
            _toast.AddSuccessToastMessage("Kampüs başarıyla eklendi!", new ToastrOptions { Title = "Başarılı!" });
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
                    KampusAdi = item.KampusAdi,
                    KampusAdiEn = item.KampusAdiEn
                };
                model.Add(kampus);
            }
            return View(model);
        }

        public IActionResult DeleteKampus(int kampusId)
        {
            Kampus kampus = _kampusService.TGetList().FirstOrDefault(x => x.KampusId == kampusId);
            if (kampus == null)
            {
                _toast.AddErrorToastMessage("Kampüs silinemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _kampusService.TDelete(kampus);
            _toast.AddSuccessToastMessage("Kampüs başarıyla silindi!", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("CurrentKampus");
        }

        [HttpGet]
        public IActionResult UpdateKampus(int KampusId)
        {
            var kampusService = _kampusService.TGetById(KampusId);

            var model = new KampusViewModel()
            {
                KampusId = kampusService.KampusId,
                KampusAdi = kampusService.KampusAdi,
                KampusAdiEn = kampusService.KampusAdiEn
            };
            model.KampusIsAdd = "Düzenle";

            return View("NewKampus", model);
        }

        [HttpPost]
        public IActionResult UpdateKampus(KampusViewModel kampusCommand)
        {
            var kampus = _kampusService.TGetList().FirstOrDefault(x => x.KampusId == kampusCommand.KampusId);
            kampus.KampusAdi = kampusCommand.KampusAdi;
            kampus.KampusAdiEn = kampusCommand.KampusAdiEn;
            if(kampus==null) 
            {
                _toast.AddErrorToastMessage("Kampüs güncellenemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _kampusService.TUpdate(kampus);
            _toast.AddSuccessToastMessage("Kampüs başarıyla güncellendi!", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("CurrentKampus");
        }

        public JsonResult KampusIsExist(string KampusAdi)
        {
            var kampusAdi = _kampusService.TGetList().Where(k => k.KampusAdi == KampusAdi).SingleOrDefault();
            if (kampusAdi != null)
            {
                return Json(false);
            }
            return Json(true);
        }




    }
}
