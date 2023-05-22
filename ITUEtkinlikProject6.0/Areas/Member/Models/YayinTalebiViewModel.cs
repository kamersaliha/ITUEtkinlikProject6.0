using EntityLayer.Concrete;

namespace ITUEtkinlikProject6._0.Areas.Member.Models
{
    public class YayinTalebiViewModel
    {
        public EntityLayer.Concrete.YayinTalebi YayinTalebi { get; set; }

        public List<Kampus> Kampusler { get; set; } = new List<Kampus>();

        public List<Salon> Salonlar { get; set; } = new List<Salon>();
    
        public List<Kategori> Kategoriler { get; set; } = new List<Kategori>();
    }
}
