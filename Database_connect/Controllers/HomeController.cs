using Database_connect.db_context;
using Database_connect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<EmployeeClass> empobj = new List<EmployeeClass>();
            var res = obj.EmpDetails.ToList();

            foreach (var item in res)
            {
                empobj.Add(new EmployeeClass
                {
                    Id = item.Id,
                    Name = item.Name,
                    EmailId = item.EmailId,
                    PhoneNo= item.PhoneNo,
                });


            }

            return View(empobj);

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

            cbj.Id = obcj.Id;
            cbj.Name = obcj.Name;
            cbj.EmailId=obcj.EmailId;
            cbj.PhoneNo= obcj.PhoneNo;
            if (obcj.Id == 0)
            {
                obj.EmpDetails.Add(cbj);
                obj.SaveChanges();
                
            }
            else
            {

                obj.Entry(cbj).State = EntityState.Modified;
                obj.SaveChanges();
                
            }
            return RedirectToAction("privacy");


            //return View();
        }
        public IActionResult Delete(int id)
        {
            EmployeeContext Db = new EmployeeContext();
            var deleteitem = Db.EmpDetails.Where(m => m.Id == id).First();
            Db.EmpDetails.Remove(deleteitem);
            Db.SaveChanges();
            return RedirectToAction("tables");            
        }

        public IActionResult edit(int id)
        {

            EmployeeClass objEmp = new EmployeeClass();
            EmployeeContext Db = new EmployeeContext();
            var editItem = Db.EmpDetails.Where(m => m.Id == id).First();

            objEmp.Id = editItem.Id;
            objEmp.Name = editItem.Name;
            objEmp.EmailId = editItem.EmailId;
            objEmp.PhoneNo = editItem.PhoneNo;


            //ViewBag.Id = EditItem.Id;

            return View("SetTable", objEmp);
        }

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
