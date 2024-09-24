using Carbook.Application.Features.CQRS.Results.ContactResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAll();
            return values.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Email = x.Email,
                Message = x.Message,
                SendDate = x.SendDate,
                Subject=x.Subject,
                Name = x.Name
            }).ToList();
        }
    }
}
