using BusinessLayer.Abstract;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITUEtkinlikProject6._0.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        IKategoriService _kategoriService;
        IEtkinlikService _etkinlikService;

        public _SliderPartial(IKategoriService kategoriService, IEtkinlikService etkinlikService)
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
                    KategoriAdi = Kategoriler.FirstOrDefault(kategori => kategori.KategoriId == etkinlik.KategoriId).KategoriAdi,
                    Kategoriler = Kategoriler,
                    Etkinlikler = Etkinlikler,
                    KategoriId = etkinlik.KategoriId
                };
                model.Add(etkinlikKategori);
            }
            return View(model);
        }
    }
    
}
