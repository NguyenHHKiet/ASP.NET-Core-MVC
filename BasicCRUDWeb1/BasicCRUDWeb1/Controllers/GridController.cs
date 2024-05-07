
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Scaffolders.Models.Grid;
using BasicCRUDWeb1.Models;
 
namespace Telerik.Scaffolders.Controllers
{
    public class GridController : Controller
    {
        public ActionResult GridPage()
        {
            return View();
        }
        
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = Enumerable.Range(1, 50).Select(i => new GridModel
            {
                Id = i,
                Freight = i * 10,
                OrderDate = new DateTime(2016, 9, 15).AddDays(i % 7),
                ShipName = "ShipName " + i,
                ShipCity = "ShipCity " + i, 
            });

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, GridModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                // service.Create(model); //save to DB
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, GridModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                // service.Update(model); //update model to DB
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, GridModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                // service.Delete(model); //delete from DB
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

    }
}

