using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SamplespecFlowProject.Configuration;
using SamplespecFlowProject.Steps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static SamplespecFlowProject.ScenarioDependencies;

namespace SamplespecFlowProject
{
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceProvider Create()
        {
            var services = new ServiceCollection();

            var config = new ConfigurationBuilder()
                .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
                .Build();

            var settings = config.Get<Settings>();

            services.AddSingleton(settings);
            services.AddSingleton<BaseSteps>();
     
            return services.BuildServiceProvider();
        }



    }
}
