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
    public class KategoriManager : IKategoriService
    {
        IKategoriDal _kategoriDal;

        public KategoriManager(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;
        }
        public void Tadd(Kategori t)
        {
            _kategoriDal.Insert(t);
        }

        public void TDelete(Kategori t)
        {
          _kategoriDal.Delete(t);
        }

        public Kategori TGetById(int id)
        {
           return _kategoriDal.GetByID(id);
        }

        public List<Kategori> TGetList()
        {
          return _kategoriDal.GetList();
        }

        public void TUpdate(Kategori t)
        {
            _kategoriDal.Update(t);
        }
    }
}
