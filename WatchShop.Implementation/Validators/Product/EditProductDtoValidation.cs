using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Product;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Product
{
    public class EditProductDtoValidation : AbstractValidator<EditProductDto>
    {
        public EditProductDtoValidation(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be grather then 0");

            RuleFor(x=>x.Name).NotEmpty()
                              .WithMessage("Name is required")
                              .MinimumLength(3)
                              .WithMessage("Minimum length is 3 characters");

            RuleFor(x => x.Description).NotEmpty()
                              .WithMessage("Description is required")
                              .MinimumLength(10)
                              .WithMessage("Minimum length is 10 characters");

            RuleFor(x=>x.CategoryId).Must(x=>ctx.Categories.Any(c=>c.Id==x))
                                    .WithMessage("Category doesn't exist");

            RuleFor(x => x.BrandId).Must(x => ctx.Brands.Any(b => b.Id == x))
                                    .WithMessage("Brand doesn't exist");

            RuleFor(x => x.Id).Must(x => ctx.Products.Any(p => p.Id == x))
                                   .WithMessage("Product doesn't exist");

        }
    }
}
