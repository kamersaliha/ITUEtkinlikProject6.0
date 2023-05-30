using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class YayinTalebiValidator : AbstractValidator<YayinTalebi>
    {
        public YayinTalebiValidator() 
        {
            RuleFor(x => x.EtkinlikAdi).NotNull().WithMessage("Etkinlik adı boş olamaz!").MaximumLength(100).WithMessage("Etkinlik adını 100 karakterden fazla girmeyiniz!").MinimumLength(5).WithMessage("Etkinlik adını 5 karakterden az girmeyiniz!");

            //RuleFor(x => x.KampusId).NotNull().WithMessage("Lütfen kampüs seçiniz!");

            RuleFor(x => x.SalonId).NotNull().WithMessage("Lütfen etkinlik salonu seçiniz!");

            RuleFor(x => x.KategoriId).NotNull().WithMessage("Lütfen etkinlik kategorisi seçiniz!");

            RuleFor(x => x.KatilimciSayisi).NotNull().WithMessage("Lütfen katılımcı sayısı giriniz!").Must(BeNumeric).WithMessage("Katılımcı sayısı sadece rakamlardan oluşmalıdır!");

            RuleFor(x => x.BaslangicTarihi).Must(x => x > DateTime.Now).WithMessage("Etkinlik başlangıç zamanı ileri tarihli olmalıdır!");

            RuleFor(x => x.BitisTarihi).GreaterThan(x => x.BaslangicTarihi).WithMessage("Etkinlik bitiş zamanı başlangıç zamanından sonra olmalıdır!");

            RuleFor(x => x.EtkinlikAciklamasiKisa).NotNull().WithMessage("Kısa etkinlik açıklaması boş olamaz!").MaximumLength(300).WithMessage("Kısa etkinlik açıklamasını 300 karakterden fazla girmeyiniz!").MinimumLength(50).WithMessage("Kısa etkinlik açıklamasını 50 karakterden az girmeyiniz!");

            RuleFor(x => x.EtkinlikAciklamasi).NotNull().WithMessage("Etkinlik açıklaması boş olamaz!").MaximumLength(500).WithMessage("Etkinlik açıklamasını 500 karakterden fazla girmeyiniz!").MinimumLength(200).WithMessage("Etkinlik açıklamasını 200 karakterden az girmeyiniz!");

            bool BeNumeric(int? value)
            {
                if (value == null)
                    return false;

                string strValue = value.ToString();
                return int.TryParse(strValue, out _);
            }
        }
    }
}
