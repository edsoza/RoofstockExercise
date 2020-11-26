using System;

namespace RoofstockExercise.Utils.ActivatorWrapper
{
    public class ActivatorWrap : IActivatorWrap
    {
        public event EventHandler<ObjectCreatedEventArgs> ObjectCreated;

        public T CreateInstance<T>()
        {
            var instance = Activator.CreateInstance<T>();
            OnObjectCreated(instance);
            return instance;
        }

        public object CreateInstance(string assemblyName, string typeName)
        {
            var type = Type.GetType($"{assemblyName},{typeName}");
            var instance = Activator.CreateInstance(type);
            OnObjectCreated(instance);
            return instance;
        }

        protected void OnObjectCreated(object entity)
        {
            ObjectCreated?.Invoke(this, new ObjectCreatedEventArgs(entity));
        }
    }
}
