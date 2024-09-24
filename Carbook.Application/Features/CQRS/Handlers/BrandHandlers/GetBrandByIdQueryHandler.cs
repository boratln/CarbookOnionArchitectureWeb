using Carbook.Application.Features.CQRS.Results.BrandResults;
using Carbook.Application.Features.CQRS.Queries.BannerQueries;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carbook.Application.Features.CQRS.Queries.BrandQueries;

namespace Carbook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            return new GetBrandByIdQueryResult
            {
                BrandId = value.BrandId,
                Name = value.Name,
            };
        }
    }
}
