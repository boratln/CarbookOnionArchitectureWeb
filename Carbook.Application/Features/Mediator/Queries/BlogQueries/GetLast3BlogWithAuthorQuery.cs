﻿using Carbook.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetLast3BlogWithAuthorQuery:IRequest<List<GetLast3BlogWithAuthorQueryResult>>
    {
    }
}