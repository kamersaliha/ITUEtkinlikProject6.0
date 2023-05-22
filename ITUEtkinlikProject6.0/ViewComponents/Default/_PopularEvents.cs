using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.ViewComponents.Default
{
    public class _PopularEvents : ViewComponent
    {
        IKategoriService _kategoriService;
        IEtkinlikService _etkinlikService;

        public _PopularEvents(IKategoriService kategoriService, IEtkinlikService etkinlikService)
        {
            _kategoriService = kategoriService;
            _etkinlikService = etkinlikService;
        }


        public IViewComponentResult Invoke()
        {
            var model = new List<EtkinlikKategoriViewModel>();
            var Etkinlikler = _etkinlikService.TGetList();
            var Kategoriler = _kategoriService.TGetList();
            // Kategori adını eşleştirme işlemi
            foreach (var etkinlik in Etkinlikler)
            {
                var etkinlikKategori = new EtkinlikKategoriViewModel()
                {
                    EtkinlikAciklamasiKisa = etkinlik.EtkinlikAciklamasiKisa,
                    EtkinlikAdi = etkinlik.EtkinlikAdi,
                    EtkinlikSorumlusu = etkinlik.EtkinlikSorumlusu,
                    Resim = etkinlik.Resim,
                    KategoriAdi = Kategoriler.FirstOrDefault(kategori => kategori.KategoriId == etkinlik.KategoriId).KategoriAdi,
                    Kategoriler = Kategoriler,
                    Etkinlikler = Etkinlikler,
                    KategoriId = etkinlik.KategoriId
                };
                model.Add(etkinlikKategori);
            }

            model = Etkinlikler.Select(etkinlik => new EtkinlikKategoriViewModel()
            {
                EtkinlikAciklamasiKisa = etkinlik.EtkinlikAciklamasiKisa,
                EtkinlikAdi = etkinlik.EtkinlikAdi,
                EtkinlikSorumlusu = etkinlik.EtkinlikSorumlusu,
                Resim = etkinlik.Resim,
                KategoriAdi = Kategoriler.FirstOrDefault(kategori => kategori.KategoriId == etkinlik.KategoriId).KategoriAdi,
                Kategoriler = Kategoriler,
                Etkinlikler = Etkinlikler,
                KategoriId = etkinlik.KategoriId,
            }).ToList();

            return View(model);
        }
    }
}

