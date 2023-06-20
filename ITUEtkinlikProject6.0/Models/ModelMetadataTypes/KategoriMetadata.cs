using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Models.ModelMetadataTypes
{
    public class KategoriMetadata
    {
        public int KategoriId { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz!")]
        [StringLength(100, ErrorMessage = "Lütfen kategori adını en fazla 100 karakter giriniz.")]
        [Remote(action: "KategoriIsExist", controller: "Kategori", ErrorMessage = "Girmiş olduğunuz kategori zaten mevcut!")]
        public string KategoriAdi { get; set; }
    }
}
