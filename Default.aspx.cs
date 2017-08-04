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

        this.Page.Title = "XXXXXX";
        Model_SiteInfo st = new Model_SiteInfo();
        Model_MainSetting setting = new Model_MainSetting();
        setting = setting.GetMainSetting();

        Model_PageEngine PageEngine = new Model_PageEngine();
        PageEngine.SiteInfo = st.GetSiteInfo();
        Master.PageEngine = PageEngine;
        //Master.SiteInfo = st.GetSiteInfo();

        //Model_MainSetting s = new Model_MainSetting();

        Model_Post post = new Model_Post();

        string PageSlug = Page.RouteData.Values["PageSlug"] as string;
        string archive = Page.RouteData.Values["archive"] as string;
        string slug = Page.RouteData.Values["slug"] as string;


        if (!string.IsNullOrEmpty(PageSlug))
        {

            string post_slug = PageSlug;


            content.Text = "";

        }


        if (string.IsNullOrEmpty(PageSlug) && string.IsNullOrEmpty(archive) && string.IsNullOrEmpty(slug))
        {
            string post_slug = string.Empty;
            int post_id = setting.HomePagePostID;
            post = post.GetPostByID(post_id);

            if(post != null)
            {
                post_slug = post.Slug;

                HeaderSection.Text = Slider();
                content.Text = post_slug;
            }
        }

        

    }

    public string Slider()
    {
        string ret = StringUtility.GetTemplate("Slider");
        return ret;
    }

    public string breadcrumb()
    {
        return string.Empty;
    }
}