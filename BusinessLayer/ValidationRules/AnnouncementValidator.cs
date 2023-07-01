using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AnnouncementValidator : AbstractValidator<Announcement>
	{
		public AnnouncementValidator()
		{
			RuleFor(x => x.Title)
				.NotEmpty().WithMessage("Duyuru Başlığı alanı boş geçilemez!")
				.MinimumLength(2).WithMessage("En az 2 karakter girişi olmalıdır.");
			RuleFor(x => x.Descripiton)
				.NotEmpty().WithMessage("Açıklama alanı boş geçilemez!")
				.MinimumLength(2).WithMessage("Lütfen 2 veya daha fazla karakter giriniz!");
		}
	}
}
