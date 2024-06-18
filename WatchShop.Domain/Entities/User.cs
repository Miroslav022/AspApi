using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int? ProfileImageId { get; set; }

        public int LocationId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new List<UserUseCase>();
        public virtual ICollection<Recension> Recensions { get; set; } = new List<Recension>();
        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}
