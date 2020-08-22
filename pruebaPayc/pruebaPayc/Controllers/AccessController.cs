using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pruebaPayc.Models;
using System.Security.Cryptography;
using System.Text;

namespace pruebaPayc.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entrar(string email, string pass)
        {
            string encryptPass = Encrypt.GetSHA256(pass);
            
            using ( pruebaPaycEntities db = new pruebaPaycEntities())
            {
                var chk = from usr in db.user
                          where usr.email == email && usr.password == encryptPass
                          select usr;
                if(chk.Count() > 0)
                {
                    return Content("1");
                }
                else
                {
                    return Content("0");
                }
            }
            
        }
    }
}