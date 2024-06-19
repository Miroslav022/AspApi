using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Users;
using WatchShop.Application.UseCases.Commands.Users;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.User;

namespace WatchShop.Implementation.UseCases.Commands.Users
{
    public class EFRegisterUserCommand : EFUseCase, IRegisterUserCommand
    {
        private RegisterUserDtoValidator _validator;
        public EFRegisterUserCommand(AspContext context, RegisterUserDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 1;

        public string Name => GetType().Name;

        public void Execute(RegisterUserDto data)
        {
            _validator.ValidateAndThrow(data);
            var allowedUseCasesForNewUser = new List<int> { 10, 11, 22, 24, 29, 30, 34, 35, 37, 40 };
            var useCasesForNewUser = new List<UserUseCase>();
            foreach (var i in allowedUseCasesForNewUser)
            {
                useCasesForNewUser.Add(new UserUseCase { UseCaseId = i });
            };

            User user = new User
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Username = data.Username,
                BirthDate = data.BirthDate,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Image = Context.Images.FirstOrDefault(x => x.path.Contains("default")),
                Location = new Location
                {
                    CityId = data.CityId,
                    Address = data.Address,
                },
                UserUseCases = useCasesForNewUser
            };
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
