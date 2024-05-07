
using Telerik.Scaffolders.Models.Form;
using System.Web.Mvc;
using System;

namespace Telerik.Scaffolders.Controllers
{
    public class FormController : Controller
    {
        public ActionResult FormPage()
        {
            var viewModel = new FormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                UserName = "johny",
                Password = "123456",
                DateOfBirth = new DateTime(1990, 5, 8),
                Agree = false
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult FormSubmit(FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPage",model);
            }
            else
            {
                //handle successful form submission
                return View("FormPage",new FormModel());
            }
        }
    }
}

