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
        public JsonResult Employee_Read([DataSourceRequest] DataSourceRequest request)
        {
            try
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
            } catch(Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
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
        public JsonResult Create([DataSourceRequest] DataSourceRequest request,Employee emp)
        {
            try
            {

                db.spAddEmployee(userID: emp.UserID, userName: emp.UserName, password: emp.Password, email: emp.Email, tel: emp.Tel, disable: emp.Disable);
                return Json(new { success = true, message = "Employee created successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
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
