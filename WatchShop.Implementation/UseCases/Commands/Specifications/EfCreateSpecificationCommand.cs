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
using WatchShop.Implementation.Validators.Category;
using WatchShop.Implementation.Validators.Specification;

namespace WatchShop.Implementation.UseCases.Commands.Specifications
{
    public class EfCreateSpecificationCommand : EFUseCase, ICreateSpecificationCommand
    {
        private CreateSpecificationDtoValidator _validator;
        public EfCreateSpecificationCommand(AspContext context, CreateSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;

        public string Name => GetType().Name;

        public void Execute(NamedEntityDto data)
        {
            _validator.ValidateAndThrow(data);
            Specification newSpecification = new Specification
            {
                Name = data.Name,
            };
            Context.Specifications.Add(newSpecification);
            Context.SaveChanges();
        }
    }
}
