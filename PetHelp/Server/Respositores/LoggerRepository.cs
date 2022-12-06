using Microsoft.AspNetCore.Identity;
using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using System.Security.Claims;

namespace PetHelp.Server.Respositores;

public class LoggerRepository : ILoggerRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _contextAccessor;

    public LoggerRepository(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
    {
        this._context = context;
        this._contextAccessor = contextAccessor;
    }

    public void LogToDb(string log)
    {
        var message = new Log();
        message.Message = log;

        var x = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        message.UserID = x; // <- TODO: poprawic
        Console.WriteLine(log);
        _context.Logi.Add(message);
        _context.SaveChanges();
    }
}
