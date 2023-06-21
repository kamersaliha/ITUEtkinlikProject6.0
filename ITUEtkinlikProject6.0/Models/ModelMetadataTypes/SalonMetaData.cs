using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Models.ModelMetadataTypes
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
        [Range(1, 5000000, ErrorMessage = "Salon kapasitesini tekrar giriniz")]
        public int SalonKapasitesi { get; set; }
    }
}

