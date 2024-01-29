using Domain.Dto;
using FluentValidation;

namespace Application.Validators
{
   public class UpdateCandidateDtoValidator : AbstractValidator<UpdateCandidateDto>
   {
      public UpdateCandidateDtoValidator()
      {
         RuleFor(dto => dto.Email)
               .NotEmpty().WithMessage("Το Email είναι υποχρεωτικό.")
               .EmailAddress().WithMessage("Μη έγκυρο Email.");

         RuleFor(dto => dto.Mobile)
               .NotEmpty().WithMessage("Ο αριθμός τηλεφώνου είναι υποχρεωτικός.")
               .Matches(@"^\d{10}$").WithMessage("Μη έγκυρος αριθμός τηλεφώνου.");
      }
   }
}