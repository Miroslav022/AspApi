using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;

namespace WatchShop.Application.DTO.Cities
{
    public class CityDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public NamedSearchDto Country { get; set; }
    }
}
