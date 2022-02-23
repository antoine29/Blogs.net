namespace BasicProject.Services
{
    using BasicProject.Domain;

    using System;
    using System.Collections.Generic;

    public interface IBlogsService
    {
        IEnumerable<Blog> GetBlogs();

        Blog GetBlog(string id);

        Blog CreateBlog(Blog blog);
    }
}
