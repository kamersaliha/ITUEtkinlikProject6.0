using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITUEtkinlikProject6._0.Areas.Member.Models.ModelMetadataTypes
{
    public class YayinTalebiMetadata
    {
        public int YayinTalebiId { get; set; }

        [Required(ErrorMessage = "Etkinlik adı boş bırakılamaz!")]
        [StringLength(100, ErrorMessage = "Etkinlik adı 5 ile 100 karakter arasında olmalıdır!", MinimumLength =5)]
        public string EtkinlikAdi { get; set; }

        [Required(ErrorMessage = "Lütfen etkinlik salonu seçiniz!")]
        public int? SalonId { get; set; }

        [Required(ErrorMessage = "Lütfen etkinlik salonu seçiniz!")]
        public string SalonAdi { get; set; }
        public int KampusId { get; set; }

        [Required(ErrorMessage = "Katılımcı sayısı boş bırakılamaz!")]
        public int? KatilimciSayisi { get; set; }

        public Durumlar? Durum { get; set; }

        [Required(ErrorMessage = "Lütfen etkinlik kategorisi seçiniz!")]
        public int KategoriId { get; set; }

        [Required(ErrorMessage = "Etkinlik açıklaması boş olamaz!")]
        [StringLength(500, ErrorMessage = "Etkinlik açıklaması 100 ile 500 karakter arasında olmalıdır!", MinimumLength = 100)]
        public string EtkinlikAciklamasi { get; set; }

        [Required(ErrorMessage = "Kısa etkinlik açıklaması boş olamaz!")]
        [StringLength(300, ErrorMessage = "Etkinlik açıklaması 10 ile 300 karakter arasında olmalıdır!", MinimumLength = 10)]
        public string EtkinlikAciklamasiKisa { get; set; }

        [Required(ErrorMessage = "Lütfen etkinlik başlangıç tarihi seçiniz!")]
        public DateTime BaslangicTarihi { get; set; }

        [Required(ErrorMessage = "Lütfen etkinlik bitiş tarihi seçiniz!")]
        public DateTime BitisTarihi { get; set; }
    }
}
