﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admTarea1._1.Startup))]
namespace admTarea1._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
