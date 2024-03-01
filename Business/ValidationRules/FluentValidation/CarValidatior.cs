using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidatior:AbstractValidator<Car>
    {
        public CarValidatior() 
        {

            RuleFor(c => c.DailyPrice).GreaterThan(0);

        }

    }
}
