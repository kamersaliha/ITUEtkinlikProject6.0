using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        //IKategoriService _kategoriService;
        //IEtkinlikService _etkinlikService;

        //public DefaultController(IKategoriService kategoriService, IEtkinlikService etkinlikService)
        //{
        //    _kategoriService = kategoriService;
        //    _etkinlikService = etkinlikService;
        //}


        [HttpGet]
		public IActionResult Index()
        {
            //var model = new List<EtkinlikKategoriViewModel>();
            //var Etkinlikler = _etkinlikService.TGetList();
            //var Kategoriler = _kategoriService.TGetList();
            //// Kategori adını eşleştirme işlemi
            //foreach (var etkinlik in Etkinlikler)
            //{
            //    var etkinlikKategori = new EtkinlikKategoriViewModel()
            //    {
            //        EtkinlikAciklamasiKisa = etkinlik.EtkinlikAciklamasiKisa,
            //        EtkinlikAdi = etkinlik.EtkinlikAdi,
            //        EtkinlikSorumlusu = etkinlik.EtkinlikSorumlusu,
            //        Resim = etkinlik.Resim,
            //        KategoriAdi = Kategoriler.FirstOrDefault(kategori => kategori.KategoriId == etkinlik.KategoriId).KategoriAdi,
            //        Kategoriler = Kategoriler,
            //        Etkinlikler = Etkinlikler,
            //        KategoriId = etkinlik.KategoriId
            //    };
            //    model.Add(etkinlikKategori);
            //}

            //model = Etkinlikler.Select(etkinlik => new EtkinlikKategoriViewModel()
            //{
            //    EtkinlikAciklamasiKisa = etkinlik.EtkinlikAciklamasiKisa,
            //    EtkinlikAdi = etkinlik.EtkinlikAdi,
            //    EtkinlikSorumlusu = etkinlik.EtkinlikSorumlusu,
            //    Resim = etkinlik.Resim,
            //    KategoriAdi = Kategoriler.FirstOrDefault(kategori => kategori.KategoriId == etkinlik.KategoriId).KategoriAdi,
            //    Kategoriler = Kategoriler,
            //    Etkinlikler = Etkinlikler,
            //    KategoriId = etkinlik.KategoriId,
            //}).ToList();


            return View();
        }
    }
}
