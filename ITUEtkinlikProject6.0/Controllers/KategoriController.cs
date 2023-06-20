using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ITUEtkinlikProject6._0.Controllers
{
    [AllowAnonymous]
    public class KategoriController : Controller
    {
        IKategoriService _kategoriService;
        IToastNotification _toast;
        public KategoriController(IKategoriService kategoriService, IToastNotification toast)
        {
            _kategoriService = kategoriService;
            _toast = toast;
        }

        [HttpGet]
        public IActionResult NewKategori()
        {
            var model = new KategoriViewModel();
            List<Kategori> Kategoriler = _kategoriService.TGetList();
            model.Kategoriler = Kategoriler;
            model.KategoriIsAdd = "Ekle";

            return View(model);
        }

        [HttpPost]
        public IActionResult NewKategori(KategoriViewModel p)
        {
            var kategori = new Kategori();
            kategori.KategoriId = p.KategoriId;
            kategori.KategoriAdi = p.KategoriAdi;
            kategori.KategoriAdiEn = p.KategoriAdiEn;
            if (kategori == null)
            {
                _toast.AddErrorToastMessage("Kategori eklenemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _kategoriService.Tadd(kategori);
            _toast.AddSuccessToastMessage("Kategori başarıyla eklendi!", new ToastrOptions { Title = "Başarılı!" });

            return RedirectToAction("CurrentKategori");
        }

        public IActionResult CurrentKategori()
        {
            var model = new List<KategoriViewModel>();
            var kategoriler = _kategoriService.TGetList();

            foreach (var item in kategoriler)
            {
                var kategori = new KategoriViewModel()
                {
                    Kategoriler = kategoriler,
                    KategoriId = item.KategoriId,
                    KategoriAdi = item.KategoriAdi,
                    KategoriAdiEn = item.KategoriAdiEn,
                };
                model.Add(kategori);
            }
            return View(model);
        }

        public IActionResult DeleteKategori(int kategoriId)
        {
            Kategori kategori = _kategoriService.TGetList().FirstOrDefault(x => x.KategoriId == kategoriId);
            if (kategori == null)
            {
                _toast.AddErrorToastMessage("Kategori silinemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _kategoriService.TDelete(kategori);
            _toast.AddSuccessToastMessage("Kategori başarıyla silindi!", new ToastrOptions { Title = "Başarılı!" });

            return RedirectToAction("CurrentKategori");
        }

        [HttpGet]
        public IActionResult UpdateKategori(int kategoriId)
        {
            var kategoriService = _kategoriService.TGetById(kategoriId);

            var model = new KategoriViewModel()
            {
                KategoriId = kategoriService.KategoriId,
                KategoriAdi = kategoriService.KategoriAdi,
                KategoriAdiEn = kategoriService.KategoriAdiEn
            };
            model.KategoriIsAdd = "Düzenle";

            return View("NewKategori", model);
        }

        [HttpPost]
        public IActionResult UpdateKategori(KategoriViewModel kategoriCommand)
        {
            var kategori = _kategoriService.TGetList().FirstOrDefault(x => x.KategoriId == kategoriCommand.KategoriId);
            kategori.KategoriAdi = kategoriCommand.KategoriAdi;
            kategori.KategoriAdiEn = kategoriCommand.KategoriAdiEn;
            if (kategori == null)
            {
                _toast.AddErrorToastMessage("Kategori güncellenemedi!", new ToastrOptions { Title = "Başarısız!" });
            }
            _kategoriService.TUpdate(kategori);
            _toast.AddSuccessToastMessage("Kategori başarıyla güncellendi!", new ToastrOptions { Title = "Başarılı!" });

            return RedirectToAction("CurrentKategori");
        }

        public JsonResult KategoriIsExist(string KategoriAdi)
        {
            var kategoriAdi = _kategoriService.TGetList().Where(k => k.KategoriAdi == KategoriAdi).SingleOrDefault();
            if (kategoriAdi != null)
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
