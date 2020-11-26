using RoofstockExercise.Data.Persistence.Interface;
using RoofstockExercise.Models;
using RoofstockExercise.Services.Interface;
using System.Collections.Generic;

namespace RoofstockExercise.Services.Implementation
{
    public class PropertyService: IPropertyService
    {
        private readonly IPropertyDao _propertyDao;
        public PropertyService(IPropertyDao propertyDao)
        {
            _propertyDao = propertyDao;
        }

        public IEnumerable<PropertiesModel> GetAllProperties()
        {
            return _propertyDao.GetAll();
        }

        public PropertiesModel AddProperty(PropertiesModel model)
        {
            return _propertyDao.Add(model);
        }

        public void DeleteProperty(PropertiesModel model)
        {
            _propertyDao.Delete(model);
        }
    }
}
