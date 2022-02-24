
namespace BasicProject.Domain
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Blog
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }
    }
}
