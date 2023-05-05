using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfEtkinlikDal : GenericRepository<Etkinlik>, IEtkinlikDal
    {
        // EfEtkinlikDal direkt olarak veritabanıyla etkileşim kuran nesneyi temsil etmektedir.
        // Bunun sebebi, veritabanıyla etkileşim kurabilen, genericRepository'den inherit almasıdır.
        // Buraya IEtkinlikDal yazılmasının sebebi, interface'ler referans tutar.
    }
}
