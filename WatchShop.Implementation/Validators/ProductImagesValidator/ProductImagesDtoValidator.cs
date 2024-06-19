using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Product;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.ProductImagesValidator
{
    public class ProductImagesDtoValidator : AbstractValidator<EditProductImage>
    {
        public ProductImagesDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ProductId).Must(x => ctx.Products.Any(p => p.Id == x)).WithMessage("Product doesn't exist");
            RuleFor(x => x.ImageId).Must(x => ctx.Images.Any(i => i.Id == x)).WithMessage("Image doesn't exist");
        }
    }
}
