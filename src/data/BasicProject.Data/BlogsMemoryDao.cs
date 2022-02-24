namespace BasicProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BasicProject.Data;
    using BasicProject.Domain;

    public class BlogsMemoryDao : IBlogsDao
    {
        private List<Blog> inMemoryBlogs = new List<Blog>
        {
                new Blog()
                {
                    Id = Guid.Parse("ca5a42e4-a4d1-41d8-97dd-af4253a3d70b"),
                    Author = "author0",
                    Content = "content0",
                    Title = "title0",
                },
                new Blog()
                {
                    Id = Guid.Parse("ca5a42e4-a4d1-41d8-97dd-af4253a3d81b"),
                    Author = "author1",
                    Content = "content1",
                    Title = "title1",
                },
                new Blog()
                {
                    Id = Guid.Parse("ca5a42e4-a4d1-41d8-97dd-af4253a3d90b"),
                    Author = "author2",
                    Content = "content2",
                    Title = "title2",
                },
        };

        public IList<Blog> GetBlogs()
        {
            return this.inMemoryBlogs;
        }

        public Blog DeleteBlog(Guid id)
        {
            Blog deletedBlog = null;
            var filteredProjects = this.inMemoryBlogs.Where(blog =>
            {
                if (blog.Id.Equals(id))
                {
                    deletedBlog = blog;
                }

                return !blog.Id.Equals(id);
            });

            return deletedBlog;
        }

        public Blog GetBlog(Guid id)
        {
            return this.inMemoryBlogs.Find(blog => blog.Id.Equals(id));
        }

        public Blog UpdateBlog(Guid id, Blog updatedBlog)
        {
            this.inMemoryBlogs = this.inMemoryBlogs.Select(blog =>
            {
                if (blog.Id.Equals(id))
                {
                    return updatedBlog;
                }

                return blog;
            }).ToList();

            return this.GetBlog(id);
        }

        public Blog CreateBlog(Blog newBlog)
        {
            this.inMemoryBlogs.Add(newBlog);
            return newBlog;
        }
    }
}
