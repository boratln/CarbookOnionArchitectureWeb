﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Dto.CommentDtos
{
    public class CreateCommentDto
    {
        public string Name { get; set; }
        public string Email {  get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentText { get; set; }
        public int BlogId { get; set; }
    }
}