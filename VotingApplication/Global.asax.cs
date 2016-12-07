using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace VotingApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            InitializeAutoMapper();
        }

        void InitializeAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Question, Models.Question>();
                cfg.CreateMap<Models.Question, Entities.Question>();
                cfg.CreateMap<Entities.ResponseOption, Models.ResponseOption>();
                cfg.CreateMap<Models.ResponseOption, Entities.ResponseOption>();
                cfg.CreateMap<Entities.Result, Models.Result>();
                cfg.CreateMap<Models.Result, Entities.Result>();
            });
        }
    }
}
