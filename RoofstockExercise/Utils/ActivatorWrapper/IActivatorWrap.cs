using System;

namespace RoofstockExercise.Utils.ActivatorWrapper
{
    public interface IActivatorWrap
    {
        event EventHandler<ObjectCreatedEventArgs> ObjectCreated;
        T CreateInstance<T>();
        object CreateInstance(string assemblyName, string typeName);
    }
}
