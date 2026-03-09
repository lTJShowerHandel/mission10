using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BowlersController : ControllerBase
{
    private readonly BowlingLeagueContext _context;

    public BowlersController(BowlingLeagueContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get bowlers from Marlins and Sharks teams only.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BowlerDto>>> GetBowlers()
    {
        var bowlers = await _context.Bowlers
            .Include(b => b.Team)
            .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
            .OrderBy(b => b.BowlerLastName)
            .ThenBy(b => b.BowlerFirstName)
            .Select(b => new BowlerDto
            {
                BowlerName = string.Join(" ", new[] { b.BowlerFirstName, b.BowlerMiddleInit, b.BowlerLastName }.Where(s => !string.IsNullOrEmpty(s))),
                TeamName = b.Team.TeamName,
                Address = b.BowlerAddress ?? "",
                City = b.BowlerCity ?? "",
                State = b.BowlerState ?? "",
                Zip = b.BowlerZip ?? "",
                PhoneNumber = b.BowlerPhoneNumber ?? "",
            })
            .ToListAsync();

        return Ok(bowlers);
    }
}
