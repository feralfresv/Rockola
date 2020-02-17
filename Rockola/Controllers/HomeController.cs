using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using Rockola.Models;

namespace Rockola.Controllers
{
    public class HomeController : Controller
    {
   //merge ejemplo
        public ActionResult Index()
        {
            return View();
        }
        #region

        ////[HttpGet]
        //public ActionResult BuscarLista(string palabra)
        //{

        //    ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
        //    return PartialView("Search", obj.BuscarLista(palabra).ToList());

        //    //    //return PartialView("Search", obj.BuscarLista(palabra).ToList());

        //    //    //var ServicioYouTube = new YouTubeService(new BaseClientService.Initializer()
        //    //    //{
        //    //    //    ApiKey = "AIzaSyCENuuzGXhwKTvQVsuG0HyhEYW9DWuXGPg",
        //    //    //    ApplicationName = this.GetType().ToString()
        //    //    //});

        //    //    //var BuscarListaSolicitud = ServicioYouTube.Search.List("snippet");
        //    //    //BuscarListaSolicitud.Q = palabra; //Buscador
        //    //    //BuscarListaSolicitud.MaxResults = 5;

        //    //    //var BuscarListaRespuesta = BuscarListaSolicitud.Execute();
        //    //    //return PartialView("Search", BuscarListaRespuesta.Items);
        //    }
        #endregion

        [HttpGet]
        public ActionResult BuscarLista(string palabra)
        {
            IEnumerable<SearchResultCustomized> searchResultCustomizeds = null;
            HttpClient clienteHTTP = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:55869")
            };
            var request = clienteHTTP.GetAsync($"api/YT_API?palabra={palabra}");
            request.Wait();

            var result = request.Result;
            var readresult = result.Content.ReadAsAsync<IList<SearchResultCustomized>>();

            return PartialView("Search", readresult.Result) ;
        }

  

        //Invocar Seervicio REST 
        [HttpGet]
        public ActionResult Index2()
        {
            HttpClient clienteHTTP = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:55869")
            };

            var request = clienteHTTP.GetAsync("api/YT_API").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<dbo>>(resultString);

                return PartialView(listado);
            }
            return View();
        }




    }
}