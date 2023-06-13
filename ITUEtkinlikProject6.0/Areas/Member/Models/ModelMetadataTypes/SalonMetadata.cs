using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITUEtkinlikProject6._0.Areas.Member.Models.ModelMetadataTypes
{
    public class SalonMetadata
    {
        public int SalonId { get; set; }
        public int KampusId { get; set; }

        [Required(ErrorMessage = "Kampus adı boş bırakılamaz!")]
        public string KampusAdi { get; set; }

        [Required(ErrorMessage = "Salon adı boş bırakılamaz!")]
        [StringLength(100, ErrorMessage = "Lütfen salon adını en fazla 100 karakter giriniz.")]
        public string SalonAdi { get; set; }

        [Required(ErrorMessage = "Salon kapasitesi boş bırakılamaz!")]
        public int SalonKapasitesi { get; set; }
    }
}
