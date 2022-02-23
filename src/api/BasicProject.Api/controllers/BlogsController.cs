namespace BasicProject.Api.controllers
{
    using BasicProject.Logger;
    using BasicProject.Services;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Configuration;
    using System.Reflection;

    [ApiController]
    public class BlogsController : BaseController
    {
        private readonly IBlogsService blogsService;
        private readonly Ilogger logger;

        public BlogsController(IBlogsService _blogsService, Ilogger logger) : base(logger)
        {
            this.blogsService = _blogsService;
            this.logger = logger;
        }

        [HttpGet("/blogs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetBlogs()
        {
            return InvokeAndReturnResult(() =>
            {
                logger.Information("Calling to Index");

                var currentApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version;
                var name = ConfigurationManager.AppSettings["name"];

                var blogs = blogsService.GetBlogs();

                return blogs;
            }, StatusCodes.Status200OK);   
        }

        [HttpGet("/blog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetBlog()
        {
            return InvokeAndReturnResult(() =>
            {
                logger.Information("Calling to Index");

                var currentApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version;
                var name = ConfigurationManager.AppSettings["name"];

                var blogs = blogsService.GetBlog("1");

                return blogs;
            }, StatusCodes.Status200OK);   
        }

        [HttpPost("/blog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PostBlog()
        {
            return InvokeAndReturnResult(() =>
            {
                logger.Information("Calling to Index");

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
