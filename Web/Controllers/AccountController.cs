using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;
using Core.Repositories;
using Core.Service;
using Core.ViewModels;
using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        const string SessionUserName = "_userName";
        private readonly IAccountRepository _accountRepository;
        private readonly IDetailRepository _detailRepository;
        private readonly IRepository<User> _userRepository;
        private readonly zumuziDbContext _context;
        public AccountController(IAccountRepository accountRepository, IDetailRepository detailRepository, zumuziDbContext context)
        {
            _accountRepository = accountRepository;
            _detailRepository = detailRepository;
            _userRepository = accountRepository;
            _context = context;
        }

        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(User user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.SignInAsync(user);
                if (result != null)
                {
                    //int userId = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name).UserId;
                    HttpContext.Session.SetString("SessionUser", result.UserName);
                    HttpContext.Session.SetInt32("SessionUserId", result.UserId);
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "kullanıcı adı veya şifre hatalı!");

            }
            return View();

        }

        public async Task<IActionResult> SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(User user, UserDetail userDetail)
        {
            await _userRepository.AddAsync(user);
            userDetail.UserId = user.UserId;
            await _detailRepository.AddAsync(userDetail);
            return RedirectToAction("SignIn", "Account");
        }

        public async Task<IActionResult> SignOUt()
        {
            var logout = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}
