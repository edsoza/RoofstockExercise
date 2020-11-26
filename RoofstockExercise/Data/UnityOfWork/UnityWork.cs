using RoofstockExercise.Data.Context;

namespace RoofstockExercise.Data.UnityOfWork
{
    public class UnityWork : IUnityWork
    {
        public IRoofstockContext DbContext { get; }

        public UnityWork(RoofstockContext context)
        {
            DbContext = context;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            
        }
    }
}
