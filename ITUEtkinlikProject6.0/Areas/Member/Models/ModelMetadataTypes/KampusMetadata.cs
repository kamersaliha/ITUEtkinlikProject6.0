using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Areas.Member.Models.ModelMetadataTypes
{
    public class KampusMetadata
    {
        public int KampusId { get; set; }

        [Required(ErrorMessage = "Kampüs adı boş bırakılamaz!")]
        [StringLength(100, ErrorMessage = "Lütfen kampus adını en fazla 100 karakter giriniz.")]
        [Remote(action: "KampusIsExist", controller: "Kampus", ErrorMessage = "Girmiş olduğunuz kampüs zaten mevcut!")]
        public string KampusAdi { get; set; }
        [Required(ErrorMessage = "İngilizce kampüs adı boş bırakılamaz!")]
        [StringLength(100, ErrorMessage = "Lütfen kampüs adını en fazla 100 karakter giriniz.")]
        public string KampusAdiEn { get; set; }

    }
}

