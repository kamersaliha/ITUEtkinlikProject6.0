using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class EtkinlikValidator : AbstractValidator<Etkinlik>
    {
        public EtkinlikValidator()
        {
            RuleFor(x => x.EtkinlikAdi).NotEmpty().WithMessage("Etkinlik Adı kısmını boş geçemezsiniz!");
            RuleFor(x => x.Kategoriler).NotEmpty().WithMessage("Kategori kısmını boş geçemezsiniz!");
            RuleFor(x => x.EtkinlikAdi).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik etkinlik adı giriniz!");
        }
    }
}
