using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        EmpManagementEntities DB = new EmpManagementEntities();
        // GET: Home
        public ActionResult Index(string search)
        {
            var data = DB.Employees.ToList();
            if(search != null)
            {
                data = data.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search)).ToList(); ;
            }
            return View(data);
        }
        public ActionResult Details(int id)
        {
            var data = DB.Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if(ModelState.IsValid)
            {
                DB.Employees.Add(emp);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(Employee emp)
        {
            var data = DB.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
            DB.Employees.Remove(data);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = DB.Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var data = DB.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
                data.FirstName = emp.FirstName;
                data.LastName = emp.LastName;
                data.Email = emp.Email;
                data.Phone = emp.Phone;
                data.DateOfBirth = emp.DateOfBirth;
                data.Position = emp.Position;
                data.Salary = emp.Salary;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Errro working on your edit");
            }
            return View();
        }
    }
}