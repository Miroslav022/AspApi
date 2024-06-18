

using FluentValidation;
using WatchShop.Application.DTO.ProductSpecificationsDtos;
using WatchShop.Application.UseCases.Commands.ProductSpecificationsCommands;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.ProductSpecificationValidator;

namespace WatchShop.Implementation.UseCases.Commands.ProductSpecifications
{
    public class EfCreateProductSpecificationCommand : EFUseCase, ICreateProductSpecificationCommand
    {
        private readonly CreateProductSpecificationDtoValidator _validator;
        public EfCreateProductSpecificationCommand(AspContext context, CreateProductSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 25;

        public string Name => GetType().Name;

        public void Execute(AddProductSpecificationDto data)
        {
            _validator.ValidateAndThrow(data);
            ProductSpecification ps = new ProductSpecification
            {
                ProductId = data.ProductId,
                SpecificationId = data.SpecificationId,
                Value = data.Value,
            };
            Context.ProductSpecifications.Add(ps);
            Context.SaveChanges();
        }
    }
}
