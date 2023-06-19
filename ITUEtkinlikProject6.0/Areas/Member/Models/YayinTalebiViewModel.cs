using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Areas.Member.Models.ModelMetadataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace ITUEtkinlikProject6._0.Areas.Member.Models
{
    [ModelMetadataType(typeof(YayinTalebiMetadata))]
    public class YayinTalebiViewModel
    {
        public EntityLayer.Concrete.YayinTalebi YayinTalebi { get; set; }

        public List<Kampus> Kampusler { get; set; } = new List<Kampus>();

        public List<Salon> Salonlar { get; set; } = new List<Salon>();
    
        public List<Kategori> Kategoriler { get; set; } = new List<Kategori>();

        public List<YayinTalebi> YayinTalepleri { get; set; } = new List<YayinTalebi>();

        public int YayinTalebiId { get; set; }

        public string EtkinlikAdi { get; set; }
        public string EtkinlikAdiEn { get; set; }

        public int SalonId { get; set; }
        public string SalonAdi { get; set; }

        public int KampusId { get; set; }

        public string KampusAdi { get; set; }

        public int? KatilimciSayisi { get; set; }

        public Durumlar? Durum { get; set; }

        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
       
        public string EtkinlikAciklamasi { get; set; }
        public string EtkinlikAciklamasiEn { get; set; }

        public string EtkinlikAciklamasiKisa { get; set; }
        public string EtkinlikAciklamasiKisaEn { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }

        public string YayinTalebiIsAdd { get; set; }

    }
}
