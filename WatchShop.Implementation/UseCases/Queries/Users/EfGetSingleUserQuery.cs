using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Images;
using WatchShop.Application.DTO.Locations;
using WatchShop.Application.DTO.Users;
using WatchShop.Application.UseCases.Queries.Users;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;

namespace WatchShop.Implementation.UseCases.Queries.Users
{
    public class EfGetSingleUserQuery : EFUseCase, IGetSingleUserQuery
    {
        public EfGetSingleUserQuery(AspContext context) : base(context)
        {
        }

        public int Id => 36;

        public string Name => "Show user";

        public UserDto Execute(int search)
        {
            User user = Context.Users.FirstOrDefault(x=>x.Id== search);
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                BirthDate = user.BirthDate,

                Location = new LocationDto
                {
                    Address = user.Location.Address,
                    City = user.Location.City.Name,
                    Country = user.Location.City.Country.Name
                },
                Image = new ImageDto
                {
                    path = user.Image.path
                }

            };
        }
    }
}
