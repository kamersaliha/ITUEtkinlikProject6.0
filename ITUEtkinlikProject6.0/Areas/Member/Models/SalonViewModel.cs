using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Areas.Member.Models.ModelMetadataTypes;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Areas.Member.Models
{
    [ModelMetadataType(typeof(SalonMetadata))]
    public class SalonViewModel
    {
        public EntityLayer.Concrete.Salon Salon { get; set; }
        public List<Salon> Salonlar { get; set; } = new List<Salon>();
        public List<Kampus> Kampusler { get; set; } = new List<Kampus>();
        public int SalonId { get; set; }
        public int KampusId { get; set; }
        public string KampusAdi { get; set; }
        public string SalonAdi { get; set; }

        public int SalonKapasitesi { get; set; }
        public string SalonIsAdd { get; set; }
    }
}
