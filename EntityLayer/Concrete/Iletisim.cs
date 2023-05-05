using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Iletisim
    {
        [Key]
        public int IletisimId { get; set; }
        public string Aciklama { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Harita { get; set; }
        public string BirimAdi { get; set;}
        public string Aciklama2 { get; set; }
    }
}
