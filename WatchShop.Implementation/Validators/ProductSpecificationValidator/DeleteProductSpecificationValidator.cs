using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.DTO.ProductSpecificationsDtos;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.ProductSpecificationValidator
{
    public class DeleteProductSpecificationValidator : AbstractValidator<DeleteProductSpecificationDto>
    {
        public DeleteProductSpecificationValidator(AspContext ctx)
        {
            RuleFor(x => x.ProductId).Must(x => ctx.ProductSpecifications.Any(ps => ps.ProductId == x))
                                     .WithMessage("Product doesn't exist");

            RuleFor(x => x.SpecificationId).Must(x => ctx.ProductSpecifications.Any(ps => ps.SpecificationId == x))
                                     .WithMessage("Specification doesn't exist");
        }
    }
}
