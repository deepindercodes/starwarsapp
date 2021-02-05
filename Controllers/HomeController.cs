using starwarsapp.Models;
using System.Web.Mvc;

namespace starwarsapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InvalidRequest()
        {
            return View();
        }

        public ActionResult Films()
        {
            return View(StarWarsApi.GetFilms());
        }

        public ActionResult FilmDetails(int id)
        {
            return View(StarWarsApi.GetFilmDetails((int)id));
        }

        public ActionResult PeopleDetails(int id)
        {
            return View(StarWarsApi.GetCharactersInfo(id));
        }

        public ActionResult PlanetDetails(int id)
        {
            return View(StarWarsApi.GetPlanetInfo(id));
        }

        public ActionResult SpeciesDetails(int id)
        {
            return View(StarWarsApi.GetSepciesInfo(id));
        }

        public ActionResult VehicleDetails(int id)
        {
            return View(StarWarsApi.GetVehicleInfo(id));
        }

        public ActionResult StarshipDetails(int id)
        {
            return View(StarWarsApi.GetShipInfo(id));
        }
    }
}