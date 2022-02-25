namespace BasicProject.Data
{
    using System;
    using System.Collections.Generic;
    using BasicProject.Domain;

    public abstract class SqlAbstract : ISqlServerDAO
    {
        public abstract bool Create(object any);

        public bool Delete<T>(string id)
        {
            if (id == "1")
            {
                return true;
            }

            if (id == "fatal-id")
            {
                throw new Exception("Exception raised from SQL Data Layer");
            }

            return false;
        }

        public T FindOne<T>(string filter)
        {
            if (filter.Equals("Duplicated Name", StringComparison.InvariantCultureIgnoreCase))
            {
                var harcodedInstance = (T)Activator.CreateInstance(typeof(T));

                return harcodedInstance;
            }

            // Harcoded instance
            var instance = (T)Activator.CreateInstance(typeof(T));
            var propertyType = instance.GetType().GetProperty("Type");

            // Todo: replace with object in a real database
            if (filter.Contains("1"))
            {
                propertyType.SetValue(instance, Template.TemplateType.ECOMMERCE);
                return instance;
            }

            if (filter.Contains("2"))
            {
                propertyType.SetValue(instance, Template.TemplateType.BLOG);
                return instance;
            }

            if (filter.Contains("3"))
            {
                propertyType.SetValue(instance, Template.TemplateType.PRODUCT);
                return instance;
            }

            return default;
        }

        public void PopulatePluginsToTemplate(ref Template template)
        {
            var availablePlugins = new List<Plugin>
            {
                new Plugin { Type = Plugin.PluginTypes.CHAT },
                new Plugin { Type = Plugin.PluginTypes.EMAIL },
                new Plugin { Type = Plugin.PluginTypes.STAT },
            };

            template.Plugins = availablePlugins;
        }

        public void Sanitize(object any)
        {
            if (any == null)
            {
                throw new Exception("Data is not valid");
            }
        }
    }
}
