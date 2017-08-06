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

       

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //  string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/Theme/emailtemplate/layoutforgot.html"), Encoding.UTF8);
        }
    

        public string checkActive( string p2, bool Ishome)
        {
            string active = string.Empty;
        string abp = HttpUtility.UrlDecode(Request.Url.AbsolutePath);
                if (abp  == "/"+p2 || (Ishome && abp == "/Default.aspx"))
                {
                    active = "active";
                }
            return active;
        }


//    Don't treat it as a URI problem, treat it a string problem. Then it's nice and easy.

//String originalPath = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
//    String parentDirectory = originalPath.Substring(0, originalPath.LastIndexOf("/"));
//    Really is that easy!

//Edited to add missing parenthesis.
    }


