using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Cities;
using WatchShop.Application.UseCases.Commands.Cities;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Category;
using WatchShop.Implementation.Validators.City;

namespace WatchShop.Implementation.UseCases.Commands.Cities
{
    public class EfCreateCityCommand : EFUseCase, ICreateCityCommand
    {
        private readonly CreateCityDtoValidator _validator;
        public EfCreateCityCommand(AspContext context, CreateCityDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 6;

        public string Name => GetType().Name;

        public void Execute(CreateCityDto data)
        {
            _validator.ValidateAndThrow(data);
            City newCity = new City
            {
                Name = data.City,
                CountryId = data.CountryId,
            };
            Context.Cities.Add(newCity);
            Context.SaveChanges();
        }
    }
}
