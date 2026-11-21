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
            return View(db.Employees.ToList());
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> employeesIDsToDelete)
        {
            db.Employees.RemoveRange(db.Employees.Where(x => employeesIDsToDelete.Contains(x.ID)));
            db.SaveChanges();
            return RedirectToAction("index");
            
        } 
    }
}