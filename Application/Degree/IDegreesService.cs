using Domain.Dto;
using Domain.Dto.Common;

namespace Application.Degree
{
   public interface IDegreesService
   {      
      Task<CommandResponse<string>> CreateDegree (CreateDegreeDto dto, CancellationToken token);

      Task<CommandResponse<string>> UpdateDegree (int Id, UpdateDegreeDto dto, CancellationToken token);
      
      Task<CommandResponse<string>> DeleteDegree (int Id, CancellationToken token);

      Task<CommandResponse<string>> ClearDegrees (CancellationToken token);
   }
}