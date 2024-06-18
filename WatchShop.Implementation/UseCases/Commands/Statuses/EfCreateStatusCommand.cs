using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Statuses;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Status;

namespace WatchShop.Implementation.UseCases.Commands.Statuses
{
    public class EfCreateStatusCommand : EFUseCase, ICreateStatusCommand
    {
        private CreateStatusDtoValidator _validator;
        public EfCreateStatusCommand(AspContext context, CreateStatusDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => GetType().Name;

        public void Execute(NamedEntityDto data)
        {
            _validator.ValidateAndThrow(data);
            Status statusToAdd = new Status
            {
                Name = data.Name
            };

            Context.Statuses.Add(statusToAdd);
            Context.SaveChanges();
        }
    }
}
