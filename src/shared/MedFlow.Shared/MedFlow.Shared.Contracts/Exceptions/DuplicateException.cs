namespace MedFlow.Shared.Contracts.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string entity, string value) : base($"{entity} is already existing in {value}.")
        { }

        public DuplicateException() : base("Cannot Create a Dupilicate Entity. ") { }
    }
}
