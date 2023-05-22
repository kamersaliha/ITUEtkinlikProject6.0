using EntityLayer.Concrete;

namespace ITUEtkinlikProject6._0.Models
{
    public class EtkinlikKategoriViewModel
    {
        public List<Kategori> Kategoriler { get; set; }

        public List<Etkinlik> Etkinlikler { get; set; }

        public string KategoriAdi { get; set; }

        public string EtkinlikAdi { get; set; }

        public string EtkinlikSorumlusu { get; set; }

        public string EtkinlikAciklamasiKisa { get; set; }

        public int KategoriId { get; set; }

        public string Resim { get; set; }
       
    }
}
