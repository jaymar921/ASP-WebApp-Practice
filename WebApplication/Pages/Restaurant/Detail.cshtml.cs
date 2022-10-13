using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;

namespace WebApplication.Pages.Restaurant
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurants;

        [TempData]
        public string Message { get; set; }
        public OdeToFood.Core.Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurants)
        {
            this.restaurants = restaurants;
        }
        public IActionResult OnGet(int restaurantId)
        {
            // get the restaurant by Id
            Restaurant = restaurants.GetById(restaurantId);

            // if restaurant is null
            if(Restaurant == null)
            {
                // we redirect to notfound page
                return RedirectToPage("./NotFound");
            }
            // else return the page
            return Page();
        }
    }
}
