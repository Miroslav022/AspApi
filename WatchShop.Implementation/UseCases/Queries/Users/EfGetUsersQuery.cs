using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Categories;
using WatchShop.Application.DTO.Images;
using WatchShop.Application.DTO.Locations;
using WatchShop.Application.DTO.Users;
using WatchShop.Application.UseCases.Queries.Users;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases.Queries.Users
{
    public class EfGetUsersQuery : EFUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(AspContext context) : base(context)
        {
        }

        public int Id => 28;

        public string Name => "Search Users";

        public PagedResponse<UserDto> Execute(SearchUserDto search)
        {
            var query = Context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(search.FirstName))
            {
                query = query.Where(x => x.FirstName.Contains(search.FirstName));
            }
            if (!string.IsNullOrEmpty(search.LastName))
            {
                query = query.Where(x => x.LastName.Contains(search.LastName));
            }
            if (!string.IsNullOrEmpty(search.UserName))
            {
                query = query.Where(x => x.Username.Contains(search.UserName));
            }
            if (!string.IsNullOrEmpty(search.City))
            {
                query = query.Where(x => x.Location.City.Name.Contains(search.City));
            }



            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<UserDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new UserDto {
                    Id = x.Id, 
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username,
                    BirthDate = x.BirthDate,
                    Location = new LocationDto
                    {
                        Address = x.Location.Address,
                        City = x.Location.City.Name,
                        Country = x.Location.City.Country.Name
                    },
                    Image = new ImageDto
                    {
                        path = x.Image.path
                    }
                    
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
