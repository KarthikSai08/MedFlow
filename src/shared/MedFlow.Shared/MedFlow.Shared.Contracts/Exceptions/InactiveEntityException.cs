namespace MedFlow.Shared.Contracts.Exceptions
{
    public class InactiveEntityException : Exception
    {
        public InactiveEntityException(string entity, int id) : base($"{entity} with Id :{id} is Inactive please try with others.") { }
    }
}
