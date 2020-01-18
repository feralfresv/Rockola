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
                ApiKey = "AIzaSyA6F3R_kIdjAu7s1i7O7DwMxrvtwbpL1J8",
                ApplicationName = this.GetType().ToString()
            });

            var BuscarListaSolicitud = ServicioYouTube.Search.List("snippet");
            BuscarListaSolicitud.Q = palabra; //Buscador
            BuscarListaSolicitud.MaxResults = 5;

            var BuscarListaRespuesta = BuscarListaSolicitud.Execute();

            return PartialView("Search", BuscarListaRespuesta.Items);
        }


        [HttpGet]
        public ActionResult AddToPlayList(string IdVideo)
        {
            Declare();
            List<string> ListVideosId = (List<string>)Session["Playlist"];
            ListVideosId.Add(IdVideo);
            Session["Playlist"] = ListVideosId;
            return PartialView("Playlist", ListVideosId);
        }

        public void Declare()
        {
            List<string> PlayListIds = new List<string>();
            if (Session["Playlist"] == null)
            {
                Session["Playlist"] = PlayListIds;
            }
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