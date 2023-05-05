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
    public class YayinTalebiManager : IYayinTalebiService
    {
        IYayinTalebiDal _yayinTalebiDal;

        public YayinTalebiManager(IYayinTalebiDal yayinTalebiDal)
        {
            _yayinTalebiDal = yayinTalebiDal;
        }

        public void Tadd(YayinTalebi t)
        {
           _yayinTalebiDal.Insert(t);   
        }

        public void TDelete(YayinTalebi t)
        {
            _yayinTalebiDal.Delete(t);
        }

        public YayinTalebi TGetById(int id)
        {
            return _yayinTalebiDal.GetByID(id);
        }

        public List<YayinTalebi> TGetList()
        {
            return _yayinTalebiDal.GetList();
        }

        public void TUpdate(YayinTalebi t)
        {
            _yayinTalebiDal.Update(t);
        }
    }
}
