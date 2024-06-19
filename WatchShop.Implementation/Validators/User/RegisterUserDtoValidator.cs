using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Users;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.User
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email).NotEmpty()
                                 .EmailAddress()
                                 .Must(x=> !ctx.Users.Any(u=>u.Email == x))
                                 .WithMessage("Email is already in use");

            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3);

            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3);
                    
            RuleFor(x=>x.Username).NotEmpty()
                                  .WithMessage("Username is required")
                                  .MinimumLength(3)
                                  .WithMessage("Minimun username length is 3 characters")
                                  .Must(x=>!ctx.Users.Any(u=>u.Username == x))
                                  .WithMessage("Username is already in use");

            RuleFor(x => x.BirthDate).Must(x => (DateTime.UtcNow - x).TotalDays > (18 * 365)).WithMessage("You have to be at least 18 years old.");



            RuleFor(x => x.CityId).NotEmpty().Must(x => ctx.Cities.Any(c => c.Id == x && c.IsActive));

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required")
                                   .MaximumLength(10).WithMessage("Addres must have maximum 10 characters");

            RuleFor(x=>x.Password).NotEmpty()
                                  .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$")
                                  .WithMessage("Password must be 8-20 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.");
        }


      
    }
}
