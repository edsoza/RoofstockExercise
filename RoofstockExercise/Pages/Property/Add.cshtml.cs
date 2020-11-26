using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoofstockExercise.Services.Interface;
using System.Linq;

namespace RoofstockExercise.Pages.Property
{
    public class AddModel : PageModel
    {
        private readonly IPropertyService _propService;
        public AddModel(IPropertyService propService)
        {
            _propService = propService;
        }
        public IActionResult OnGet(int? id)
        {
            var propertyFinded = IndexModel.listProperties.FirstOrDefault(x => x.Id == id);
            if (_propService.GetAllProperties().FirstOrDefault(x => x.Id == id) != null)
            {
                ViewData["InsertResult"] = 200;
                return Page();
            }
            else
            {
                _propService.AddProperty(new Models.PropertiesModel()
                {
                    Address = propertyFinded.Address,
                    Id = id.Value,
                    ListPrice = propertyFinded.ListPrice,                    
                    MonthyRent = propertyFinded.MonthyRent,
                    YearBuilt = propertyFinded.YearBuilt,
                    GrossYield = propertyFinded.GrossYield
                }) ;
                return RedirectToPage("/Property/IndexDB");
            }            
        }
    }
}
