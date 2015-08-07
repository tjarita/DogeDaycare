using System.Web.Mvc;

namespace DogeDaycare.Web.Controllers
{
    public class HomeController : DogeDaycareControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}