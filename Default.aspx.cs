using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!this.Page.IsPostBack)
        //{

        //}

        //this.Page.Title = "XXXXXX";
        //Model_SiteInfo st = new Model_SiteInfo();
        //Master.SiteInfo = st.GetSiteInfo();


        //Model_MainSetting s = new Model_MainSetting();

        string archive = Page.RouteData.Values["archive"] as string;

        string slug = Page.RouteData.Values["slug"] as string;

        string slugonly = Page.RouteData.Values["slugonly"] as string;




   
       // lbltext.Text = d.SiteInfo
    }
}