using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFundamentals.Models;

namespace MVCFundamentals.Controllers
{
    public class HomeController : Controller
    {
        SampleDBContext db = new SampleDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult All()
        {
            System.Threading.Thread.Sleep(5000);

            List<Student> model = db.Students.ToList();
            return PartialView("_student", model);   // partial view : model
        }

        public PartialViewResult Top5()
        {
            System.Threading.Thread.Sleep(5000);

            List<Student> model = db.Students.OrderByDescending(x => x.TotalMarks).Take(5).ToList();
            return PartialView("_student", model);
        }

        public PartialViewResult Bottom5()
        {
            System.Threading.Thread.Sleep(5000);

            List<Student> model = db.Students.OrderBy(x => x.TotalMarks).Take(5).ToList();
            return PartialView("_student", model);
        }
    }
}