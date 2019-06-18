using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlainConcepts.SIDRA.Web.Manager;

namespace WebApplication14
{
    public class Startup
    {
        private SidraStartup sidraStartup { get; set; }

        public Startup(IHostingEnvironment environment, ILoggerFactory loggerFactory) :
            this(environment, loggerFactory, Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
        {
        }

        protected Startup(IHostingEnvironment environment, ILoggerFactory loggerFactory, string basePath)
        {
            sidraStartup = new SidraStartup(environment, loggerFactory, basePath);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            sidraStartup.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            sidraStartup.Configure(app, env);
        }
    }
}
