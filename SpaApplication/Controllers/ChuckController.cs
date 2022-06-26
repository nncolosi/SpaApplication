using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SpaApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChuckController : Controller
    {
       
        [HttpGet("categories")]
        public async Task <IEnumerable<String>> Get()
        {
            List<String> categories = new List<string>();
           
          
          using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.chucknorris.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("jokes/categories").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    //deserialize to your class
                    categories = JSserializer.Deserialize<List<String>>(responseString);
                }
            }

            return categories;

        }

    }
}
