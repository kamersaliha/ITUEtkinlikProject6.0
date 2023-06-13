using BusinessLayer.Abstract;
using ITUEtkinlikProject6._0.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace ITUEtkinlikProject6._0.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class SalonController : Controller
    {
        ISalonService _salonService;
        IKampusService _kampusService;

        public SalonController(ISalonService salonService, IKampusService kampusService)
        {
            _salonService = salonService;
            _kampusService = kampusService;
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
            salon.SalonId=p.SalonId;
            salon.SalonAdi = p.SalonAdi;
            salon.KampusId= p.KampusId; 
            salon.SalonKapasitesi = p.SalonKapasitesi;

            _salonService.Tadd(salon);
            return RedirectToAction("CurrentSalon");
        }

        public IActionResult CurrentSalon()
        {
            var model = new List<SalonViewModel>();
            var salonlar = _salonService.TGetList();
            var kampusler = _kampusService.TGetList();

            foreach ( var item in salonlar )
            {
                var salon = new SalonViewModel()
                {
                    Salonlar = salonlar,
                    Kampusler = kampusler,
                    SalonId = item.SalonId,
                    SalonAdi = item.SalonAdi,
                    KampusId = item.KampusId,
                    KampusAdi = kampusler.FirstOrDefault(kampus => kampus.KampusId == item.KampusId).KampusAdi,
                    SalonKapasitesi=item.SalonKapasitesi

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
                KampusId = salon.KampusId,
                KampusAdi= kampusService.FirstOrDefault(x => x.KampusId == salon.KampusId).KampusAdi,
                SalonKapasitesi= salon.SalonKapasitesi

            };
            model.Kampusler = _kampusService.TGetList();
            model.SalonIsAdd = "Düzenle";
            return View("NewSalon", model);
        }
        [HttpPost]
        public IActionResult UpdateSalon(SalonViewModel salonCommand)
        {
            var salon = _salonService.TGetList().FirstOrDefault(x=>x.SalonId == salonCommand.SalonId);
            salon.SalonAdi= salonCommand.SalonAdi;
            salon.SalonKapasitesi = salonCommand.SalonKapasitesi;
            salon.KampusId = salonCommand.KampusId;
            salon.SalonKapasitesi = salonCommand.SalonKapasitesi;
            _salonService.TUpdate(salon);
          
            return RedirectToAction("CurrentSalon");
        }

        public IActionResult DeleteSalon(int salonId)
        {
            Salon salon = _salonService.TGetList().FirstOrDefault(x=> x.SalonId == salonId);

            if(salon!=null)
            {
                _salonService.TDelete(salon);
            }

            return RedirectToAction("CurrentSalon");
        }
        
    }
}
