using System.IdentityModel.Tokens.Jwt;
using WatchShop.Application.UseCases.Commands.Brands;
using WatchShop.Application.UseCases.Commands.Carts;
using WatchShop.Application.UseCases.Commands.Categories;
using WatchShop.Application.UseCases.Commands.Cities;
using WatchShop.Application.UseCases.Commands.CommonUseCase;
using WatchShop.Application.UseCases.Commands.Countries;
using WatchShop.Application.UseCases.Commands.Images;
using WatchShop.Application.UseCases.Commands.Orders;
using WatchShop.Application.UseCases.Commands.Products;
using WatchShop.Application.UseCases.Commands.Recensions;
using WatchShop.Application.UseCases.Commands.Specifications;
using WatchShop.Application.UseCases.Commands.Statuses;
using WatchShop.Application.UseCases.Commands.Users;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.UseCases.Commands.Brands;
using WatchShop.Implementation.UseCases.Commands.Carts;
using WatchShop.Implementation.UseCases.Commands.Categories;
using WatchShop.Implementation.UseCases.Commands.Cities;
using WatchShop.Implementation.UseCases.Commands.Countries;
using WatchShop.Implementation.UseCases.Commands.Images;
using WatchShop.Implementation.UseCases.Commands.Orders;
using WatchShop.Implementation.UseCases.Commands.Products;
using WatchShop.Implementation.UseCases.Commands.Recensions;
using WatchShop.Implementation.UseCases.Commands.ProductSpecifications;
using WatchShop.Implementation.UseCases.Commands.Specifications;
using WatchShop.Implementation.UseCases.Commands.Statuses;
using WatchShop.Implementation.UseCases.Commands.Users;
using WatchShop.Implementation.Validators.Brand;
using WatchShop.Implementation.Validators.Cart;
using WatchShop.Implementation.Validators.Category;
using WatchShop.Implementation.Validators.City;
using WatchShop.Implementation.Validators.Common;
using WatchShop.Implementation.Validators.Country;
using WatchShop.Implementation.Validators.Order;
using WatchShop.Implementation.Validators.Product;
using WatchShop.Implementation.Validators.ProductSpecificationValidator;
using WatchShop.Implementation.Validators.Recension;
using WatchShop.Implementation.Validators.Specification;
using WatchShop.Implementation.Validators.Status;
using WatchShop.Implementation.Validators.User;
using WatchShop.Application.UseCases.Commands.ProductSpecificationsCommands;
using WatchShop.Application.UseCases.Queries.Brands;
using WatchShop.Implementation.UseCases.Queries.Brands;
using WatchShop.Application.UseCases.Queries.Products;
using WatchShop.Implementation.UseCases.Queries.Products;
using WatchShop.Application.UseCases.Queries.Categories;
using WatchShop.Implementation.UseCases.Queries.Categories;
using WatchShop.Application.UseCases.Queries.Specifications;
using WatchShop.Implementation.UseCases.Queries.Specifications;
using WatchShop.Application.UseCases.Queries.Users;
using WatchShop.Implementation.UseCases.Queries.Users;
using WatchShop.Application.UseCases.Queries.Countries;
using WatchShop.Implementation.UseCases.Queries.Countries;
using WatchShop.Application.UseCases.Queries.Statuses;
using WatchShop.Implementation.UseCases.Queries.Statuses;
using WatchShop.Application.UseCases.Queries.Cities;
using WatchShop.Implementation.UseCases.Queries.Cities;
using WatchShop.Application.UseCases.Queries.Orders;
using WatchShop.Implementation.UseCases.Queries.Orders;
using WatchShop.Application.UseCases.Queries.Carts;
using WatchShop.Implementation.UseCases.Queries.Carts;

namespace watchShopApi.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IRegisterUserCommand, EFRegisterUserCommand>();
            services.AddTransient<ICreateBrandCommand, EFCreateBrandCommand>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<ICreateSpecificationCommand, EfCreateSpecificationCommand>();
            services.AddTransient<ICreateCountryCommand, EfCreateCountryCommand>();
            services.AddTransient<ICreateCityCommand, EfCreateCityCommand>();
            services.AddTransient<ICreateStatusCommand, EfCreateStatusCommand>();
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<ICreateRecensionCommand, EfCreateRecensionCommand>();
            services.AddTransient<IAddToCartCommand, EfAddToCartCommand>();
            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IDeleteStatusCommand, EfDeleteStatusCommand>();
            services.AddTransient<IDeleteSpecificationCommand, EfDeleteSpecificationCommand>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IDeleteCountryCommand, EfDeleteCountryCommand>();
            services.AddTransient<IDeleteCityCommand, EfDeleteCityComand>();
            services.AddTransient<IDeleteImageCommand, EfDeleteImageCommand>();
            services.AddTransient<IDeleteRecensionCommand, EfDeleteRecensionCommand>();
            services.AddTransient<IDeleteProductSpecification, EfDeleteProductSpecificationCommand>();
            services.AddTransient<IDeleteCartItemCommand, EfDeleteCartItemCommand>();
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<IProductSearchQuery, EfGetProductsQuery>();
            services.AddTransient<ICreateProductSpecificationCommand, EfCreateProductSpecificationCommand>();
            services.AddTransient<ICategorySearchQuery, EfGetCategoriesQuery>();
            services.AddTransient<IGetSpecificationsQuery, EfGetSpecificationsQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetCountryQuery, EfGetCountryQuery>();
            services.AddTransient<IGetStatusesQuery, EfGetStatusesQuery>();
            services.AddTransient<IGetCitiesQuery, EfGetCitiesQuery>();
            services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>();
            services.AddTransient<IGetCartsQuery, EfGetCartQuery>();
            services.AddTransient<IProductDetailsQuery, EfGetProductDetailsQuery>();

            services.AddTransient<RegisterUserDtoValidator>();
            services.AddTransient<BrandDtoValidator>();
            services.AddTransient<CreateCategoryDtoValidator>();
            services.AddTransient<CreateSpecificationDtoValidator>();
            services.AddTransient<CreateCountryDtoValidator>();
            services.AddTransient<CreateCityDtoValidator>();
            services.AddTransient<CreateStatusDtoValidator>();
            services.AddTransient<CreateProductDtoValidator>();
            services.AddTransient<CreateRecensionDtoValidator>();
            services.AddTransient<AddToCartDtoValidator>();
            services.AddTransient<CreateOrderDtoValidation>();
            services.AddTransient<DeleteItemValidator<Brand>>();
            services.AddTransient<DeleteItemValidator<Category>>();
            services.AddTransient<DeleteItemValidator<Status>>();
            services.AddTransient<DeleteItemValidator<Specification>>();
            services.AddTransient<DeleteItemValidator<Product>>();
            services.AddTransient<DeleteItemValidator<User>>();
            services.AddTransient<DeleteItemValidator<Country>>();
            services.AddTransient<DeleteItemValidator<City>>();
            services.AddTransient<DeleteItemValidator<Image>>();
            services.AddTransient<DeleteItemValidator<Recension>>();
            services.AddTransient<DeleteItemValidator<CartItem>>();
            services.AddTransient<DeleteProductSpecificationValidator>();
            services.AddTransient<CreateProductSpecificationDtoValidator>();
        }
        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
