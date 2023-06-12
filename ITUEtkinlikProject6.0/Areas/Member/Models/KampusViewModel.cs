using EntityLayer.Concrete;

namespace ITUEtkinlikProject6._0.Areas.Member.Models
{
    public class KampusViewModel
    {
        public EntityLayer.Concrete.Kampus Kampus { get; set; }
        public List<Kampus> Kampusler { get; set; } = new List<Kampus>();
        public int KampusId { get; set; }
        public string KampusAdi { get; set; }
        public string KampusIsAdd { get; set; }
    }
}
