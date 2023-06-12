﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITUEtkinlikProject6._0.Areas.Member.Models.ModelMetadataTypes
{
    public class KampusMetadata
    {
        public int KampusId { get; set; }

        [Required(ErrorMessage = "Kampus adı boş bırakılamaz!")]
        [StringLength(100, ErrorMessage = "Lütfen kampus adını en fazla 100 karakter giriniz.")]
        public string KampusAdi { get; set; }
    }
}
