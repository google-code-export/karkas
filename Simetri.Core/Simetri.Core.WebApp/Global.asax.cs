using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Simetri.Core.DataUtil;

namespace Simetri.Core.WebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ConnectionSingleton.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}