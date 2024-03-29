﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using YayinTalebiViewModel = ITUEtkinlikProject6._0.Models.YayinTalebiViewModel;

namespace ITUEtkinlikProject6._0.Controllers
{
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
        IToastNotification _toast;
        public YayinTalebiController(ISalonService salonService, IKategoriService kategoriService, IYayinTalebiService yayinTalebiService, IKampusService kampusService, IEtkinlikService etkinlikService, IToastNotification toast)
        {
            _yayinTalebiService = yayinTalebiService; // Program.cs'de yaptığımız IoC container'a dependency injection yapılacak olan interface'leri atarak bu yöntem tamamlanmış olur.
            // IoC => Inversion of Control container'ı.
            _salonService = salonService;
            _kategoriService = kategoriService;
            _kampusService = kampusService;
            _etkinlikService = etkinlikService;
            _toast = toast;
        }
        //Yayın taleplerinin listelendiği action method
        public IActionResult CurrentYayinTalebi()
        {
            var model = new List<YayinTalebiViewModel>();
            //_yayinTalebiService.TGetList() yöntemi çağrılarak tüm yayın talepleri alınır.
            var yayinTalepleri = _yayinTalebiService.TGetList();
            var salonlar = _salonService.TGetList();
            var kategoriler = _kategoriService.TGetList();

            //Her bir yayın talebi için bir YayinTalebiViewModel örneği oluşturulur ve veriler atanır.
            foreach (var yayintalebi in yayinTalepleri)
            {
                var yayinTalebi = new YayinTalebiViewModel()
                {
                    YayinTalepleri = yayinTalepleri,
                    Salonlar = salonlar,
                    Kategoriler = kategoriler,
                    YayinTalebiId = yayintalebi.YayinTalebiId,
                    EtkinlikAdi = yayintalebi.EtkinlikAdi,
                    EtkinlikAdiEn = yayintalebi.EtkinlikAdiEn,
                    SalonId = yayintalebi.SalonId,
                    SalonAdi = salonlar.FirstOrDefault(salon => salon.SalonId == yayintalebi.SalonId).SalonAdi,
                    KategoriId = yayintalebi.KategoriId,
                    KategoriAdi = kategoriler.FirstOrDefault(kategoriler => kategoriler.KategoriId == yayintalebi.KategoriId).KategoriAdi,
                    KatilimciSayisi = yayintalebi.KatilimciSayisi,
                    EtkinlikAciklamasi = yayintalebi.EtkinlikAciklamasi,
                    EtkinlikAciklamasiEn = yayintalebi.EtkinlikAciklamasiEn,
                    EtkinlikAciklamasiKisa = yayintalebi.EtkinlikAciklamasiKisa,
                    EtkinlikAciklamasiKisaEn = yayintalebi.EtkinlikAciklamasiKisaEn,
                    BaslangicTarihi = (DateTime)yayintalebi.BaslangicTarihi,
                    BitisTarihi = (DateTime)yayintalebi.BitisTarihi,
                };
                //Oluşturulan YayinTalebiViewModel örneği, model listesine eklenir.
                model.Add(yayinTalebi);
            }
            return View(model);
        }
        // Yeni yayın talebi isteği ekranını getiren action method
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
        // Yeni yayın talebi isteğini post eden (gönderen) action method
        [HttpPost]
        public IActionResult NewYayinTalebi(YayinTalebiViewModel p)
        {
            var yayinTalebi = new YayinTalebi();
            yayinTalebi.EtkinlikAciklamasi = p.EtkinlikAciklamasi;
            yayinTalebi.EtkinlikAciklamasiEn = p.EtkinlikAciklamasiEn;
            yayinTalebi.EtkinlikAdi = p.EtkinlikAdi;
            yayinTalebi.EtkinlikAdiEn = p.EtkinlikAdiEn;
            yayinTalebi.SalonId = p.SalonId;
            yayinTalebi.EtkinlikAciklamasiKisa = p.EtkinlikAciklamasiKisa;
            yayinTalebi.EtkinlikAciklamasiKisaEn = p.EtkinlikAciklamasiKisaEn;
            yayinTalebi.KategoriId = p.KategoriId;
            yayinTalebi.KatilimciSayisi = p.KatilimciSayisi;
            yayinTalebi.BaslangicTarihi = p.BaslangicTarihi;
            yayinTalebi.BitisTarihi = p.BitisTarihi;

            foreach (var salon in _salonService.TGetList())
            {
                if (salon.SalonId == p.SalonId)
                {
                    yayinTalebi.KampusId = salon.KampusId;
                    break;
                }
            }

            ////YayinTalebiValidator sınıfı kullanılarak yayinTalebi nesnesinin doğrulama işlemi gerçekleştirilir.
            //var validator = new YayinTalebiValidator();

            ////validator.Validate(yayinTalebi) yöntemi çağrılarak yayinTalebi nesnesi doğrulanır ve sonuç (result) alınır.
            //var result = validator.Validate(yayinTalebi);

            //if (!result.IsValid)
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError("", error.ErrorMessage);
            //    }
            //    return View(p);
            //}
            if (yayinTalebi == null)
            {
                _toast.AddErrorToastMessage("Yayın talebi eklenemedi!", new ToastrOptions { Title = "Başarısız!" });
            }

            _yayinTalebiService.Tadd(yayinTalebi);
            _toast.AddSuccessToastMessage("Yayın talebi başarıyla eklendi!", new ToastrOptions { Title = "Başarılı!" });

            return RedirectToAction("CurrentYayinTalebi");
        }

