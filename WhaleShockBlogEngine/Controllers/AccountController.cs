using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WhaleShockBlogEngine.Models;

namespace WhaleShockBlogEngine.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public ActionResult Login()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                var privateKey = rsa.ExportParameters(true);

                // 뷰로 공개키 전달
                ViewBag.Exponent = Convert.ToBase64String(privateKey.Exponent);
                ViewBag.Modulus = Convert.ToBase64String(privateKey.Modulus);
                Session["PrivateKey"] = privateKey;
            }
            return View();
        }

        // POST: /Account/Regist
        [HttpPost]
        public JsonResult Login(AccountModel encrypted)
        {
            string returning = "";

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                if (Session["PrivateKey"] == null)
                {
                    throw new Exception();
                }

                rsa.ImportParameters((RSAParameters)Session["PrivateKey"]);
                var decrypted = rsa.Decrypt(Convert.FromBase64String(encrypted.Hash_Id), false);

                returning = Encoding.UTF8.GetString(decrypted);

                Session["PrivateKey"] = null;
            }

            return Json(returning);
        }

        // Get: /Account/Regist
        public ActionResult Regist()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                var privateKey = rsa.ExportParameters(true);
                
                // 뷰로 공개키 전달
                ViewBag.Exponent = Convert.ToBase64String(privateKey.Exponent);
                ViewBag.Modulus = Convert.ToBase64String(privateKey.Modulus);
                Session["PrivateKey"] = privateKey;
            }

            return View();
        }

        // POST: /Account/Regist
        [HttpPost]
        public JsonResult Regist(AccountModel encrypted)
        {
            string returning = "";

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                if (Session["PrivateKey"] == null)
                {
                    throw new Exception();
                }

                rsa.ImportParameters((RSAParameters)Session["PrivateKey"]);
                var decrypted = rsa.Decrypt(Convert.FromBase64String(encrypted.Hash_Id), false);
                using (SHA256 sha = new SHA256Managed())
                {
                    var hash = sha.ComputeHash(decrypted);
                    //returning = Encoding.UTF8.GetString(hash);
                    returning = Convert.ToBase64String(hash);
                }

                Session["PrivateKey"] = null;
            }

            return Json(returning);
        }
    }
}
