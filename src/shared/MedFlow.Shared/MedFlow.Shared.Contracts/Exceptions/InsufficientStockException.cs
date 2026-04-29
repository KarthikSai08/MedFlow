namespace MedFlow.Shared.Contracts.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException(string prd, int qnty) : base($"{prd} has only {qnty} please try within the stock quantity.") { }

        public InsufficientStockException(string message) { }
    }
}
