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

      [HttpPost]
      public async Task<IActionResult> CreateDegree([FromBody] CreateDegreeDto dto, CancellationToken token)
         => Ok(await _degreesService.CreateDegree(dto, token));

      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateDegree(Guid id,  [FromBody] UpdateDegreeDto dto, CancellationToken token)
        => Ok(await _degreesService.UpdateDegree(id, dto, token));

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteDegree(Guid id, CancellationToken token)
        => Ok(await _degreesService.DeleteDegree(id, token));
    }
}