using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EtkinlikManager : IEtkinlikService
    {
        // Managerler, veriler veritabanına gitmeden önce, ilk kontrolün yapıldığı katmandır.

        IEtkinlikDal _etkinlikDal;

        public EtkinlikManager(IEtkinlikDal etkinlikDal)
        {
            // IEtkinlikDal, veritabanındaki etkinlik tablosundaki işlemleri yapan nesnenin referansını tutar.
            _etkinlikDal = etkinlikDal;
        }
        public void Tadd(Etkinlik t)
        {
            _etkinlikDal.Insert(t);   
        }

        public void TDelete(Etkinlik t)
        {
            _etkinlikDal.Delete(t);
        }

        public List<Etkinlik> TGetList()
        {
            return _etkinlikDal.GetList();
        }

        public Etkinlik TGetById(int id)
        {
            return _etkinlikDal.GetByID(id);
        }

        public void TUpdate(Etkinlik t)
        {
            _etkinlikDal.Update(t);
        }
    }
}
