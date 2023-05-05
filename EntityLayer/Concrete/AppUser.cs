﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        //public string ResimUrl { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        //public string Cinsiyet { get; set; }
        public ICollection<YayinTalebi> YayinTalepleri { get; set; }
    }
}
