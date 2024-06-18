using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.ProductSpecificationsDtos;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.ProductSpecificationValidator
{
    public class CreateProductSpecificationDtoValidator : AbstractValidator<AddProductSpecificationDto>
    {
        public CreateProductSpecificationDtoValidator(AspContext ctx)
        {
            RuleFor(x=>x.ProductId).Must(x=>ctx.Products.Any(p=>p.Id==x)).WithMessage("Product doesn't exist");
            RuleFor(x=>x.SpecificationId).Must(x=>ctx.Specifications.Any(s=>s.Id==x)).WithMessage("Specification doesn't exist");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Value is required");
        }
    }
}
