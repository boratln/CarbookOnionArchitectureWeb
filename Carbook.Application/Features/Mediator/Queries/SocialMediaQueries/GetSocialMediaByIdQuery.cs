using Carbook.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery:IRequest<GetSocialMediaByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
