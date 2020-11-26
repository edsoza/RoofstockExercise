namespace RoofstockExercise.Utils.ActivatorWrapper
{
    public class ObjectCreatedEventArgs
    {
        private readonly object _entity;
        public ObjectCreatedEventArgs(object entity)
        {
            _entity = entity;
        }
        public object Entity
        {
            get { return _entity; }
        }
    }
}
