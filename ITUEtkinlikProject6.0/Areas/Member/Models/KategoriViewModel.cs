using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Areas.Member.Models.ModelMetadataTypes;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Areas.Member.Models
{
    [ModelMetadataType(typeof(KategoriMetadata))]
    public class KategoriViewModel
    {
        public EntityLayer.Concrete.Kategori Kategori { get; set; }
        public List<Kategori> Kategoriler { get; set; } = new List<Kategori>();
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriAdiEn { get; set; }
        public string KategoriIsAdd { get; set; }
    }
}
