using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WatchShop.Application.DTO.Product;
using WatchShop.Application.UseCases.Commands.Products;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Product;

namespace WatchShop.Implementation.UseCases.Commands.Products
{
    public class EfEditProductCommand : EFUseCase, IEditProductCommand
    {
        private readonly EditProductDtoValidation _validator;
        public EfEditProductCommand(AspContext context, EditProductDtoValidation validator) : base(context)
        {
            _validator = validator;
        }

        public int Id =>38;

        public string Name => GetType().Name;

        public void Execute(EditProductDto data)
        {
            _validator.ValidateAndThrow(data);
            Product productToEdit = Context.Products.FirstOrDefault(x => x.Id == data.Id);
            productToEdit.Name = data.Name;
            productToEdit.Description = data.Description;
            productToEdit.CategoryId = data.CategoryId;
            productToEdit.BrandId = data.BrandId;


            var LastActivePrice = productToEdit.Prices.OrderByDescending(p=>p.CreatedAt).FirstOrDefault();
            if(LastActivePrice.Amount != data.Price)
            {
                var newPrice = new Price
                {
                    Amount = data.Price,
                    Product = productToEdit,

                };
                Context.Prices.Add(newPrice);
            }

            Context.SaveChanges();
        }
    }
}
