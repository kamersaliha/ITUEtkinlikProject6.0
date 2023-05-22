using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }

        public ICollection<Etkinlik> Etkinlikler { get; set; }
        public ICollection<YayinTalebi> YayinTalepleri { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string KategoriAdi { get; set; }
    }
}
