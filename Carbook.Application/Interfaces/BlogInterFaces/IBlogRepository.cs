﻿using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Interfaces.BlogInterFaces
{
    public interface IBlogRepository
    {
        public Blog GetByBlog(int id);
        public List<Blog> GetLast3BlogWithAuthors();
        public List<Blog> GetAllBlogsWithAuthors();
        public Blog GetByBlogWithAuthor(int id);
    }
}
