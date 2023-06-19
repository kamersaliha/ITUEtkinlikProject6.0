using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kampus
    {
        public int KampusId { get; set; }

        public ICollection<YayinTalebi> YayinTalepleri { get; set; }

        public ICollection<Salon> Salonlar { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string KampusAdi { get; set; }
        public string KampusAdiEn { get; set; }

    }
}
