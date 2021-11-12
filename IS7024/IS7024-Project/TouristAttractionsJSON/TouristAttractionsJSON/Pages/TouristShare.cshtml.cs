using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TouristAttractionsJSON.Pages
{
    public class TouristShareModel : PageModel
    {
        public JsonResult OnGet()
        {
            string city = HttpContext.Request.Query["city"];

            string key = System.IO.File.ReadAllText("WeatherAPIKey.txt");

            string url = "https://github.com/shivika24/tourism-project/blob/master/db.json" + city + "&key=" + key;



            string weatherDetails = getData(url);



            TouristShare.TouristShareAPI array = TouristShare.TouristShareAPI.FromJson(weatherDetails);



            return new JsonResult(array);
        }



        private string getData(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.DownloadString(url);
            }
        }
    }
}
