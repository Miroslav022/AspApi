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
    public class EfEditUserCommand : EFUseCase, IEditUserCommand
    {
        private readonly EditUserDtoValidation _validate;
        public EfEditUserCommand(AspContext context, EditUserDtoValidation validate) : base(context)
        {
            _validate = validate;
        }

        public int Id => 39;

        public string Name => GetType().Name;

        public void Execute(EditUserDto data)
        {
            _validate.ValidateAndThrow(data);
            User userToEdit = Context.Users.FirstOrDefault(x => x.Id == data.Id);
            userToEdit.FirstName = data.FirstName;
            userToEdit.LastName = data.LastName;
            userToEdit.Email = data.Email;
            userToEdit.Username = data.Username;
            userToEdit.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);
            userToEdit.BirthDate = data.BirthDate;
            userToEdit.Image = Context.Users.Any(x=>x.Image.path == data.ProfileImagePath && x.Id == data.Id) ? userToEdit.Image : new Image { path = data.ProfileImagePath};

            Context.SaveChanges();
        }
    }
}
