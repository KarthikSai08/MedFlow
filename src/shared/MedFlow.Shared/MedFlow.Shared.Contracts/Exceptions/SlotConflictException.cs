namespace MedFlow.Shared.Contracts.Exceptions
{
    public class SlotConflictException : Exception
    {
        public SlotConflictException() : base("The Appointment slot has been already booked.Try another slot.") { }
    }
}
