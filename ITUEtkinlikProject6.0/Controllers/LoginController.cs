﻿using EntityLayer.Concrete;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITUEtkinlikProject6._0.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                Ad = p.Ad,
                Soyad = p.Soyad,
                Email = p.Mail,
                UserName = p.KullaniciAdi

            };
            if(p.Sifre == p.SifreDogrulama)
            {
                var result = await _userManager.CreateAsync(appUser, p.Sifre);
                if(result.Succeeded) 
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> SignIn(UserSignInViewModel p)
        {
            if(ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(p.KullaniciAdi, p.Sifre, false, true);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new {area="Member"});
                  }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();

        }
    }
}


