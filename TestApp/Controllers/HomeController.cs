using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using TestApp.Utilities;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Home()
        {
            return View();

        }

        public IActionResult Register(Student student)
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForRegister(Student student)
        {
            StudentAppContext Dbcontext = new StudentAppContext();
            Student sdt = new Student();
            sdt.FirstName = student.FirstName;
            sdt.LastName = student.LastName;
            sdt.Age = student.Age;
            sdt.Department = student.Department;
            sdt.Address = student.Address;
            sdt.City = student.City;
            sdt.Mail = student.Mail;
            sdt.Phone = student.Phone;

            SendMail mail = new SendMail();
            string pass = mail.SendEmail(student.Mail);
            sdt.Password = pass;


            Dbcontext.Add(sdt);
            Dbcontext.SaveChanges();

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForLogin(string email,string password)
        {

            StudentAppContext dbContext = new StudentAppContext();
            string Email = email;

            string Password = password;
            var userlist = dbContext.Students.ToList();
            var user = userlist.Where(X => X.Mail == email && X.Password == password).FirstOrDefault();

            if (user != null)
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