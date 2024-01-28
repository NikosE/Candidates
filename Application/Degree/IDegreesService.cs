using Domain.Dto;
using Domain.Dto.Common;

namespace Application.Degree
{
   public interface IDegreesService
   {
      Task<CommandResponse<string>> CreateDegree (CreateDegreeDto dto, CancellationToken token);
      Task<CommandResponse<string>> UpdateDegree (Guid DegreeId, UpdateDegreeDto dto, CancellationToken token);
      Task<CommandResponse<string>> DeleteDegree (Guid DegreeId, CancellationToken token);
   }
}