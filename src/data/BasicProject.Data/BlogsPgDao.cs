namespace BasicProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BasicProject.Domain;

    public class BlogsPgDao : IBlogsDao
    {
        public BlogsPgDao()
        {

        }

        public Blog CreateBlog(Blog newBlog)
        {
            throw new NotImplementedException();
        }

        public Blog DeleteBlog(Guid id)
        {
            throw new NotImplementedException();
        }

        public Blog GetBlog(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Blog> GetBlogs()
        {
            throw new NotImplementedException();
        }

        public Blog UpdateBlog(Guid id, Blog updatedBlog)
        {
            throw new NotImplementedException();
        }
    }
}
