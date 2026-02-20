using Microsoft.AspNetCore.Mvc;
using SportsManagementApp.DTOs;
using SportsManagementApp.Entities;
using SportsManagementApp.Helper;
using SportsManagementApp.Services;

namespace SportsManagementApp.Controllers
{
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
        [ProducesResponseType(typeof(ApiResponseSuccess<Sport>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponseError<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sport>> Create(CreateSportDto dto)
        {
            try
            {
                var result = await _sportService.CreateSport(dto);

                return CreatedAtAction(nameof(GetById), new { id = result.Id }, new ApiResponseSuccess<Sport>
                {
                    Success = true,
                    Message = StringConstant.sportsCreated,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseError<string>
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseSuccess<Sport>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseError<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponseError<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Sport>>> GetAll()
        {
            try
            {
                var result = await _sportService.GetAllSports();

                if(result == null)
                {
                    return NotFound(new ApiResponseError<string>
                    {
                        Success = false,
                        Message = StringConstant.sportNotFound,
                    });
                }

                return Ok(new ApiResponseSuccess<IEnumerable<Sport>>
                {
                    Success = true,
                    Message = StringConstant.sportsFetchSuccess,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseError<string>
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponseSuccess<Sport>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseError<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponseError<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sport>> GetById(int id)
        {
            try
            {
                var result = await _sportService.GetSportById(id);

                if (result == null)
                {
                    return NotFound(new ApiResponseError<string>
                    {
                        Success = false,
                        Message = StringConstant.sportNotFound
                    });
                }

                return Ok(new ApiResponseSuccess<Sport>
                {
                    Success = true,
                    Message = StringConstant.sportsFetchSuccess,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseError<string>
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

       
    }
}
