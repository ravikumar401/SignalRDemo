﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Notifications_SignalR
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string Connection = ConfigurationManager.ConnectionStrings["NotificationsDBCon"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SqlDependency.Start(Connection);
        }

        protected void Application_End()
        {

            SqlDependency.Stop(Connection);
        }
    }
}
