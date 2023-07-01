using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class TeamValidator : AbstractValidator<Team>
	{
        public TeamValidator()
        {
            RuleFor(x => x.PersonName)
                .NotEmpty().WithMessage("İsim-Soyisim alanı boş geçilemez!")
                .MinimumLength(2).WithMessage("Minimum 2 karakter giriniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Departman alanı boş geçilemez!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel alanı boş geçilemez!");
        }
    }
}
