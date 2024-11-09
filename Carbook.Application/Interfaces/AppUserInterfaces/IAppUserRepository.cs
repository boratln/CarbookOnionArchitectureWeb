using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Interfaces.AppUserInterfaces
{
	public interface IAppUserRepository
	{
		Task<List<AppUser>> GetByFilter(Expression<Func<AppUser, bool>> filter);
	}
}
