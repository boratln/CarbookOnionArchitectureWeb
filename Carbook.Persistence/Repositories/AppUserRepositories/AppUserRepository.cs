using Carbook.Application.Interfaces.AppUserInterfaces;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.AppUserRepositories
{
	public class AppUserRepository : IAppUserRepository
	{
		private readonly CarbookContext _carbookContext;

		public AppUserRepository(CarbookContext carbookContext)
		{
			_carbookContext = carbookContext;
		}

		public async Task<List<AppUser>> GetByFilter(Expression<Func<AppUser, bool>> filter)
		{
			var values = await _carbookContext.AppUsers.Where(filter).ToListAsync();

			return values;
		}
	}
}
