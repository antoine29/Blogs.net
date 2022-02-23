namespace BasicProject.Services
{
    using BasicProject.Data;
    using BasicProject.Domain;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BlogsService : IBlogsService
    {
        private readonly ICheckSystemDAO checkSystemDAO;

        public BlogsService(ICheckSystemDAO checkSystemDAO)
        {
            this.checkSystemDAO = checkSystemDAO;
        }

        IEnumerable<Blog> IBlogsService.GetBlogs()
        {
            return new List<Blog> {
                new Blog()
                {
                    Author = "author0",
                    Content = "content0",
                    Title = "title0"
                },
                new Blog()
                {
                    Author = "author1",
                    Content = "content1",
                    Title = "title1"
                },
                new Blog()
                {
                    Author = "author2",
                    Content = "content2",
                    Title = "title2"
                },
            };
        }

        Blog IBlogsService.GetBlog(string id)
        {
            return new Blog()
            {
                Author = "author0",
                Content = "content0",
                Title = "title0"
            };
        }

        Blog IBlogsService.CreateBlog(Blog blog)
        {
            return blog;
        }
    }
}
