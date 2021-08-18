namespace BasicProject.Api
{
    using BasicProject.Logger;

    using System;
    using System.Configuration;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;

    public class Program
    {
        private const string logo = @"
        ______           _       ______          _           _   
        | ___ \         (_)      | ___ \        (_)         | |  
        | |_/ / __ _ ___ _  ___  | |_/ / __ ___  _  ___  ___| |_ 
        | ___ \/ _` / __| |/ __| |  __/ '__/ _ \| |/ _ \/ __| __|
        | |_/ / (_| \__ \ | (__  | |  | | | (_) | |  __/ (__| |_ 
        \____/ \__,_|___/_|\___| \_|  |_|  \___/| |\___|\___|\__|
                                               _/ |              
                                              |__/
        ";

        private static readonly Ilogger logger = LoggerFactory.GetLogger<Program>();

        static void Main(string[] args)
        {
            try
            {
                logger.Information(logo);

                string url = ConfigurationManager.AppSettings["apiUrl"];

                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseUrls(urls: url)
                    .UseStartup<Startup>()
                    .Build();

                logger.Information($"Service Running on {url}");
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error($"Unable to start the application", ex);
                throw;
            }
        }
    }
}
