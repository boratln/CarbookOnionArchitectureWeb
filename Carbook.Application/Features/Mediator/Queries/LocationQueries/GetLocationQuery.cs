using Carbook.Application.Features.Mediator.Results.LocationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery:IRequest<List<GetLocationQueryResult>>
    {
    }
}
