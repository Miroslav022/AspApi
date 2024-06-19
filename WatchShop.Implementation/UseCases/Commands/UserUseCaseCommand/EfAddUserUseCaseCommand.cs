using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.UserUseCasesDto;
using WatchShop.Application.UseCases.Commands.UserUseCases;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.UserUseCaseValidator;

namespace WatchShop.Implementation.UseCases.Commands.UserUseCaseCommand
{
    public class EfAddUserUseCaseCommand : EFUseCase, IAddUserUseCaseCommand
    {
        private readonly UserUseCaseDtoValidator _validator;
        public EfAddUserUseCaseCommand(AspContext context, UserUseCaseDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 42;

        public string Name => GetType().Name;

        public void Execute(UserUseCaseDto data)
        {
            _validator.ValidateAndThrow(data);
            Context.UserUseCases.AddRange(data.UseCaseIds.Select(x =>
             new UserUseCase
             {
                 UserId = data.UserId,
                 UseCaseId = x
             }));

            Context.SaveChanges();
        }
    }
}
