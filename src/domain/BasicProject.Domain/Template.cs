namespace BasicProject.Domain
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Template
    {
        public enum TemplateType
        {
            ECOMMERCE = 0,
            BLOG,
            PRODUCT,
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public TemplateType Type { get; set; }

        public List<Plugin> Plugins { get; set; }
    }
}
