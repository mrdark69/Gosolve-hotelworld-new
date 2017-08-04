using gs_newsletter;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class SiteUserMaster : MasterPage
    {
    //private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    //private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    //private string _antiXsrfTokenValue;

    public Model_PageEngine PageEngine { get; set; }
    //public Model_SiteInfo SiteInfo { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //  string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/Theme/emailtemplate/layoutforgot.html"), Encoding.UTF8);
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            //Context.GetOwinContext().Authentication.SignOut();
        }
    }


