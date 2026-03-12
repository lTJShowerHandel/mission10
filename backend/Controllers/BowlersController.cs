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
        try
        {
            var list = await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .OrderBy(b => b.BowlerLastName)
                .ThenBy(b => b.BowlerFirstName)
                .ToListAsync();

            var bowlers = list.Select(b =>
            {
                var nameParts = new[] { b.BowlerFirstName, b.BowlerMiddleInit, b.BowlerLastName }
                    .Where(s => !string.IsNullOrEmpty(s));
                return new BowlerDto
                {
                    BowlerName = string.Join(" ", nameParts),
                    TeamName = b.Team.TeamName,
                    Address = b.BowlerAddress ?? "",
                    City = b.BowlerCity ?? "",
                    State = b.BowlerState ?? "",
                    Zip = b.BowlerZip ?? "",
                    PhoneNumber = b.BowlerPhoneNumber ?? "",
                };
            }).ToList();

            return Ok(bowlers);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message, detail = ex.InnerException?.Message });
        }
    }
}
