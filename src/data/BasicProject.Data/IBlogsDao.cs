namespace BasicProject.Data
{
    using System;
    using System.Collections.Generic;
    using BasicProject.Domain;

    public interface IBlogsDao
    {
        IList<Blog> GetBlogs();

        Blog GetBlog(Guid id);

        Blog CreateBlog(Blog newBlog);

        Blog UpdateBlog(Guid id, Blog updatedBlog);

        Blog DeleteBlog(Guid id);
    }
}
