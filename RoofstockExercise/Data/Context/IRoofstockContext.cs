using Microsoft.EntityFrameworkCore;

namespace RoofstockExercise.Data.Context
{
    public interface IRoofstockContext
    {
        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
    }
}
