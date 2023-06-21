using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Models.ModelMetadataTypes;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Models
{
    [ModelMetadataType(typeof(KampusMetadata))]
    public class KampusViewModel
    {
        public EntityLayer.Concrete.Kampus Kampus { get; set; }
        public List<Kampus> Kampusler { get; set; } = new List<Kampus>();
        public int KampusId { get; set; }
        public string KampusAdi { get; set; }
        public string KampusAdiEn { get; set; }
        public string KampusIsAdd { get; set; }
    }
}
