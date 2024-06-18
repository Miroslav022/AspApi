using FluentValidation;
using WatchShop.Application.DTO.Product;
using WatchShop.Application.UseCases.Commands.Products;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Product;

namespace WatchShop.Implementation.UseCases.Commands.Products
{

    public class EfCreateProductCommand : EFUseCase, ICreateProductCommand
    {
        private CreateProductDtoValidator _validator;
        public EfCreateProductCommand(AspContext context, CreateProductDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 8;

        public string Name => GetType().Name;

        public void Execute(CreateProductDto data)
        {
            _validator.ValidateAndThrow(data);

            foreach(var file in data.Images)
            {
                var tempFile = Path.Combine("wwwroot", "temp", file);
                var desticationFile = Path.Combine("wwwroot", "products", file);
                System.IO.File.Move(tempFile, desticationFile);
            }

            Product productToAdd = new Product
            {
                Name = data.Name,
                CategoryId = data.CategoryId,
                BrandId = data.BrandId,
                Description = data.Description,
                Images = data.Images.Select(x=> new ProductImage
                {
                    Image = new Image
                    {
                        path = x
                    }
                }).ToList(),
                ProductSpecifications = data.ProductSpecifications.Select(x=>new ProductSpecification
                {
                    SpecificationId = x.SpecificationId,
                    Value = x.SpecificationValue,
                }).ToList(),
            };


            Price newPriceForNewProduct = new Price
            {
                Amount = data.Price,
                Product = productToAdd,
            };

            Context.Prices.Add(newPriceForNewProduct);
            Context.SaveChanges();
        }
    }
}
