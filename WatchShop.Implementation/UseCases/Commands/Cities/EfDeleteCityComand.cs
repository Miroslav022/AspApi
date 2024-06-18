using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Cities;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Cities
{
    public class EfDeleteCityComand : EFUseCase, IDeleteCityCommand
    {
        private readonly DeleteItemValidator<City> _validator;
        public EfDeleteCityComand(AspContext context, DeleteItemValidator<City> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);

            City city = Context.Cities.FirstOrDefault(x=>x.Id == data.Id);
            if (city != null) {
                city.IsActive = !city.IsActive;
                Context.SaveChanges();               
            }
        }
    }
}
