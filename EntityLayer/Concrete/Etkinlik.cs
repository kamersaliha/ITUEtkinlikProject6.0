using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Etkinlik
    {
        [Key]
        public int EtkinlikId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string EtkinlikAdi { get; set; }
        public string EtkinlikAdiEn { get; set; }
        public int SalonId { get; set; }
        public virtual Salon Salonlar { get; set; }
        public int KatilimciSayisi { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategoriler { get; set; }
        public Durumlar Durumu { get; set; }
        public string EtkinlikAciklamasi { get; set; }
        public string EtkinlikAciklamasiEn { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string EtkinlikAciklamasiKisa { get; set; }
        public string EtkinlikAciklamasiKisaEn { get; set; }
        public string UcretBilgisi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Resim { get; set; }
        public string EtkinlikSorumlusu { get; set; }
    }
}
