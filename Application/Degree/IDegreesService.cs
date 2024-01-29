using Domain.Dto;
using Domain.Dto.Common;

namespace Application.Degree
{
   public interface IDegreesService
   {
      Task<Response<List<ItemDegreesDto>>> GetDegreesAll(CancellationToken token);

      Task<Response<string>> CreateDegree (CreateDegreeDto dto, CancellationToken token);

      Task<Response<string>> UpdateDegree (int Id, UpdateDegreeDto dto, CancellationToken token);
      
      Task<Response<string>> DeleteDegree (int Id, CancellationToken token);

      Task<Response<string>> ClearDegrees (CancellationToken token);
   }
}