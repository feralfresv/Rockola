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
        //pruebaa v1
        //prueba v2
        //prueba v3

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarLista(string palabra)
        {
            var ServicioYouTube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAACKrydm8xL3ILzJWFQy5vN4vXTNa8dN8",
                ApplicationName = this.GetType().ToString()
            });

            var BuscarListaSolicitud = ServicioYouTube.Search.List("snippet");
            BuscarListaSolicitud.Q = palabra; //Buscador
            BuscarListaSolicitud.MaxResults = 5;

            var BuscarListaRespuesta = BuscarListaSolicitud.Execute();

            return PartialView("Search", BuscarListaRespuesta.Items);
        }


        [HttpGet]
        public ActionResult AddToPlayList(Google.Apis.YouTube.v3.Data.SearchResult IdVideo)
        {
            return PartialView("AddPlay", IdVideo);
        }

        [HttpGet]
        public ActionResult Play(string IdVideo)
        {
            return PartialView("Play", IdVideo);
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