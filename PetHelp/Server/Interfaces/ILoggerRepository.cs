namespace PetHelp.Server.Interfaces;

public interface ILoggerRepository
{
    public void LogToDb(string log);
}