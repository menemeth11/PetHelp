namespace PetHelp.Shared.Services;

public interface IClockProvider
{
    DateTime Now { get; }
}

public class ClockProvider : IClockProvider
{
    public DateTime Now => DateTime.Now;
}