using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using SpaApplication.Models;
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
    public class SwapiController : Controller
    {
        [HttpGet("people")]
        public async Task<IEnumerable<Person>> Get()
        {
            List<Person> people = new List<Person>();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://swapi.dev/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/people/").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    //deserialize to your class
                    people = JSserializer.Deserialize<List<Person>>(responseString);
                }
            }

            return people;

        }
    }
}
