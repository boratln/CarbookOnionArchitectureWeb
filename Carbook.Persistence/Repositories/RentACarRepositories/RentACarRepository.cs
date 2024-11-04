using Carbook.Application.Features.Mediator.Results.RentACarResults;
using Carbook.Application.Interfaces.RentACarInterfaces;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarbookContext _context;

        public RentACarRepository(CarbookContext context)
        {
            _context = context;
        }

        public async Task <List<RentACar>> GetByFilter(Expression<Func<RentACar, bool>> filter)
        {
            var values = await _context.RentACars.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
         
            return values;
        }
    }
}
