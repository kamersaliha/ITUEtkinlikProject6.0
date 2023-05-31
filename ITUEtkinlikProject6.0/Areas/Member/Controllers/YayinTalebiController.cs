using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Areas.Member.Models;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YayinTalebiViewModel = ITUEtkinlikProject6._0.Areas.Member.Models.YayinTalebiViewModel;

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
            var model = new List<YayinTalebiViewModel>();
            var yayinTalepleri = _yayinTalebiService.TGetList();
            var salonlar = _salonService.TGetList();
            var kategoriler = _kategoriService.TGetList();


            foreach (var yayintalebi in yayinTalepleri)
            { 
            var yayinTalebi = new YayinTalebiViewModel()
            {
                YayinTalepleri = yayinTalepleri,
                Salonlar = salonlar,
                Kategoriler = kategoriler,
                YayinTalebiId = yayintalebi.YayinTalebiId,
                EtkinlikAdi = yayintalebi.EtkinlikAdi,
                SalonId = yayintalebi.SalonId,
                SalonAdi= salonlar.FirstOrDefault(salon => salon.SalonId == yayintalebi.SalonId).SalonAdi,               
                KategoriId = yayintalebi.KategoriId,
                KategoriAdi = kategoriler.FirstOrDefault(kategoriler => kategoriler.KategoriId == yayintalebi.KategoriId).KategoriAdi,
                KatilimciSayisi = yayintalebi.KatilimciSayisi,
                EtkinlikAciklamasi = yayintalebi.EtkinlikAciklamasi,
                EtkinlikAciklamasiKisa = yayintalebi.EtkinlikAciklamasiKisa,
                BaslangicTarihi = (DateTime)yayintalebi.BaslangicTarihi,
                BitisTarihi = (DateTime)yayintalebi.BitisTarihi,
                Durum = yayintalebi.Durumu
            };
            model.Add(yayinTalebi);
        }
            return View(model);
        }

        [HttpGet]
        public IActionResult NewYayinTalebi()
        {
           
            var model = new YayinTalebiViewModel();

            List<Kampus> kampusler = _kampusService.TGetList();

            model.Kampusler = kampusler;

            List<Kategori> kategoriler = _kategoriService.TGetList();
            
            model.Kategoriler = kategoriler;

            model.YayinTalebiIsAdd = "Ekle";

            return View(model);
        }

        [HttpPost]
        public IActionResult NewYayinTalebi(YayinTalebiViewModel p)
        {
            var yayinTalebi = new YayinTalebi();
            yayinTalebi.EtkinlikAciklamasi = p.EtkinlikAciklamasi;
            yayinTalebi.EtkinlikAdi = p.EtkinlikAdi;
            yayinTalebi.SalonId = p.SalonId;
            yayinTalebi.EtkinlikAciklamasiKisa = p.EtkinlikAciklamasiKisa;
            yayinTalebi.KategoriId = p.KategoriId;
            yayinTalebi.KatilimciSayisi = p.KatilimciSayisi;
            yayinTalebi.BaslangicTarihi = p.BaslangicTarihi;

            foreach (var salon in _salonService.TGetList())
            {
                if (salon.SalonId == p.SalonId)
                {
                    yayinTalebi.KampusId = salon.KampusId;
                    break;
                }
            }

            var validator = new YayinTalebiValidator();
            var result = validator.Validate(yayinTalebi);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View(p);
            }

            _yayinTalebiService.Tadd(yayinTalebi);

            return RedirectToAction("member/CurrentYayinTalebi");
        }

        [HttpPost]
        public JsonResult SalonlariGetir(string kampusId)
        {
            var filtrelenmisSalonlar = _salonService.TGetList().Where(x=> x.KampusId == Convert.ToInt32(kampusId)).ToList();
            
            return Json(filtrelenmisSalonlar);
        }
       
        public ActionResult DeleteYayinTalebi(int yayinTalebiId)
        {
            YayinTalebi yayinTalebi = _yayinTalebiService.TGetList().FirstOrDefault(x => x.YayinTalebiId == yayinTalebiId);

            if (yayinTalebi != null)
            {
                _yayinTalebiService.TDelete(yayinTalebi);              
            }
            return RedirectToAction("/YayinTalebi/CurrentYayinTalebi", new { Areas = "Member" });
        }

        [HttpGet]
        public IActionResult UpdateYayinTalebi(int yayinTalebiId)
        {
            var yayinTalebi = _yayinTalebiService.TGetById(yayinTalebiId);
            var kampusService = _kampusService.TGetList();
            var salonService = _salonService.TGetList();
            var kategoriService= _kategoriService.TGetList();
            var model = new YayinTalebiViewModel()
            {
                EtkinlikAciklamasi = yayinTalebi.EtkinlikAciklamasi,
                EtkinlikAciklamasiKisa = yayinTalebi.EtkinlikAciklamasiKisa,
                EtkinlikAdi = yayinTalebi.EtkinlikAdi,
                SalonId = yayinTalebi.SalonId,
                KategoriId = yayinTalebi.KategoriId,
                KatilimciSayisi = yayinTalebi.KatilimciSayisi,
                BaslangicTarihi = (DateTime)yayinTalebi.BaslangicTarihi,
                BitisTarihi = (DateTime)yayinTalebi.BitisTarihi,
                KampusId = yayinTalebi.KampusId,
                KampusAdi = kampusService.FirstOrDefault(x => x.KampusId == yayinTalebi.KampusId)?.KampusAdi,
                SalonAdi = salonService.FirstOrDefault(x => x.SalonId==yayinTalebi.SalonId)?.SalonAdi,
                KategoriAdi = kategoriService.FirstOrDefault(x=>x.KategoriId==yayinTalebi.KategoriId)?.KategoriAdi

            };
            model.Kampusler = _kampusService.TGetList();
            model.Kategoriler = _kategoriService.TGetList();
            model.YayinTalebiIsAdd = "Düzenle";
            return View("NewYayinTalebi", model);
        }
        [HttpPost]
        public IActionResult UpdateYayinTalebi(YayinTalebiViewModel yayinTalebiCommand)
        {
           var yayinTalebi =  _yayinTalebiService.TGetList().FirstOrDefault(x => x.YayinTalebiId == yayinTalebiCommand.YayinTalebiId);
            yayinTalebi.KatilimciSayisi = yayinTalebiCommand.KatilimciSayisi;
            yayinTalebi.BitisTarihi = yayinTalebiCommand.BitisTarihi;
            yayinTalebi.BaslangicTarihi = yayinTalebiCommand.BaslangicTarihi;
            yayinTalebi.EtkinlikAciklamasi = yayinTalebiCommand.EtkinlikAciklamasi;
            yayinTalebi.EtkinlikAciklamasiKisa = yayinTalebiCommand.EtkinlikAciklamasiKisa;
            yayinTalebi.SalonId = yayinTalebiCommand.SalonId;
            yayinTalebi.KategoriId = yayinTalebiCommand.KategoriId;

            foreach (var salon in _salonService.TGetList())
            {
                if (salon.SalonId == yayinTalebiCommand.SalonId)
                {
                    yayinTalebi.KampusId = salon.KampusId;
                    break;
                }
            }
            _yayinTalebiService.TUpdate(yayinTalebi);
            return View("CurrentYayinTalebi");
        }

        [HttpGet]
        public IActionResult YayinTalebiDetails(int id)
        {
            var yayinTalebi = _yayinTalebiService.TGetById(id);
            var kampusService = _kampusService.TGetList();
            var salonService = _salonService.TGetList();
            var kategoriService = _kategoriService.TGetList();
            var model = new YayinTalebiViewModel()
            {
                YayinTalebiId= yayinTalebi.YayinTalebiId,
                EtkinlikAciklamasi = yayinTalebi.EtkinlikAciklamasi,
                EtkinlikAciklamasiKisa = yayinTalebi.EtkinlikAciklamasiKisa,
                EtkinlikAdi = yayinTalebi.EtkinlikAdi,
                SalonId = yayinTalebi.SalonId,
                KategoriId = yayinTalebi.KategoriId,
                KatilimciSayisi = yayinTalebi.KatilimciSayisi,
                BaslangicTarihi = (DateTime)yayinTalebi.BaslangicTarihi,
                BitisTarihi = (DateTime)yayinTalebi.BitisTarihi,
                KampusId = yayinTalebi.KampusId,
                KampusAdi = kampusService.FirstOrDefault(x => x.KampusId == yayinTalebi.KampusId)?.KampusAdi,
                SalonAdi = salonService.FirstOrDefault(x => x.SalonId == yayinTalebi.SalonId)?.SalonAdi,
                KategoriAdi = kategoriService.FirstOrDefault(x => x.KategoriId == yayinTalebi.KategoriId)?.KategoriAdi

            };
            return View(model);
        }
    }
}
