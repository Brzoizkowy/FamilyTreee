using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyTree.Models;
using System.Security.Cryptography;

namespace FamilyTree.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using(OurDbContext db = new OurDbContext())
            {
                return View(db.userAccount.ToList());
            }
            return View();
        }

        public ActionResult Register()
        {
        
            if (Session["UserId"] != null)
            {
                return RedirectToAction("LoggedIn");

            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Register(UserAccount userAccount)
        {
                using (OurDbContext db = new OurDbContext())
                {
                    System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    byte[] bs = System.Text.Encoding.UTF8.GetBytes(userAccount.Password);
                    bs = x.ComputeHash(bs);
                    System.Text.StringBuilder s = new System.Text.StringBuilder();
                    foreach (byte b in bs)
                    {
                        s.Append(b.ToString("x2").ToLower());
                    }
                    userAccount.Password = s.ToString();

                    db.userAccount.Add(userAccount);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = userAccount.Email + " succesfully registered.";
           
            return View();
        }

        //Login
        public ActionResult Login()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("LoggedIn");
              
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bs = System.Text.Encoding.UTF8.GetBytes(user.Password);
                bs = x.ComputeHash(bs);
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                foreach (byte b in bs)
                {
                    s.Append(b.ToString("x2").ToLower());
                }
                user.Password = s.ToString();


                var usr = db.userAccount.Single(u => u.Email == user.Email && u.Password == user.Password);
                if(usr !=null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["Email"] = usr.Email.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is wrong.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}