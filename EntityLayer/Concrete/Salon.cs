using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Salon
    {
        public virtual ICollection<Etkinlik> Etkinlikler { get; set; }
        public virtual ICollection<YayinTalebi> YayinTalepleri { get; set; }

        [Key]
        public int SalonId { get; set; }

        public int KampusId { get; set; }

        [ForeignKey("KampusId")]
        public virtual Kampus Kampusler { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string SalonAdi { get; set; }
        public string SalonAdiEn { get; set; }
        public int SalonKapasitesi { get; set; }
    }
}
