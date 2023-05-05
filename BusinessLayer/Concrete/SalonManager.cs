using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SalonManager : ISalonService
    {
        ISalonDal _salonDal;

        public SalonManager(ISalonDal salonDal)
        {
            _salonDal = salonDal;
        }
        public void Tadd(Salon t)
        {
            _salonDal.Insert(t);
        }

        public void TDelete(Salon t)
        {
            _salonDal.Delete(t);
        }

        public Salon TGetById(int id)
        {
            return _salonDal.GetByID(id);
        }

        public List<Salon> TGetList()
        {
          return _salonDal.GetList();
        }

        public void TUpdate(Salon t)
        {
            _salonDal.Update(t);
        }
    }
}
