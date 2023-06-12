using EntityLayer.Concrete;

namespace ITUEtkinlikProject6._0.Areas.Member.Models
{
    public class SalonViewModel
    {
        public EntityLayer.Concrete.Salon Salon { get; set; }
        public List<Salon> Salonler { get; set; } = new List<Salon>();
        public int SalonId { get; set; }
        public string SalonAdi { get; set; }
        public string SalonIsAdd { get; set; }
    }
}
