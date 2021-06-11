using System;
using System.Net;
using CZProxy.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CZProxy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : Controller
    {
        private const string _eventsUrl =
            "https://community-z.com/api/v2/events.json?start={0}&period=upcoming";//"&location%5B%5D=Uzbekistan";

        // GET
        [HttpGet]
        public IActionResult Index(int? pageNumber)
        {
            if (pageNumber < 0)
                pageNumber = 0;
            
            string json;

            try
            {
                using WebClient wc = new WebClient();
                json = wc.DownloadString(string.Format(_eventsUrl, pageNumber ?? 0));
            }
            catch (Exception ex)
            {
                return View(new EventsResponse { ErrorMessage =  ex.Message });
            }

            if (string.IsNullOrEmpty(json))
                return View(new EventsResponse { ErrorMessage = "No events fetched" });

            var response = JsonConvert.DeserializeObject<EventsResponse>(json);

            if (response != null)
            {
                foreach (var czEvent in response.Events)
                {
                    czEvent.Branding ??= new Branding();

                    czEvent.Branding.Images ??= new Images();
                    
                    czEvent.Branding.Images.S ??= string.Empty;
                }
                return View(response);
            }

            return View(new EventsResponse { ErrorMessage = "Nothing to show" });
        }
    }
}