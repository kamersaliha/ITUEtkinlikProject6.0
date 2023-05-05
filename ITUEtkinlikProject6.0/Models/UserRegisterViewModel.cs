using System.ComponentModel.DataAnnotations;

namespace ITUEtkinlikProject6._0.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage="Lütfen adınızı giriniz")]
        public string Ad { get; set; }

		[Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
		public string Soyad { get; set; }

		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
		public string KullaniciAdi { get; set; }

		[Required(ErrorMessage = "Lütfen mail adresinizi giriniz")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
		public string Sifre { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz")]
		[Compare("Sifre",ErrorMessage ="Şifreler uyumlu değil!")]
		public string SifreDogrulama { get; set; }
	}
}
