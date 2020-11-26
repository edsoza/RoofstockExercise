using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RoofstockExercise.Models;
using RoofstockExercise.Utils;
using System.Collections.Generic;
using System.Text.Json;

namespace RoofstockExercise.Pages.Property
{
    public class IndexModel : PageModel
    {
        private static string PROPERTY = "properties.json";
        private readonly RestService _restService;
        public static List<PropertiesModel> listProperties;

        [BindProperty]
        public string Properties { get; set; }

        public IndexModel(IConfiguration _config)
        {
            _restService = new RestService(_config.GetSection("RestService").GetSection("EndPoint").Value);
        }
        public IActionResult OnGet()
        {
            ObtainPropertiesInformation(_restService.Get(PROPERTY));

            return Page();
        }

        private void ObtainPropertiesInformation(JObject json)
        {
            listProperties = new List<PropertiesModel>();
            foreach (var property in json["properties"])
            {
                PropertiesModel model = new PropertiesModel();
                model.Id = property["id"].Value<int>();
                model.ListPrice = (property["financial"] == null || property["financial"].ToString() == "") ? 0 : property["financial"]["listPrice"].Value<decimal>();
                model.Address = (property["address"] == null || property["address"].ToString() == "") ? string.Empty : property["address"]["address1"].Value<string>();
                model.MonthyRent = (property["financial"] == null || property["financial"].ToString() == "") ? 0 : property["financial"]["monthlyRent"].Value<decimal>();
                model.YearBuilt = (property["physical"] == null || property["physical"].ToString() == "") ? 0 : property["physical"]["yearBuilt"].Value<int>();
                model.GrossYield = model.GrossYield;

                listProperties.Add(model);
            }

            Properties = JsonSerializer.Serialize(listProperties);
        }
    }
}
