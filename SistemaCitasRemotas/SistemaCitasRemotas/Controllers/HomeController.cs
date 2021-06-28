//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Calendar.v3;
//using Google.Apis.Calendar.v3.Data;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SistemaCitasRemotas.Controllers
{
    public class HomeController : Controller
    {
        //public List<CitasReservadas> EventosGoogle = new List<CitasReservadas>();
        ////permisos de calendario
        //static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        ////nombre de la aplicacion
        //static string ApplicationName = "Google Calendar API .NET Quickstart";

        public class CitasReservadas
        {
            public DateTime citahora { get; set; }
            public string citaNombre { get; set; }
            public string linkmeet { get; set; }
        }

        // GET: Home
        public ActionResult Index()
        {
            //CalendarioEvento();
            //ViewBag.ListaEventos = EventosGoogle;
            return View();
        }

        //public void CalendarioEvento()
        //{
        //    UserCredential credential;

        //    //ruta 
        //    string ruta = Server.MapPath("~/Credencial.json");
        //    //string ruta = @"C:\Users\Marlon\Desktop\Ultimo Ciclo\Programacion Web 2\Proyecto citas medicas\Credencial.json";


        //    using (var stream =
        //        new FileStream(ruta, mode: FileMode.Open, FileAccess.Read))
        //    {
        //        // The file token.json stores the user's access and refresh tokens, and is created
        //        // automatically when the authorization flow completes for the first time.
        //        string credPath = "token.json";
        //        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            Scopes,
        //            "user",
        //            CancellationToken.None,
        //            new FileDataStore(credPath, true)).Result;
        //        Console.WriteLine("Archivo de Credencial guardado en: " + credPath);
        //    }

        //    // Create Google Calendar API service.
        //    var service = new CalendarService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = ApplicationName,
        //    });

        //    // Define parameters of request.
        //    EventsResource.ListRequest request = service.Events.List("primary");
        //    request.TimeMin = DateTime.Now;
        //    request.ShowDeleted = false;
        //    request.SingleEvents = true;
        //    request.MaxResults = 10;
        //    request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        //    // List events.
        //    Events events = request.Execute();
        //    Console.WriteLine("Upcoming events:");
        //    if (events.Items != null && events.Items.Count > 0)
        //    {
        //        foreach (var eventItem in events.Items)
        //        {

        //            CitasReservadas obj = new CitasReservadas();

        //            obj.citahora = eventItem.Created.Value;

        //            obj.citaNombre = eventItem.Summary.ToString();
        //            //var n = eventItem.ConferenceData.ConferenceSolution.Key.Type;
        //            obj.linkmeet = eventItem.HangoutLink != null ? eventItem.HangoutLink.ToString() : "";
        //            EventosGoogle.Add(obj);

        //            //EventosGoogle.Add(eventItem.ICalUID);
        //            //string when = eventItem.Start.DateTime.ToString();
        //            //if (String.IsNullOrEmpty(when))
        //            //{
        //            //    when = eventItem.Start.Date;
        //            //}
        //            //Console.WriteLine("{0} ({1})", eventItem.Summary, when);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No upcoming events found.");
        //    }
        //    //Console.Read();
        //}
    }
}