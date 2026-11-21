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
        private readonly SampleDBContext db = new SampleDBContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        //[HttpPost]
        //public ActionResult Delete(IEnumerable<int> employeesIDsToDelete)
        //{
        //    //db.Employees.RemoveRange(db.Employees.Where(x => employeesIDsToDelete.Contains(x.ID)));
        //    //db.SaveChanges();
        //    //return RedirectToAction("index");
        //    db.Employees.Where(x => employeesIDsToDelete.Contains(x.ID)).ToList().ForEach(x => db.Employees.Remove(x));
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> employeesIDsToDelete)
        {
            if (employeesIDsToDelete != null)
            {
                db.Employees.RemoveRange(db.Employees.Where(x => employeesIDsToDelete.Contains(x.ID)));
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }




    }
}
