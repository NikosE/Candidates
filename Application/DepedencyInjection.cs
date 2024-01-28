using Application.Candidate;
using Application.Degree;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
   public static class DepedencyInjection
   {
      public static IServiceCollection AddApplication(this IServiceCollection services)
      {
         // Application/Admin services
         services.AddScoped<IDegreesService, DegreesService>();
         services.AddScoped<ICandidatesService, CandidatesService>();
         

        // Application services
        

        return services;
      }        
   }
}