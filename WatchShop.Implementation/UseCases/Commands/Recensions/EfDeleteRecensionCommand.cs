using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Recensions;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Recensions
{
    public class EfDeleteRecensionCommand : EFUseCase, IDeleteRecensionCommand
    {
        private readonly DeleteItemValidator<Recension> _validator;
        public EfDeleteRecensionCommand(AspContext context, DeleteItemValidator<Recension> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 21;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);

            Recension recension = Context.Recensions.FirstOrDefault(x=>x.Id == data.Id);
            if (recension != null) {
                recension.IsActive = !recension.IsActive;
                Context.SaveChanges();
            }
        }
    }
}
