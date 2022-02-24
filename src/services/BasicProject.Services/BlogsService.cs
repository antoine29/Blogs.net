namespace BasicProject.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BasicProject.Data;
    using BasicProject.Domain;

    public class BlogsService : IBlogsService
    {
        private IBlogsDao blogsDao;

        public BlogsService(IBlogsDao blogsDao)
        {
            this.blogsDao = blogsDao;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return this.blogsDao.GetBlogs();
        }

        public Blog GetBlog(string id)
        {
            return this.blogsDao.GetBlog(Guid.Parse(id));
        }

        public Blog CreateBlog(Blog newBlog)
        {
            newBlog.Id = Guid.NewGuid();
            return this.blogsDao.CreateBlog(newBlog);
        }
    }
}
