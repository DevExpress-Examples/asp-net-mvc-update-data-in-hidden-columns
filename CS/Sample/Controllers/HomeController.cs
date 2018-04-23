using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Sample.Models;

namespace Sample.Controllers {
    public class HomeController : Controller {
        PersonsList list = new PersonsList();

        public ActionResult Index() {
            return View(list.GetPersons());
        }

        public ActionResult GridViewEditingPartial() {
            return PartialView(list.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Person person) {
            if (ModelState.IsValid)
                list.AddPerson(person);
            return PartialView("GridViewEditingPartial", list.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Person personInfo) {
            System.Diagnostics.Debug.WriteLine(personInfo.MiddleName);

            if (ModelState.IsValid)
                list.UpdatePerson(personInfo);
            return PartialView("GridViewEditingPartial", list.GetPersons());
        }

        public ActionResult EditingDelete(int personId) {
            list.DeletePerson(personId);
            return PartialView("GridViewEditingPartial", list.GetPersons());
        }
    }
}