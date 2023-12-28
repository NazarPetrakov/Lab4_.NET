namespace BusinessLogicLayer.Exeptions
{
    internal class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }

        public EntityNotFoundException(object key)
            : base($"Entity \"{typeof(T).Name}\" ({key}) was not found.")
        {
        }
    }
}
