using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoofstockExercise.Services.Interface;
using System.Linq;

namespace RoofstockExercise.Pages.Property
{
    public class DeleteModel : PageModel
    {
        private readonly IPropertyService _propService;
        public DeleteModel(IPropertyService propService)
        {
            _propService = propService;
        }
        public IActionResult OnGet(int? id)
        {
            var propertyFinded = IndexModel.listProperties.FirstOrDefault(x => x.Id == id);
            _propService.DeleteProperty(propertyFinded);
            return RedirectToPage("/Property/Index");
        }
    }
}
