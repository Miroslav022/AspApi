using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Products;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Brand;
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Products
{
    public class EfDeleteProductCommand : EFUseCase, IDeleteProductCommand
    {
        private readonly DeleteItemValidator<Product> _validator;
        public EfDeleteProductCommand(AspContext context, DeleteItemValidator<Product> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 15;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);
            Product product = Context.Products.FirstOrDefault(p=>p.Id == data.Id);
            if (product != null)
            {
                product.IsActive = !product.IsActive;
                Context.SaveChanges();
            }
        }
    }
}
