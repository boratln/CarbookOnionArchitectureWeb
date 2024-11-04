using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
       Task< List<RentACar>> GetByFilter(Expression<Func<RentACar, bool>> filter);
    }
}
