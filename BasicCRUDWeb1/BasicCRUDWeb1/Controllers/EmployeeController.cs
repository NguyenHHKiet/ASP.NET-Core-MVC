using BasicCRUDWeb1.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BasicCRUDWeb1.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer employeeDataAccessLayer = null;
        public static basicTestEntities db = new basicTestEntities();

        public EmployeeController()
        {
            employeeDataAccessLayer = new EmployeeDataAccessLayer();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var q = db.spGetAllEmployee().ToList();
            List<Employee> list = new List<Employee>();
            list.Clear();

            q.ForEach(i =>
            {
                Employee emp = new Employee
                {
                    UserID = i.UserID,
                    UserName = i.UserName,
                    Password = i.Password,
                    Email = i.Email,
                    Tel = i.Tel,
                    Disable = i.Disable
                };
                list.Add(emp);
            });

            return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            Employee employee = employeeDataAccessLayer.GetEmployeeData(id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                employeeDataAccessLayer.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            Employee employee = employeeDataAccessLayer.GetEmployeeData(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                employeeDataAccessLayer.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(string id)
        {
            Employee employee = employeeDataAccessLayer.GetEmployeeData(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                employeeDataAccessLayer.DeleteEmployee(employee.UserID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
