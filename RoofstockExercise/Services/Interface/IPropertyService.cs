using RoofstockExercise.Models;
using System.Collections.Generic;

namespace RoofstockExercise.Services.Interface
{
    public interface IPropertyService
    {
        IEnumerable<PropertiesModel> GetAllProperties();
        PropertiesModel AddProperty(PropertiesModel model);
        void DeleteProperty(PropertiesModel model);
    }
}
