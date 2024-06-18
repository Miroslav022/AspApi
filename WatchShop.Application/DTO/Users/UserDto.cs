using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Images;
using WatchShop.Application.DTO.Locations;
using WatchShop.Domain.Entities;

namespace WatchShop.Application.DTO.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }

        public LocationDto Location { get; set; }
        public ImageDto Image { get; set; }

    }
}
