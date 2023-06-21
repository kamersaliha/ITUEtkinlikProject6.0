using BusinessLayer.Abstract;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using NToastNotify;

namespace ITUEtkinlikProject6._0.Controllers
{
    [AllowAnonymous]
    public class SalonController : Controller
    {
        ISalonService _salonService;
        IKampusService _kampusService;
        IToastNotification _toast;

        public SalonController(ISalonService salonService, IKampusService kampusService, IToastNotification toast)
        {
            _salonService = salonService;
            _kampusService = kampusService;
            _toast = toast;
        }

        [HttpGet]
        public IActionResult NewSalon()
        {
            var model = new SalonViewModel();
            List<Kampus> kampusler = _kampusService.TGetList();
            model.Kampusler = kampusler;
            model.SalonIsAdd = "Ekle";

            return View(model);
        }

        [HttpPost]
        public IActionResult NewSalon(SalonViewModel p)
        {
            var salon = new Salon();
            salon.SalonId = p.SalonId;
            salon.SalonAdi = p.SalonAdi;
            salon.SalonAdiEn = p.SalonAdiEn;
            salon.KampusId = p.KampusId;
            salon.SalonKapasitesi = p.SalonKapasitesi;
            if (salon == null)
            {
                _toast.AddErrorToastMessage("Salon eklenemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _toast.AddSuccessToastMessage("Salon başarıyla eklendi!", new ToastrOptions { Title = "Başarılı!" });

            _salonService.Tadd(salon);
            return RedirectToAction("CurrentSalon");
        }

        public IActionResult CurrentSalon()
        {
            var model = new List<SalonViewModel>();
            var salonlar = _salonService.TGetList();
            var kampusler = _kampusService.TGetList();

            foreach (var item in salonlar)
            {
                var salon = new SalonViewModel()
                {
                    Salonlar = salonlar,
                    Kampusler = kampusler,
                    SalonId = item.SalonId,
                    SalonAdi = item.SalonAdi,
                    SalonAdiEn = item.SalonAdiEn,
                    KampusId = item.KampusId,
                    KampusAdi = kampusler.FirstOrDefault(kampus => kampus.KampusId == item.KampusId).KampusAdi,
                    SalonKapasitesi = item.SalonKapasitesi

                };
                model.Add(salon);
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateSalon(int salonId)
        {
            var salon = _salonService.TGetById(salonId);
            var kampusService = _kampusService.TGetList();

            var model = new SalonViewModel()
            {
                SalonId = salon.SalonId,
                SalonAdi = salon.SalonAdi,
                SalonAdiEn = salon.SalonAdiEn,
                KampusId = salon.KampusId,
                KampusAdi = kampusService.FirstOrDefault(x => x.KampusId == salon.KampusId).KampusAdi,
                SalonKapasitesi = salon.SalonKapasitesi

            };
            model.Kampusler = _kampusService.TGetList();
            model.SalonIsAdd = "Düzenle";
            return View("NewSalon", model);
        }
        [HttpPost]
        public IActionResult UpdateSalon(SalonViewModel salonCommand)
        {
            var salon = _salonService.TGetList().FirstOrDefault(x => x.SalonId == salonCommand.SalonId);
            salon.SalonAdi = salonCommand.SalonAdi;
            salon.SalonAdiEn = salonCommand.SalonAdiEn;
            salon.SalonKapasitesi = salonCommand.SalonKapasitesi;
            salon.KampusId = salonCommand.KampusId;
            salon.SalonKapasitesi = salonCommand.SalonKapasitesi;
            if (salon == null)
            {
                _toast.AddErrorToastMessage("Salon güncellenemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _salonService.TUpdate(salon);
            _toast.AddSuccessToastMessage("Salon başarıyla güncellendi!", new ToastrOptions { Title = "Başarılı!" });

            return RedirectToAction("CurrentSalon");
        }

        public IActionResult DeleteSalon(int salonId)
        {
            Salon salon = _salonService.TGetList().FirstOrDefault(x => x.SalonId == salonId);

            if (salon == null)
            {
                _toast.AddErrorToastMessage("Salon silinemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _salonService.TDelete(salon);
            _toast.AddSuccessToastMessage("Salon başarıyla silindi!", new ToastrOptions { Title = "Başarılı!" });

            return RedirectToAction("CurrentSalon");
        }

        public JsonResult SalonIsExist(string SalonAdi)
        {
            var salonAdi = _salonService.TGetList().Where(s => s.SalonAdi == SalonAdi).SingleOrDefault();
            if (salonAdi != null)
            {
                return Json(false);
            }
            return Json(true);
        }

    }
}
