using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Brands;
using WatchShop.Application.UseCases.Commands.CommonUseCase;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Categories
{
    public class EfDeleteCategoryCommand : EFUseCase, IDeleteCategoryCommand
    {
        private readonly DeleteItemValidator<Category> _validator;
        public EfDeleteCategoryCommand(AspContext context, DeleteItemValidator<Category> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);

            Category categoryToDelete = Context.Categories.FirstOrDefault(x=>x.Id == data.Id);
            categoryToDelete.IsActive = false;
            Context.SaveChanges();
        }
    }
}
