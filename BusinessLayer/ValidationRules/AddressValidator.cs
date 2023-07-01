using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AddressValidator : AbstractValidator<Address>
	{
        public AddressValidator()
        {
            RuleFor(x => x.Descripiton1).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Descripiton2).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Descripiton3).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Descripiton4).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Mapinfo).NotEmpty().WithMessage("Bu alan boş geçilemez!");
        }
    }
}
