using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Images;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Images
{
    public class EfDeleteImageCommand : EFUseCase, IDeleteImageCommand
    {
        private readonly DeleteItemValidator<Image> _validator;
        public EfDeleteImageCommand(AspContext context, DeleteItemValidator<Image> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 19;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);

            Image image = Context.Images.FirstOrDefault(x=>x.Id == data.Id);
            if (image != null) {
                image.IsActive = !image.IsActive;
                Context.SaveChanges();
            }
        }
    }
}
