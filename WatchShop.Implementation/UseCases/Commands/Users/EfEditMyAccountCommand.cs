using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application;
using WatchShop.Application.DTO.Users;
using WatchShop.Application.UseCases.Commands.Users;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.User;

namespace WatchShop.Implementation.UseCases.Commands.Users
{
    public class EfEditMyAccountCommand : EFUseCase, IEditMyAccount
    {
        private readonly EditMyAccountDtoValidator _validator;
        private readonly IApplicationActor _actor;
        public EfEditMyAccountCommand(AspContext context, EditMyAccountDtoValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 40;

        public string Name => GetType().Name;

        public void Execute(EditMyAccount data)
        {
            _validator.ValidateAndThrow(data);
            User userToEdit = Context.Users.FirstOrDefault(x => x.Id == _actor.Id);
            userToEdit.FirstName = data.FirstName;
            userToEdit.LastName = data.LastName;
            userToEdit.Email = data.Email;
            userToEdit.Username = data.Username;
            userToEdit.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);
            userToEdit.BirthDate = data.BirthDate;
            userToEdit.Image = Context.Users.Any(x => x.Image.path == data.ProfileImagePath && x.Id == _actor.Id) ? userToEdit.Image : new Image { path = data.ProfileImagePath };

            Context.SaveChanges();
        }
    }
}
