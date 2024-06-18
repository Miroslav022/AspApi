using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Users;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Users
{
    public class EfDeleteUserCommand : EFUseCase, IDeleteUserCommand
    {
        private readonly DeleteItemValidator<User> _validator;
        public EfDeleteUserCommand(AspContext context, DeleteItemValidator<User> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);
            User user = Context.Users.FirstOrDefault(x => x.Id == data.Id);
            if (user != null) {
                user.IsActive = !user.IsActive;
                Context.SaveChanges();
            }
        }
    }
}
