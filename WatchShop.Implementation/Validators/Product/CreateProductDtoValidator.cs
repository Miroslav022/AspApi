using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Product;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Product
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name).NotEmpty()
                              .WithMessage("Product name is required")
                              .Must(x => !ctx.Products.Any(p => p.Name == x))
                              .WithMessage("Product with the same name already exists");

            RuleFor(x => x.Description).NotEmpty()
                                     .WithMessage("Description is required")
                                     .MinimumLength(20)
                                     .WithMessage("Description should be at least 20 characters");

            RuleFor(x => x.BrandId).NotEmpty()
                                 .WithMessage("Brand id is required")
                                 .Must(x => ctx.Brands.Any(b => b.Id == x && b.IsActive))
                                 .WithMessage("Brand doesn't exist");

            RuleFor(x => x.CategoryId).NotEmpty()
                                 .WithMessage("Category id is required")
                                 .Must(x => ctx.Categories.Any(c => c.Id == x && c.IsActive))
                                 .WithMessage("Category doesn't exist");

            RuleFor(x => x.Price).NotEmpty()
                               .WithMessage("Price is required")
                               .GreaterThan(0)
                               .WithMessage("Price must be greater then 0");

            RuleFor(x => x.Images).NotEmpty()
                                .WithMessage("At least one image is required")
                                .DependentRules(() =>
                                {
                                    RuleForEach(x => x.Images).Must((x, fileName) =>
                                    {
                                        var path = Path.Combine("wwwroot", "temp", fileName);
                                        var exists = Path.Exists(path);

                                        return exists;
                                    }).WithMessage("File doesn't exist.");
                                });

            RuleFor(x => x.ProductSpecifications).NotEmpty()
                                               .WithMessage("Product must have at least one specification")
                                               .DependentRules(() =>
                                               {
                                                   RuleForEach(x => x.ProductSpecifications).ChildRules(spec =>
                                                   {
                                                       spec.RuleFor(x => x.SpecificationId).NotEmpty()
                                                                                         .WithMessage("Specification is required")
                                                                                         .Must(sp => ctx.Specifications.Any(s => s.Id == sp))
                                                                                         .WithMessage("Specification doesn't exist");

                                                       spec.RuleFor(x => x.SpecificationValue).NotEmpty()
                                                                                            .WithMessage("Specification value is required");
                                                   });
                                               });
        }
    }
}
