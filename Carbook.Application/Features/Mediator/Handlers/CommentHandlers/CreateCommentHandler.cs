using Carbook.Application.Features.Mediator.Commands.CommentCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.CommandHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _commentrepository;

        public CreateCommentHandler(IRepository<Comment> commentrepository)
        {
            _commentrepository = commentrepository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _commentrepository.Create(new Comment
            {
                BlogId = request.BlogId,
                CommentText = request.CommentText,
                CreatedDate = request.CreatedDate,
                Name = request.Name,
                Email=request.Email
            });
        }
    }
}
