using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLinkedInProfile.Model;

namespace MyLinkedInProfile.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepoContext _context;

        public HomeController(UserRepoContext context)
        {
            _context = context;
        }
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserInfoModel userInfos)
        {
            var user = _context.UserInfos.Where(w => w.UserName == userInfos.UserName && w.Password == userInfos.Password).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserName", user.UserName);
                return this.RedirectToActionPermanent("Profile");
            }

            ViewBag.Message = string.Format("Hatalı şifre");
            return View();
        }

        [HttpGet]
        public ActionResult NewAccount(UserInfoModel userInfos)
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAccountCreate(UserInfoModel userInfos)
        {
            if (userInfos.Password==null || userInfos.Password == null)
            {
                ViewBag.Message = string.Format("Kullanıcı adı veya şifre giriniz...");
                return View("NewAccount");
            }
            _context.UserInfos.Add(userInfos);
            _context.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ViewResult Profile()
        {
            int userId = Int32.Parse(HttpContext.Session.GetString("UserId"));
            var edu = _context.Educations.Where(w => w.UserId == userId).FirstOrDefault();
            return View(edu);
        }

        [HttpPost]
        public ActionResult ProfileAddOrEdit(EducationModel educationInfos)
        {
            int userId = Int32.Parse(HttpContext.Session.GetString("UserId"));
            if (_context.Educations.Any(a => a.UserId == userId))
            {
                var user =_context.Educations.Where(w => w.UserId == userId).FirstOrDefault();
                user.HighScool = educationInfos.HighScool;
                user.University = educationInfos.University;
                user.Master = educationInfos.Master;
                _context.SaveChanges();
            }
            else
            {
                educationInfos.UserId = userId;
                _context.Educations.Add(educationInfos);
                _context.SaveChanges();
            }

            return View("Profile");
        }

    }
}