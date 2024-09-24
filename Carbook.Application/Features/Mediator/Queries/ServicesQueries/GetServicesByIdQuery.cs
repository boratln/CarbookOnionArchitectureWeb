using Carbook.Application.Features.Mediator.Results.ServicesResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Queries.ServicesQueries
{
    public class GetServicesByIdQuery:IRequest<GetServicesByIdQueryResult>
    {
        public int Id { get; set; }

        public GetServicesByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
