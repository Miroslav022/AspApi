using FluentValidation;
using WatchShop.Application.DTO.ProductSpecificationsDtos;
using WatchShop.Application.Exceptions;
using WatchShop.Application.UseCases.Commands.ProductSpecificationsCommands;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.ProductSpecificationValidator;

namespace WatchShop.Implementation.UseCases.Commands.ProductSpecifications
{
    public class EfDeleteProductSpecificationCommand : EFUseCase, IDeleteProductSpecification
    {
        private readonly DeleteProductSpecificationValidator _validator;
        public EfDeleteProductSpecificationCommand(AspContext context, DeleteProductSpecificationValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 20;

        public string Name => GetType().Name;

   

        public void Execute(DeleteProductSpecificationDto data)
        {
            _validator.ValidateAndThrow(data);
            
            ProductSpecification productSpecification = Context.ProductSpecifications.FirstOrDefault(x => x.ProductId == data.ProductId && x.SpecificationId == data.SpecificationId);
            if (productSpecification != null) {
                Context.ProductSpecifications.Remove(productSpecification);
                Context.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException(nameof(ProductSpecification));
            }
        }
    }
}
