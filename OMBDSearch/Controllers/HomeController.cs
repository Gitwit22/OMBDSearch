using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using OMBDSearch.Models;
using System.Diagnostics;


namespace OMBDSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        

        public IActionResult MovieNight() 
        { 
            return View(); 
        
        }

        public IActionResult MovieSearch()
        {
            return View();

        }

        


        [HttpGet]

        public ActionResult MovieSearchForm(string Title)
        {
            string apiUri = "http://www.omdbapi.com/?apikey=5ad7ba55&t";
            var apiTask = apiUri.GetJsonAsync<Movie>();
            apiTask.Wait();
            Movie result = apiTask.Result;

            
            return View("MovieSearch", result);
        }



        

        [HttpPost]
        public IActionResult MovieSearchResults(Movie Title)
        {
            return View("MovieSearch", Title);

        }

        [HttpGet]
        public IActionResult MovieNightForm()
        {


            return View("MovieNight");
        }

        //[HttpPost]
        //    public IActionResult MovieNightResult(string Title1, string Title2, string Title3)
        //    {
        //        List<Movie> SearchResults = new List<Movie>();
        //        Title1.ToList(SearchResults);
        //        Title2.ToList(SearchResults);
        //        Title3.ToList(SearchResults);
        //        return View("MovieNight");
        //    }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}