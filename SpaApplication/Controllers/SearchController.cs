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
    public class SearchController : Controller
    {
        [HttpGet]
        public async Task<SearchResult> Get(string query)
        {
            SearchResult results = new SearchResult();
            Results jokes = new Results();
            PeopleResult people = new PeopleResult(); 


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.chucknorris.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"jokes/search?query={query}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    //deserialize to your class
                    jokes = JSserializer.Deserialize<Results>(responseString);
                }

              
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://swapi.dev/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               var response = client.GetAsync($"api/people/?search={query}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    //deserialize to your class
                    people = JSserializer.Deserialize<PeopleResult>(responseString);
                }
            }
                results.jokes = jokes;
            results.people = people;
            return results;

        }
    }
}
