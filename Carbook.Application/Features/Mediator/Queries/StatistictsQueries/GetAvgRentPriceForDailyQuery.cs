using Carbook.Application.Features.Mediator.Results.StatistictsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Queries.StatistictsQueries
{
    public class GetAvgRentPriceForDailyQuery:IRequest<GetAvgRentPriceForDailyQueryResult>
    {
    }
}
