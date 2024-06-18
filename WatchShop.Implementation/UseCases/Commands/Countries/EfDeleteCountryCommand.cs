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
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Countries
{
    public class EfDeleteCountryCommand : EFUseCase, IDeleteCountryCommand
    {
        private readonly DeleteItemValidator<Country> _validator;
        public EfDeleteCountryCommand(AspContext context, DeleteItemValidator<Country> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id =>17;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);
            Country country = Context.Countries.FirstOrDefault(x => x.Id == data.Id);
            if(country!=null)
            {
                country.IsActive = !country.IsActive;
                Context.SaveChanges();
            }
        }
    }
}
