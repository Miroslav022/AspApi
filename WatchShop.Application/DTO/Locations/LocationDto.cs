﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Domain.Entities;

namespace WatchShop.Application.DTO.Locations
{
    public class LocationDto
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
