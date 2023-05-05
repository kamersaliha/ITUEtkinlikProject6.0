using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEtkinlikService : IGenericService<Etkinlik>
    {
		// Bu alttakileri tekrar yazmamak için IGenericService'den inherit ettik.
		//void Tadd(T t);
		//void TDelete(T t);
		//void TUpdate(T t);
		//List<T> TGetList();
		//T TGetById(int id);
	}
}
