using Carbook.Application.Features.CQRS.Queries.ContactQueries;
using Carbook.Application.Features.CQRS.Results.ContactResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandle
    {
        public readonly IRepository<Contact> _repository;
        public GetContactByIdQueryHandle(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = value.ContactId,
                Email = value.Email,
                Message = value.Message,
                SendDate = value.SendDate,
                Subject = value.Subject,
                Name = value.Name
            };

        }
    }
}
