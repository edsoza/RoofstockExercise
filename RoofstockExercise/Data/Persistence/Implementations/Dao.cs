using RoofstockExercise.Data.UnityOfWork;
using RoofstockExercise.Utils.ActivatorWrapper;
using System.Collections.Generic;

namespace RoofstockExercise.Data.Persistence.Implementations
{
    public abstract class Dao<TModel> where TModel : class, new()
    {
        protected IUnityWork UnitOfWorkHelper;
        protected readonly IActivatorWrap Activator;

        protected Dao(IUnityWork unitOfWorkHelper, IActivatorWrap activator)
        {
            UnitOfWorkHelper = unitOfWorkHelper;
            Activator = activator;
        }

        public virtual TModel Get(object id)
        {
            return UnitOfWorkHelper.DbContext.Set<TModel>().Find(id);
        }
        public virtual IEnumerable<TModel> GetAll()
        {
            return UnitOfWorkHelper.DbContext.Set<TModel>();
        }

        public virtual TModel Create()
        {
            var model = Activator.CreateInstance<TModel>();
            return model;
        }

        public virtual TModel Add(TModel model)
        {
            var modelEntity = UnitOfWorkHelper.DbContext.Set<TModel>().Add(model);
            UnitOfWorkHelper.Commit();
            return modelEntity.Entity;
        }
        public virtual TModel Update(TModel model)
        {
            var modelEntity = UnitOfWorkHelper.DbContext.Set<TModel>().Update(model);
            UnitOfWorkHelper.Commit();
            return modelEntity.Entity;
        }

        public virtual void Delete(TModel model)
        {
            UnitOfWorkHelper.DbContext.Set<TModel>().Remove(model);
            UnitOfWorkHelper.Commit();
        }

    }
}
