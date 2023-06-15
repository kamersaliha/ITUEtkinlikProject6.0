using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    [Route("Member/[controller]/[action]")]
    public class KategoriController : Controller
    {
        IKategoriService _kategoriService;
        public KategoriController (IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
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
            if (!ModelState.IsValid) 
            {
                var messages = ModelState.ToList();
            }
            _kategoriService.Tadd(kategori);
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
                    KategoriAdi = item.KategoriAdi
                };
                model.Add(kategori);
            }
            return View(model);
        }

        public IActionResult DeleteKategori(int kategoriId)
        {
            Kategori kategori = _kategoriService.TGetList().FirstOrDefault(x=>x.KategoriId == kategoriId);
            if(kategori != null)
            {
                _kategoriService.TDelete(kategori);
            }
            return RedirectToAction("CurrentKategori");
        }

        [HttpGet]
        public IActionResult UpdateKategori(int kategoriId)
        {
            var kategoriService = _kategoriService.TGetById(kategoriId);

            var model = new KategoriViewModel()
            {
                KategoriId = kategoriService.KategoriId,
                KategoriAdi=kategoriService.KategoriAdi
            };
            model.KategoriIsAdd = "Düzenle";

            return View("NewKategori", model);
        }

        [HttpPost]
        public IActionResult UpdateKategori(KategoriViewModel kategoriCommand)
        {
            var kategori = _kategoriService.TGetList().FirstOrDefault(x=>x.KategoriId==kategoriCommand.KategoriId);
            kategori.KategoriAdi = kategoriCommand.KategoriAdi;
            _kategoriService.TUpdate(kategori);
            return RedirectToAction("CurrentKategori");
        }

        


    }
}
