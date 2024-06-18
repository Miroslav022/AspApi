using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Specifications;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Specifications
{
    public class EfDeleteSpecificationCommand : EFUseCase, IDeleteSpecificationCommand
    {
        private readonly DeleteItemValidator<Specification> _validator;
        public EfDeleteSpecificationCommand(AspContext context, DeleteItemValidator<Specification> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
             _validator.ValidateAndThrow(data);

            Specification specification = Context.Specifications.FirstOrDefault(x=>x.Id == data.Id);
            if (specification != null)
            {
                specification.IsActive = !specification.IsActive;
                Context.SaveChanges();
            }
        }
    }
}