        //Yayın taleplerinin listelendiği sayfada ilgili yayın talebini silmek için  kullanılan action method
        public ActionResult DeleteYayinTalebi(int yayinTalebiId)
        {

            //yayinTalebiId parametresi kullanılarak _yayinTalebiService.TGetList() yöntemi çağrılır ve belirtilen yayinTalebiId değerine sahip yayın talebini alınır.
            YayinTalebi yayinTalebi = _yayinTalebiService.TGetList().FirstOrDefault(x => x.YayinTalebiId == yayinTalebiId);

            //yayinTalebi null değilse _yayinTalebiService.TDelete(yayinTalebi) yöntemi çağrılır ve yayın talebi silinir.
            if (yayinTalebi == null)
            {
                _toast.AddErrorToastMessage("Yayın talebi silinemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _yayinTalebiService.TDelete(yayinTalebi);
            _toast.AddSuccessToastMessage("Yayın talebi başarıyla silindi!", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("CurrentYayinTalebi");
        }

        //Yayın talebinin düzenlendiği sayfayı çağıran action method
        [HttpGet]
        public IActionResult UpdateYayinTalebi(int yayinTalebiId)
        {
            //Servislerden veriler alınır.
            var yayinTalebi = _yayinTalebiService.TGetById(yayinTalebiId);
            var kampusService = _kampusService.TGetList();
            var salonService = _salonService.TGetList();
            var kategoriService = _kategoriService.TGetList();

            //Değişkenlerden alınan veriler YayinTalebiViewModelQdeki ilgili değişkenlere aktarılır ve modelde saklanır.
            var model = new YayinTalebiViewModel()
            {
                EtkinlikAciklamasi = yayinTalebi.EtkinlikAciklamasi,
                EtkinlikAciklamasiEn = yayinTalebi.EtkinlikAciklamasiEn,
                EtkinlikAciklamasiKisa = yayinTalebi.EtkinlikAciklamasiKisa,
                EtkinlikAciklamasiKisaEn = yayinTalebi.EtkinlikAciklamasiKisaEn,
                EtkinlikAdi = yayinTalebi.EtkinlikAdi,
                EtkinlikAdiEn = yayinTalebi.EtkinlikAdiEn,
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

            //Kampüsler, salonlar ve kategorilerin listelenebilmesi için servislerden ilgili veriler modele aktarılır ve view'e yönlendirilir
            model.Kampusler = _kampusService.TGetList();
            model.Kategoriler = _kategoriService.TGetList();
            model.YayinTalebiIsAdd = "Düzenle";
            return View("NewYayinTalebi", model);
        }

        //Yayın talebi düzenlemelerini yapıldıktan sonra veritabanına post eden method
        [HttpPost]
        public IActionResult UpdateYayinTalebi(YayinTalebiViewModel yayinTalebiCommand)
        {

            //Database üzerindeki YayınTalebi nesnesinin özellikleri kullanıcıdan gelen yayinTalebiCommand nesnesinin özellikleriyle güncellenir. 
            var yayinTalebi = _yayinTalebiService.TGetList().FirstOrDefault(x => x.YayinTalebiId == yayinTalebiCommand.YayinTalebiId);
            yayinTalebi.EtkinlikAdi = yayinTalebiCommand.EtkinlikAdi;
            yayinTalebi.EtkinlikAdiEn = yayinTalebiCommand.EtkinlikAdiEn;
            yayinTalebi.KatilimciSayisi = yayinTalebiCommand.KatilimciSayisi;
            yayinTalebi.BitisTarihi = yayinTalebiCommand.BitisTarihi;
            yayinTalebi.BaslangicTarihi = yayinTalebiCommand.BaslangicTarihi;
            yayinTalebi.EtkinlikAciklamasi = yayinTalebiCommand.EtkinlikAciklamasi;
            yayinTalebi.EtkinlikAciklamasiEn = yayinTalebiCommand.EtkinlikAciklamasiEn;
            yayinTalebi.EtkinlikAciklamasiKisa = yayinTalebiCommand.EtkinlikAciklamasiKisa;
            yayinTalebi.EtkinlikAciklamasiKisaEn = yayinTalebiCommand.EtkinlikAciklamasiKisaEn;
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
            if (yayinTalebi == null)
            {
                _toast.AddErrorToastMessage("Yayın talebi güncellenemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            //_yayinTalebiService.TUpdate(yayinTalebi) kullanılarak güncellenen yayın talebi veritabanına kaydedilir
            _yayinTalebiService.TUpdate(yayinTalebi);
            _toast.AddSuccessToastMessage("Yayın talebi başarıyla güncellendi!", new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("CurrentYayinTalebi");
        }

        //Belirli bir yayın talebinin detaylarını görüntülemek için kullanılan action method
        [HttpGet]
        public IActionResult YayinTalebiDetails(int yayinTalebiId)
        {

            //id parametresiyle ilgili yayın talebi _yayinTalebiService hizmetinden (TGetById yöntemiyle) alınır.
            var yayinTalebi = _yayinTalebiService.TGetById(yayinTalebiId);
            var kampusService = _kampusService.TGetList();
            var salonService = _salonService.TGetList();
            var kategoriService = _kategoriService.TGetList();

            //İlgili özellikler YayinTalebiViewModel'e atanır.
            var model = new YayinTalebiViewModel()
            {
                YayinTalebiId = yayinTalebi.YayinTalebiId,
                EtkinlikAciklamasi = yayinTalebi.EtkinlikAciklamasi,
                EtkinlikAciklamasiEn = yayinTalebi.EtkinlikAciklamasiEn,
                EtkinlikAciklamasiKisa = yayinTalebi.EtkinlikAciklamasiKisa,
                EtkinlikAciklamasiKisaEn = yayinTalebi.EtkinlikAciklamasiKisaEn,
                EtkinlikAdi = yayinTalebi.EtkinlikAdi,
                EtkinlikAdiEn = yayinTalebi.EtkinlikAdiEn,
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

        [HttpPost]
        public JsonResult SalonlariGetir(string kampusId)
        {
            var filtrelenmisSalonlar = _salonService.TGetList().Where(x => x.KampusId == Convert.ToInt32(kampusId)).ToList();

            return Json(filtrelenmisSalonlar);
        }
    }
}
