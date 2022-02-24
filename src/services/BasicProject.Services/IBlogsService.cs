namespace BasicProject.Services
{
    using System;
    using System.Collections.Generic;
    using BasicProject.Domain;

    public interface IBlogsService
    {
        IEnumerable<Blog> GetBlogs();

        Blog GetBlog(string id);

        Blog CreateBlog(Blog newBlog);
    }
}
