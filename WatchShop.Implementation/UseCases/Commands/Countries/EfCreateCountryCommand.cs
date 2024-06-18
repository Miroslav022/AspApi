using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Countries;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Country;

namespace WatchShop.Implementation.UseCases.Commands.Countries
{
    public class EfCreateCountryCommand : EFUseCase, ICreateCountryCommand
    {
        private readonly CreateCountryDtoValidator _validator;
        public EfCreateCountryCommand(AspContext context, CreateCountryDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => GetType().Name;


        public void Execute(NamedEntityDto data)
        {
            _validator.ValidateAndThrow(data);
            Country newCountry = new Country
            {
                Name = data.Name,
            };
            Context.Countries.Add(newCountry);
            Context.SaveChanges();
        }
    }
}
