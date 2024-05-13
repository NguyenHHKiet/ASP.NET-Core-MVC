
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Scaffolders.Models.Grid;
using KendoUI.Models;

namespace Telerik.Scaffolders.Controllers
{
    public class EmployeeController : Controller
    {
        basicTestEntities dbContext = null;
        public EmployeeController()
        {
            dbContext = new basicTestEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var q = dbContext.spGetAllEmployee().ToList();

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

            var dsResult = list.ToDataSourceResult(request);
            return Json(dsResult);
        }

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, EmployeeModel model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    dbContext.spAddEmployee(userID: model.UserID, userName: model.UserName, password: model.Password, email: model.Email, tel: model.Tel, disable: model.Disable); //save to DB
                }
                return Json(new { success = true, message = "Employee created successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, EmployeeModel model)
        {
            try 
            { 
                if (model != null && ModelState.IsValid)
                {
                    dbContext.spUpdateEmployee(userID: model.UserID, userName: model.UserName, password: model.Password, email: model.Email, tel: model.Tel, disable: model.Disable); //update model to DB
                }
                return Json(new { success = true, message = "Employee edited successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, EmployeeModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                 dbContext.spDeleteEmployee(model.UserID); //delete from DB
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

    }
}

