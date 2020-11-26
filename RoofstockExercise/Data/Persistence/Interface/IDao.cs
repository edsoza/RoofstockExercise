using System.Collections.Generic;

namespace RoofstockExercise.Data.Persistence.Interface
{
    public interface IDao<TModel>
    {
        TModel Get(object id);
        IEnumerable<TModel> GetAll();
        TModel Add(TModel model);
        TModel Create();
        TModel Update(TModel model);
        void Delete(TModel model);
    }
}
