using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FlightSearchEngine.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Please select a source location")]
        public string Source { get; set; }

        [Required(ErrorMessage = "Please select a destination location")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Please enter number of persons")]
        [Range(1, 10, ErrorMessage = "Number of persons must be between 1 and 10")]
        public int NumberOfPersons { get; set; }

        [ValidateNever]
        public SelectList? SourceList { get; set; }

        [ValidateNever]
        public SelectList? DestinationList { get; set; }
    }
}
