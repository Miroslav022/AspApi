using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.Recensions
{
    public class CreateRecensionDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
