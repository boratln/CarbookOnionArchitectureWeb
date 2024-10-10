using Carbook.Application.Features.CQRS.Results.AboutResults;
using Carbook.Application.Features.CQRS.Results.BannerResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values=await _repository.GetAll();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                Description = x.Description,
                Title = x.Title,
                VideoDescription= x.VideoDescription,
                VideoUrl = x.VideoUrl,
            }).ToList();
        }
    }
}
