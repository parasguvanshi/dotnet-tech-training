using Microsoft.AspNetCore.Mvc;
using SportsManagementApp.DTOs;
using SportsManagementApp.Entities;
using SportsManagementApp.Services.Interfaces;

namespace SportsManagementApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SportsController : ControllerBase
{
    private readonly ISportService _sportService;
    public SportsController(ISportService sportService)
    {
        _sportService = sportService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Sport), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Sport>> CreateSports(CreateSportDto dto)
    {
        try
        {
            var result = await _sportService.CreateSport(dto);
            return CreatedAtAction(nameof(CreateSports), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<Sport>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Sport>>> SearchSports([FromQuery] int? id, [FromQuery] string? name)
    {
        try
        {
            var result = await _sportService.SearchSports(id, name);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message ?? ex.Message);
        }
    }
}

