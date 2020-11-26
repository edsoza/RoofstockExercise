using RoofstockExercise.Data.Context;
using System;

namespace RoofstockExercise.Data.UnityOfWork
{
    public interface IUnityWork: IDisposable
    {
        IRoofstockContext DbContext { get; }
        void Commit();
    }
}
