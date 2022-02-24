namespace BasicProject.Api.controllers
{
    using System.Configuration;
    using System.Reflection;
    using BasicProject.Logger;
    using BasicProject.Services;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class BlogsController : BaseController
    {
        private readonly IBlogsService blogsService;
        private readonly Ilogger logger;

        public BlogsController(IBlogsService blogsService, Ilogger logger) : base(logger)
        {
            this.blogsService = blogsService;
            this.logger = logger;
        }

        [HttpGet("/blogs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetBlogs()
        {
            return this.InvokeAndReturnResult(() =>
            {
                this.logger.Information("Getting blogs");

                var currentApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version;
                var name = ConfigurationManager.AppSettings["name"];

                var blogs = this.blogsService.GetBlogs();

                return blogs;
            }, StatusCodes.Status200OK);
        }

        [HttpGet("/blog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetBlog()
        {
            var blog = this.blogsService.GetBlog("1");
            return this.InvokeAndReturnResult(() =>
            {
                string id = "some-guid";
                this.logger.Information($"Getting blog: {id}");

                var currentApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version;
                var name = ConfigurationManager.AppSettings["name"];

                return blog;
            }, blog != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound);
        }

        [HttpPost("/blog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PostBlog()
        {
            return this.InvokeAndReturnResult(() =>
            {
                this.logger.Information("Creating blog");

                var currentApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version;
                var name = ConfigurationManager.AppSettings["name"];

                var blogs = blogsService.CreateBlog(new Domain.Blog()
                {
                    Title="new title",
                    Content="new content",
                    Author="new author"
                });

                return blogs;
            }, StatusCodes.Status200OK);
        }
    }
}
