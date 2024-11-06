using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand:IRequest
    {
        public string Name {  get; set; }
        public string Email {  get; set; }
        public DateTime CreatedDate {  get; set; }
        public int BlogId {  get; set; }
        public string CommentText {  get; set; }
    }
}
