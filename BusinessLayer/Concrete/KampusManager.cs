using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KampusManager : IKampusService
    {
        IKampusDal _kampusDal;

        public KampusManager(IKampusDal kampusDal)
        {
            _kampusDal = kampusDal;
        }

        public void Tadd(Kampus t)
        {
            _kampusDal.Insert(t);
        }

        public void TDelete(Kampus t)
        {
            _kampusDal.Delete(t);
        }

        public Kampus TGetById(int id)
        {
           return _kampusDal.GetByID(id);
        }

        public List<Kampus> TGetList()
        {
            return _kampusDal.GetList();
        }

        public void TUpdate(Kampus t)
        {
            _kampusDal.Update(t);
        }
    }
}
