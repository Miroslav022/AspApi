using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.Cities
{
    public class CreateCityDto
    {
        public string City { get; set; }
        public int CountryId { get; set; }
    }
}
