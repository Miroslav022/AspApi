using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Brands;
using WatchShop.Application.DTO.Images;
using WatchShop.Application.DTO.Product;
using WatchShop.Application.DTO.ProductSpecificationsDtos;
using WatchShop.Application.DTO.Recensions;
using WatchShop.Application.UseCases.Queries.Products;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases.Queries.Products
{
    public class EfGetProductsQuery : EFUseCase, IProductSearchQuery
    {
        public EfGetProductsQuery(AspContext context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "Search products";

        public PagedResponse<ProductDto> Execute(ProductSearch search)
        {

            var query = Context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }
            if (!string.IsNullOrEmpty(search.Category))
            {
                query = query.Where(x=>x.Category.Name == "dsads");
            }
            if (!string.IsNullOrEmpty(search.Brand))
            {
                query = query.Where(x => x.Brand.Name == search.Brand);
            }
            if (search.PriceFrom > 0)
            {
                query = query.Where(x => x.Prices.First(p=>p.IsActive).Amount > search.PriceFrom );
            }
            if (search.PriceTo > 0 && (search.PriceFrom>0 ? search.PriceFrom < search.PriceTo : true))
            {
                query = query.Where(x => x.Prices.First(p => p.IsActive).Amount < search.PriceTo);
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<ProductDto>
            {
                CurrentPage = page,
                Data = query.Select(x=>new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Brand = x.Brand.Name,
                    Category = x.Category.Name,
                    Images = x.Images.Select(img=>new ProductImageDto
                    {
                        path = img.Image.path,
                        IsBackground = img.IsBackground,
                    }).ToList(),
                    Price = x.Prices.OrderByDescending(p => p.CreatedAt).FirstOrDefault().Amount,
                    Recensions = x.Recensions.Select(r=>new RecensionDto
                    {
                        Description = r.Description,
                        Title = r.Title,
                        Id = r.Id,
                    }).ToList(),
                    ProductSpecifications = x.ProductSpecifications.Select(ps=>new ProductSpecificationSearchDto
                    {
                        Specification = ps.Specification.Name,
                        Value = ps.Value,
                    }).ToList(),

                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
