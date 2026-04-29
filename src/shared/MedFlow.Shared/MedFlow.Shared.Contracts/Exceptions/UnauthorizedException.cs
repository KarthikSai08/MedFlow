namespace MedFlow.Shared.Contracts.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string name, int id) : base($"{name} with Id:{id} is not authorized. Please login again.") { }
    }
}
