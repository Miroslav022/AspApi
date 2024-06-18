using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Brands;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Brand;

namespace WatchShop.Implementation.UseCases.Commands.Brands
{
    public class EFCreateBrandCommand : EFUseCase, ICreateBrandCommand
    {
        private BrandDtoValidator _validator;
        public EFCreateBrandCommand(AspContext context, BrandDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => GetType().Name;

        public void Execute(NamedEntityDto data)
        {
            _validator.ValidateAndThrow(data);
            Brand brandToAdd = new Brand
            {
                Name = data.Name,
            };
            Context.Brands.Add(brandToAdd);
            Context.SaveChanges();
        }
    }
}
