using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Brands;
using WatchShop.Application.UseCases.Commands.CommonUseCase;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Brands
{
    public class EfDeleteBrandCommand : EFUseCase, IDeleteBrandCommand
    {
        private readonly DeleteItemValidator<Brand> _validator;
        public EfDeleteBrandCommand(AspContext context, DeleteItemValidator<Brand> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 12;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);
            Brand brandToDelete = Context.Brands.FirstOrDefault(x => x.Id == data.Id);
            brandToDelete.IsActive = !brandToDelete.IsActive;
            Context.SaveChanges();
        }
    }
}
