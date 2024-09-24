using Carbook.Application.Features.CQRS.Queries.BannerQueries;
using Carbook.Application.Features.CQRS.Results.BannerResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerId = value.BannerId,
                Description = value.Description,
                Title = value.Title,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl,
            };

        }
    }
}
