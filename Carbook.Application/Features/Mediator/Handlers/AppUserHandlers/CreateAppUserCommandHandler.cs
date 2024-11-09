using Carbook.Application.Enums;
using Carbook.Application.Features.Mediator.Commands.AppUserCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
	{
		private readonly IRepository<AppUser> _appUserRepository;

		public CreateAppUserCommandHandler(IRepository<AppUser> appUserRepository)
		{
			_appUserRepository = appUserRepository;
		}

		public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
			await _appUserRepository.Create(new AppUser
			{
				Username = request.Username,
				Password = request.Password,
				AppRoleId=(int) RolesType.Member,
				Email = request.Email,
				Name = request.Name,
				Surname = request.Surname,
				
			});
		}
	}
}
