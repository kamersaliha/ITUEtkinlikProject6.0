using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class YayinTalebi
    {
        [Key]
        public int YayinTalebiId { get; set; }

        //public int AppUserId { get; set; }

        //public virtual AppUser AppUsers { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string EtkinlikAdi { get; set; }

        public int KampusId { get; set; }

        [ForeignKey("KampusId")]
        public virtual Kampus Kampus { get; set; }

        public int SalonId { get; set; }

        [ForeignKey("SalonId")]
        public virtual Salon Salonlar { get; set; }

        public int? KatilimciSayisi { get; set; }

        public int KategoriId { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategori Kategoriler { get; set; }

        public Durumlar? Durumu { get; set; }

        [Column(TypeName = "nvarchar(600)")]
        public string? EtkinlikAciklamasi { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? EtkinlikAciklamasiKisa { get; set; }

        public string? UcretBilgisi { get; set; }

        public DateTime? BaslangicTarihi { get; set; }

        public DateTime? BitisTarihi { get; set; }

        public string? Resim { get; set; }
    }
}
public enum Durumlar{

    onaylanmış = 1,

    reddedildi = -1,

    beklemede = 0,

    suresi_gecmis = 2
}
