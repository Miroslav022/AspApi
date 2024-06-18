using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Categories;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Category;


namespace WatchShop.Implementation.UseCases.Commands.Categories
{
    public class EfCreateCategoryCommand : EFUseCase, ICreateCategoryCommand
    {
        private CreateCategoryDtoValidator _validator;
        public EfCreateCategoryCommand(AspContext context, CreateCategoryDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 3;

        public string Name => GetType().Name;

        public void Execute(NamedEntityDto data)
        {
            _validator.ValidateAndThrow(data);
            Category newCategory = new Category
            {
                Name = data.Name,
            };
            Context.Categories.Add(newCategory);
            Context.SaveChanges();
        }
    }
}
