using Carbook.Application.Features.Mediator.Queries.AppUserQueries;
using Carbook.Application.Features.Mediator.Results.AppUserResults;
using Carbook.Application.Interfaces;
using Carbook.Application.Interfaces.AppUserInterfaces;
using Carbook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IRepository<AppUser> _appUserRepository;
		private readonly IRepository<AppRole> _appRoleRepository;

		public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
		{
			_appUserRepository = appUserRepository;
			_appRoleRepository = appRoleRepository;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();
			var user = await _appUserRepository.GetByFilter(x=>x.Username== request.Username && x.Password==request.Password);
			if (user == null)
			{
				values.IsExist = false;
			}
			else
			{
				values.IsExist = true;
				values.Username = user.Username;
				values.Role = (await _appRoleRepository.GetByFilter(x => x.AppRoleId == user.AppRoleId))?.AppRoleName;
				values.Id = user.AppUserId;
			}
			return values;
			
		}
	}
}
