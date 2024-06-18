using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application
{
    public interface IApplicationActor
    {
        public int Id { get; }
        public string Username { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }

        IEnumerable<int> AllowedUseCases { get; }

        //IEnumerable<Cart> Cart {get;}
    }
}
