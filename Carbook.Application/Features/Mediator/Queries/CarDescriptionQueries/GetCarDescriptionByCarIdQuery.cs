using Carbook.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery : IRequest<GetCarDescriptionByCarIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarDescriptionByCarIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
