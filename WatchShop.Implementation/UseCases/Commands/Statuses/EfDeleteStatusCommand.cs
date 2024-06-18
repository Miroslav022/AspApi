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
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Statuses
{
    public class EfDeleteStatusCommand : EFUseCase, IDeleteStatusCommand
    {
        private readonly DeleteItemValidator<Status> _validator;
        public EfDeleteStatusCommand(AspContext context, DeleteItemValidator<Status> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);

            Status status = Context.Statuses.FirstOrDefault(x=>x.Id==data.Id);
            if (status != null)
            {
                status.IsActive = !status.IsActive;
                Context.SaveChanges();
            }
        }
    }
}
