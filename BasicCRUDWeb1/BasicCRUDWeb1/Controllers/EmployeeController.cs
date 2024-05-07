using BasicCRUDWeb1.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Telerik.SvgIcons;

namespace BasicCRUDWeb1.Controllers
{
    public class EmployeeController : Controller
    {
        public static EmployeeDataAccessLayer db = null;

        public EmployeeController()
        {
            db = new EmployeeDataAccessLayer();
        }

        // Index page của trang Employee, hiển thị danh sách của Employees
        public ActionResult Index()
        {
            IEnumerable<Employee> emp = db.GetAllEmployee();
            return View(emp);
        }

        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            //1.Hiện thông tin người sử dụng.
            Employee emp= db.GetEmployeeData(id);
            return View(emp);
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
            // TODO: Add insert logic here
            db.AddEmployee(employee);
            return View();
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            //1.Hiện thông tin người sử dụng.
            Employee employee = db.GetEmployeeData(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                //4.Update lại thông tin được sửa vào database       
                // TODO: Add update logic here
                db.UpdateEmployee(employee);
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
            Employee employee = db.GetEmployeeData(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                //1.Xóa thông tin dòng được chọn.
                // TODO: Add delete logic here
                db.DeleteEmployee(employee.UserID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
