using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Category
{
    public class CreateCategoryDtoValidator : AbstractValidator<NamedEntityDto>
    {
        public CreateCategoryDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x=>x.Name).NotEmpty().WithMessage("Category name is required")
                              .Must(x=> !ctx.Categories.Any(c=>c.Name==x)).WithMessage("Category already exists");
        }
    }
}
