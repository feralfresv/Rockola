using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Rockola.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarLista(string palabra)
        {
            var ServicioYouTube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDOWDXSYml18hvagwa91sPt0nHhFkSpWnA",
                ApplicationName = this.GetType().ToString()
            });

            var BuscarListaSolicitud = ServicioYouTube.Search.List("snippet");
            BuscarListaSolicitud.Q = palabra; //Buscador
            BuscarListaSolicitud.MaxResults = 10;

            var BuscarListaRespuesta = BuscarListaSolicitud.Execute();

            return PartialView("Search", BuscarListaRespuesta.Items);
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
    }
}