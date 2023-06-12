using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ITUEtkinlikProject6._0.Areas.Member.Models.ModelMetadataTypes
{
    public class KategoriMetadata
    {      
        public int KategoriId { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz!")]
        [StringLength(100, ErrorMessage = "Lütfen kategori adını en fazla 100 karakter giriniz.")]
        public string KategoriAdi { get; set; }
    }
}
