using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RoofstockExercise.Services.Interface;

namespace RoofstockExercise.Pages.Property
{
    public class IndexDBModel : PageModel
    {
        private readonly IPropertyService _propertyService;

        [BindProperty]
        public string Properties { get; set; }
        public IndexDBModel(IPropertyService propertySevice)
        {
            _propertyService = propertySevice;
        }
        public IActionResult OnGet()
        {
            var result = _propertyService.GetAllProperties();
            Properties = JsonConvert.SerializeObject(result);

            return Page();
        }
    }
}
