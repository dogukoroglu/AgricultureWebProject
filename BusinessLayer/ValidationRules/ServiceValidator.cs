using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ServiceValidator : AbstractValidator<Service>
	{
        public ServiceValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş geçilemez!")
                .MinimumLength(2).WithMessage("Lütfen en az 2 veya daha fazla karakter giriniz!");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş geçilemez!")
				.MinimumLength(2).WithMessage("Lütfen en az 2 veya daha fazla karakter giriniz!");
			RuleFor(x => x.Image).NotEmpty().WithMessage("Görsel alanı boş geçilemez!");
        }
    }
}
