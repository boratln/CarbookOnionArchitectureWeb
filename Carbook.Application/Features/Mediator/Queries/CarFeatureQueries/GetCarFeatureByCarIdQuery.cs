using Carbook.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery:IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int Id {  get; set; }

        public GetCarFeatureByCarIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
