using RoofstockExercise.Data.Persistence.Interface;
using RoofstockExercise.Data.UnityOfWork;
using RoofstockExercise.Models;
using RoofstockExercise.Utils.ActivatorWrapper;

namespace RoofstockExercise.Data.Persistence.Implementations
{
    public class PropertyDao: Dao<PropertiesModel>, IPropertyDao
    {
        public PropertyDao(IUnityWork unitOfWorkHelper, IActivatorWrap activator) : base(unitOfWorkHelper, activator)
        {

        }
    }
}
