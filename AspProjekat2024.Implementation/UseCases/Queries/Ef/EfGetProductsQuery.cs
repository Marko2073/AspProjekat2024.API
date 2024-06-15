using AspProjekat2024.Application.DTO;
using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspProjekat2024.Implementation.UseCases.Queries.Ef
{
    public class EfGetProductsQuery : EfUseCase, IGetProductsQuery
    {
        public EfGetProductsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Get Products";

        public string Description => "Get All Products";

        public IEnumerable<ProductDto> Execute(ProductsSearch search)
        {
            var query = Context.ModelVersions.AsQueryable();

            if (search.BrandId != null)
            {
                query = query.Where(x => x.Model.BrandId == search.BrandId);
            }
            if (search.ModelId != null)
            {
                query = query.Where(x => x.ModelId == search.ModelId);
            }
            if (search.ModelVersionId != null)
            {
                query = query.Where(x => x.Id == search.ModelVersionId);
            }
            if (search.SpecificationIds != null && search.SpecificationIds.Any())
            {
                query = query.Where(x => x.ModelVersionSpecifications.Any(y => search.SpecificationIds.Contains(y.SpecificationId)));
            }

            // Dodavanje paginacije
            var skipCount = (search.Page.GetValueOrDefault(1) - 1) * search.ItemsPerPage.GetValueOrDefault(5);
            query = query.Skip(skipCount).Take(search.ItemsPerPage.GetValueOrDefault(5));

            var products = query.Select(x => new ProductDto
            {
                Id = x.Id,
                BrandId = x.Model.BrandId,
                BrandName = x.Model.Brand.Name,
                ModelId = x.ModelId,
                ModelName = x.Model.Name,
                ModelVersionId = x.Id,
                StockQuantity = x.StockQuantity,
                Price = 0,
                Specifications = x.ModelVersionSpecifications.Select(y => new SpecificationDto
                {
                    Id = y.SpecificationId,
                    Name = y.Specification.Name,
                    Parent = y.Specification.Parent.Name
                }).ToList(),
                Pictures = x.Pictures.Select(y => new PicturesDto
                {
                    Id = y.Id,
                    Path = y.Path,

                }).ToList()
            }).ToList();

            return products;
        }
    }
}
