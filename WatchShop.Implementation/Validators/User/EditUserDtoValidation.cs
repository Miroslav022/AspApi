using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Users;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.User
{
    public class EditUserDtoValidation : AbstractValidator<EditUserDto>
    {
        private readonly AspContext _ctx;
        public EditUserDtoValidation(AspContext ctx)
        {
            _ctx = ctx;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.Users.Any(u => u.Id == x)).WithMessage("User doesn't exist");

            RuleFor(x => x.Email).NotEmpty()
                               .WithMessage("Email is required")
                               .EmailAddress()
                               .WithMessage("Please enter email format");

            RuleFor(x => x.FirstName).NotEmpty()
                                   .WithMessage("First name is required")
                                   .MinimumLength(3)
                                   .WithMessage("Name must have at least 3 characters");

            RuleFor(x => x.LastName).NotEmpty()
                                   .WithMessage("Last name is required")
                                   .MinimumLength(3)
                                   .WithMessage("Name must have at least 3 characters");

            RuleFor(x => x.Username).NotEmpty()
                                 .WithMessage("Username is required")
                                 .MinimumLength(3)
                                 .WithMessage("Minimun username length is 3 characters")
                                .Must((dto, username) => !IsUsernameInUse(dto.Id, username))
                                 .WithMessage("Username is already in use");

            RuleFor(x => x.BirthDate).Must(x => (DateTime.UtcNow - x).TotalDays > (18 * 365)).WithMessage("You have to be at least 18 years old.");


            RuleFor(x => x.Password).NotEmpty()
                                  .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$")
                                  .WithMessage("Password must be 8-20 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.");

        }
        private bool IsUsernameInUse(int id, string username)
        {
            return _ctx.Users.Any(u => u.Username == username && u.Id != id);
        }
    }
}
