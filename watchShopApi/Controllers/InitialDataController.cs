using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {

            AspContext ctx = new AspContext();
            Brand b = new Brand
            {
                Name = "Rolex"
            };
            Brand b2 = new Brand
            {
                Name = "Casio"
            };

            Category c1 = new Category
            {
                Name = "Luxury"
            };

            Category c2 = new Category
            {
                Name = "Sport"
            };

            Specification s1 = new Specification
            {
                Name = "Material"
            };

            Specification s2 = new Specification
            {
                Name = "Dial"
            };

            Image i1 = new Image { path = "slika1.png" };
            Image i2 = new Image { path = "slika2.png" };


            Product p1 = new Product
            {
                Name = "Sat Proizvod 1",
                Description = "Description Description 1",
                Category = c1,
                Brand = b,
                Prices = new HashSet<Price>
                {
                    new Price {Amount = 199.99m }
                },
            };

            ProductSpecification ps1 = new ProductSpecification
            {
                Specification = s1,
                Value = "vrednost spec 1",
                Product = p1,
            };

            ProductImage pi1 = new ProductImage
            {
                Product = p1,
                Image = i1
            };


            Product p2 = new Product
            {
                Name = "Sat Proizvod 2",
                Description = "Description Description 2",
                Category = c2,
                Brand = b2,
                Prices = new HashSet<Price>
                {
                    new Price { Amount = 399.99m }
                },
            };

            ProductSpecification ps2 = new ProductSpecification
            {
                Specification = s2,
                Value = "vrednost spec 2",
                Product = p2,
            };

            ProductImage pi2 = new ProductImage
            {
                Product = p2,
                Image = i2
            };

            var user1 = new User
            {
                Email = "user.@gmail.com",
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Password = BCrypt.Net.BCrypt.HashPassword("Projekat123!"),
                BirthDate = new DateTime(1990, 5, 15),
                Location = new Location
                {
                    Address = "Adresa 2",
                    City = new City
                    {
                        Name = "Berlin",
                        Country = new Country
                        {
                            Name = "Germany"
                        }
                    }
                },
                Image = new Image { path = "default.png " },
            };
            var allowedUseCasesForNewUser = new List<int> { 10, 11, 22, 24, 29, 30, 34, 35, 37, 40 };
            List<UserUseCase> AllUseCasesUser = new List<UserUseCase>();

            foreach (var i in allowedUseCasesForNewUser)
            {
                AllUseCasesUser.Add(new UserUseCase { UseCaseId = i, User = user1 });
            }

            var user2 = new User
            {
                Email = "admin@gmail.com",
                FirstName = "Jane",
                LastName = "Smith",
                Username = "janesmith",
                Password = BCrypt.Net.BCrypt.HashPassword("Projekat123!"),
                BirthDate = new DateTime(1985, 8, 25),
                Location = new Location
                {
                    Address = "Adresa 1",
                    City = new City
                    {
                        Name = "Beograd",
                        Country = new Country
                        {
                            Name = "Serbia"
                        }
                    }
                },
                Image = new Image { path = "default.png " },

            };
            List<UserUseCase> AllUseCases = new List<UserUseCase>();
            for (int i = 1; i < 43; i++)
            {
                AllUseCases.Add(new UserUseCase { UseCaseId = i, User = user2 });
            }


            Status stat1 = new Status
            {
                Name = "Delivered"
            };

            Status stat2 = new Status
            {
                Name = "Confirmed"
            };

            ctx.Statuses.Add(stat1);
            ctx.Statuses.Add(stat2);

            ctx.ProductSpecifications.Add(ps1);
            ctx.ProductImages.Add(pi1);

            ctx.ProductSpecifications.Add(ps2);
            ctx.ProductImages.Add(pi2);

            ctx.UserUseCases.AddRange(AllUseCases);
            ctx.UserUseCases.AddRange(AllUseCasesUser);

            ctx.SaveChanges();

            return Created();

        }
    }
}
