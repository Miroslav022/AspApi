using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Product;
using WatchShop.Application.UseCases.Commands.ProductImages;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.ProductImagesValidator;

namespace WatchShop.Implementation.UseCases.Commands.ProductImages
{
    public class EfProductImagesCommand : EFUseCase, IAddProductImagesCommand
    {
        private readonly ProductImagesDtoValidator _validator;
        public EfProductImagesCommand(AspContext context, ProductImagesDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 41;

        public string Name => GetType().Name;

        public void Execute(EditProductImage data)
        {
            _validator.ValidateAndThrow(data);
            ProductImage newProductImage = new ProductImage
            {
                ImageId = data.ImageId,
                ProductId = data.ProductId,
            };
            Context.ProductImages.Add(newProductImage);
            Context.SaveChanges();
        }
    }
}
