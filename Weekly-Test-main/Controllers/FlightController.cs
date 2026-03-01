using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlightSearchEngine.Data;
using FlightSearchEngine.Models;

namespace FlightSearchEngine.Controllers
{
    public class FlightController : Controller
    {
        private readonly DatabaseHelper _dbHelper;

        public FlightController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new SearchViewModel();
            var sources = await _dbHelper.GetSourcesAsync();
            var destinations = await _dbHelper.GetDestinationsAsync();

            model.SourceList = new SelectList(sources);
            model.DestinationList = new SelectList(destinations);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlights(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var sources = await _dbHelper.GetSourcesAsync();
                var destinations = await _dbHelper.GetDestinationsAsync();
                model.SourceList = new SelectList(sources);
                model.DestinationList = new SelectList(destinations);
                return View("Index", model);
            }

            var results = await _dbHelper.SearchFlightsAsync(model.Source, model.Destination, model.NumberOfPersons);
            ViewBag.SearchType = "Flight Only";
            ViewBag.Persons = model.NumberOfPersons;
            return View("Results", results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlightsWithHotels(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var sources = await _dbHelper.GetSourcesAsync();
                var destinations = await _dbHelper.GetDestinationsAsync();
                model.SourceList = new SelectList(sources);
                model.DestinationList = new SelectList(destinations);
                return View("Index", model);
            }

            var results = await _dbHelper.SearchFlightsWithHotelsAsync(model.Source, model.Destination, model.NumberOfPersons);
            ViewBag.SearchType = "Flight + Hotel";
            ViewBag.Persons = model.NumberOfPersons;
            return View("Results", results);
        }
    }
}
