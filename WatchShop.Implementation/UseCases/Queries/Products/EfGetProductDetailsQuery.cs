using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Images;
using WatchShop.Application.DTO.Product;
using WatchShop.Application.DTO.ProductSpecificationsDtos;
using WatchShop.Application.DTO.Recensions;
using WatchShop.Application.UseCases.Queries.Products;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;

namespace WatchShop.Implementation.UseCases.Queries.Products
{
    public class EfGetProductDetailsQuery : EFUseCase, IProductDetailsQuery
    {
        public EfGetProductDetailsQuery(AspContext context) : base(context)
        {
        }

        public int Id => 34;

        public string Name => "Product Details";

        public ProductDto Execute(int search)
        {
            Product product = Context.Products.FirstOrDefault(x => x.Id == search && x.IsActive);
            ProductDto p = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Prices.OrderByDescending(p => p.CreatedAt).FirstOrDefault().Amount,
                Brand = product.Brand.Name,
                Category = product.Category.Name,
                Images = product.Images.Select(x => new ProductImageDto
                {
                    IsBackground = x.IsBackground,
                    path = x.Image.path,
                }).ToList(),
                Recensions = product.Recensions.Select(x => new RecensionDto
                {
                    Description = x.Description,
                    Title = x.Title,
                    Id = x.Id
                }).ToList(),
                ProductSpecifications = product.ProductSpecifications.Select(x => new ProductSpecificationSearchDto
                {
                    Specification = x.Specification.Name,
                    Value = x.Value
                }).ToList(),
            };
            return p;




        }
    }
}
