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
        //pruebaa v1 git
        //prueba v2 git
        //prueba v3 git

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarLista(string palabra)
        {

            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            return PartialView("Search", obj.BuscarLista(palabra).ToList());
            //return PartialView("Search", obj.BuscarLista(palabra).ToList());

            //var ServicioYouTube = new YouTubeService(new BaseClientService.Initializer()
            //{
            //    ApiKey = "AIzaSyCENuuzGXhwKTvQVsuG0HyhEYW9DWuXGPg",
            //    ApplicationName = this.GetType().ToString()
            //});

            //var BuscarListaSolicitud = ServicioYouTube.Search.List("snippet");
            //BuscarListaSolicitud.Q = palabra; //Buscador
            //BuscarListaSolicitud.MaxResults = 5;

            //var BuscarListaRespuesta = BuscarListaSolicitud.Execute();
            //return PartialView("Search", BuscarListaRespuesta.Items);
        }
  
        #region

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

        #endregion
    }
}