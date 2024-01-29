using Application.Degree;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
   [ApiController]
   [Route("api/degrees")]
   public class DegreesController : ControllerBase
   {
      private readonly IDegreesService _degreesService;

      public DegreesController(IDegreesService degreesService)
      {
         _degreesService = degreesService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll(CancellationToken token)
        => Ok(await _degreesService.GetDegreesAll(token));

      [HttpPost]
      public async Task<IActionResult> CreateDegree([FromBody] CreateDegreeDto dto, CancellationToken token)
         => Ok(await _degreesService.CreateDegree(dto, token));

      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateDegree(int id,  [FromBody] UpdateDegreeDto dto, CancellationToken token)
        => Ok(await _degreesService.UpdateDegree(id, dto, token));

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteDegree(int id, CancellationToken token)
        => Ok(await _degreesService.DeleteDegree(id, token));

      [HttpDelete]
      public async Task<IActionResult> ClearDegrees(CancellationToken token)
        => Ok(await _degreesService.ClearDegrees(token));
    }
}