using Database_connect.db_context;
using Database_connect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Database_connect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult tables()
        {
            EmployeeContext obj = new EmployeeContext();
            var res = obj.EmpDetails.ToList();

            return View(res);
            
        }
        [HttpGet]
        public IActionResult SetTable()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetTable(EmployeeClass obcj)
        {
            EmployeeContext obj = new EmployeeContext();
            EmpDetail cbj = new EmpDetail();

            cbj.Name = obcj.Name;
            cbj.EmailId=obcj.EmailId;
            cbj.PhoneNo= obcj.PhoneNo;
            //if (obcj.Id == 0)
            //{
                obj.EmpDetails.Add(cbj);
                obj.SaveChanges();
            //}
            //else
            //{

            //    obj.Entry(cbj).State = System.Data.Entity.EntityState.Modified;
            //    obj.SaveChanges();
            //}

            //return RedirectToAction("tables");
            return View();
        }
        public IActionResult Delete(int id)
        {
            EmployeeContext Db = new EmployeeContext();
            var deleteitem = Db.EmpDetails.Where(m => m.Id == id).First();
            Db.EmpDetails.Remove(deleteitem);
            Db.SaveChanges();
            return RedirectToAction("tables");
            
        }

        //public IActionResult edit(int id)
        //{

        //    EmployeeClass objEmp = new EmployeeClass();
        //    EmployeeContext Db = new EmployeeContext();
        //        var EditItem = Db.EmpDetails.Where(m => m.Id == id).First();

        //        objEmp.Id = EditItem.Id;
        //        objEmp.Name = EditItem.Name;
        //        objEmp.EmailId = EditItem.EmailId;
        //        objEmp.PhoneNo = EditItem.PhoneNo;
                

        //        ViewBag.Id = EditItem.Id;

        //        return View("SetTable", objEmp);
        //    }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
