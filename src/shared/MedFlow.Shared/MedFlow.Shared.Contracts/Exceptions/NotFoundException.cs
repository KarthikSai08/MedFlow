namespace MedFlow.Shared.Contracts.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity, int id) : base($"{entity} with the Id : {id} Not Found.") { }

        public NotFoundException() : base("Entity not found!") { }
    }
}
