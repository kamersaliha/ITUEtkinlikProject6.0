using Microsoft.AspNetCore.Identity;

namespace ITUEtkinlikProject6._0.Models
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        //Kayıt ekranında girilen bilgilerin yeterliliği konusundaki uyarıları IdentityErrorDescriber class'ını kullanarak türkçeleştirdik.
        public override IdentityError PasswordTooShort(int length) 
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola minimum {length} karakter olmalıdır"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Parola en az 1 büyük harf içermelidir."
            };

        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Parola en az 1 küçük harf içermelidir."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola en az 1 sembol içermelidir."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresDigit",
                Description = $"Parola en az 1 rakam içermelidir ('0'.'9')."
            };
        }

    }
}
