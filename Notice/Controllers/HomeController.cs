using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notice.Models;

namespace Notice.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db;
        bool havenewmessage;
        string newmessage;

        public HomeController()
        {
            db = new UserContext();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }      
        [HttpPost]
        public ActionResult Enter(string Name, string Password)
        {
            var user = db.Users.FirstOrDefault(t=>t.Name==Name);
            if (user == null)
            {
                User newuser = new User();
                newuser.Name = Name;
                newuser.Password = Password;
                db.Users.Add(newuser);
                db.SaveChanges();
            }
            return View("SendMessage");
        }//Регистрация пользователя

        [HttpPost]
        public void Send(string message)
        {
            Message newmessage = new Message();
            newmessage.TextMessage = message;
            newmessage.TimeMessage = DateTime.Now.Date.ToString();
            db.Messages.Add(newmessage);
            db.SaveChanges();
            havenewmessage = true;
            this.newmessage = message;
        }//Получение сообщения и запись в базу

        public string GetData()
        {
            return "3";
        }
    }
}