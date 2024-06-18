using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application;
using WatchShop.Application.DTO.Recensions;
using WatchShop.Application.UseCases.Commands.Recensions;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Recension;

namespace WatchShop.Implementation.UseCases.Commands.Recensions
{
    public class EfCreateRecensionCommand : EFUseCase, ICreateRecensionCommand
    {
        private readonly CreateRecensionDtoValidator _valdiator;
        private readonly IApplicationActor _actor;
        public EfCreateRecensionCommand(AspContext context, CreateRecensionDtoValidator valdiator, IApplicationActor actor) : base(context)
        {
            _valdiator = valdiator;
            _actor = actor;
        }

        public int Id => 9;

        public string Name => GetType().Name;

        public void Execute(CreateRecensionDto data)
        {
            _valdiator.ValidateAndThrow(data);
            Recension newRecension = new Recension
            {
                ProductId = data.ProductId,
                UserId = _actor.Id,
                Title = data.Title,
                Description = data.Description,
            };

            Context.Recensions.Add(newRecension);
            Context.SaveChanges();
        }
    }
}
