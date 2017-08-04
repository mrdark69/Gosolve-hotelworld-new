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

        if (!this.Page.IsPostBack)
        {
            this.Page.Title = "XXXXXX";
            Model_SiteInfo st = new Model_SiteInfo();
            Model_MainSetting setting = new Model_MainSetting();
            setting = setting.GetMainSetting();

            Model_PageEngine PageEngine = new Model_PageEngine();
            PageEngine.SiteInfo = st.GetSiteInfo();




            //string[] dd = { "fixed-sidebar", "no-skin-config", "full-height-layout" };
            //StyleCore dd = new StyleCore();
            //StyleCore.arrayClass = dd;


            //Set Setting to MasterPage Class
            Master.PageEngine = PageEngine;


            



            byte bytPostTypeID = 0;
            string StrPost_slug = string.Empty;
            int intPostID = 0;

            string PostType = Page.RouteData.Values["Param1"] as string;

            if (!string.IsNullOrEmpty(PostType))
            {

                //1. Check Is Archive
                Model_Archive archive = new Model_Archive();
                archive = archive.GetPostArchive(PostType);

                if(archive !=null)
                {
                    bytPostTypeID = archive.PostTypeID;
                    StrPost_slug = (string.IsNullOrEmpty(archive.Slug) ? archive.PostTypeSlug : archive.Slug);

                    

                }





            }
            else
            {
                //Case HomePage No Slug 
                //Get PostID From Setting HomePage Slug

                intPostID = setting.HomePagePostID;
                Model_Post  post = CmsController.GetPostByID(intPostID);

                if (post != null)
                {
                    StrPost_slug = post.Slug;


                    HeaderSection.Text = GenerateHeaderBannerAndSlider(post);
                    content.Text = post.BodyContent;


                }
            }


            
        }
       

        
    }

    

    private string HomePage()
    {
        return string.Empty;
    }

    private string Post_Pages()
    {
        return string.Empty;
    }


    private string Post_Product()
    {
        return string.Empty;
    }

    private string Post_Blog()
    {
        return string.Empty;
    }

    private string GenerateHeaderBannerAndSlider(Model_Post post)
    {
        string ret = string.Empty;

        if (post.ShowMasterSlider)
        {
            ret = Slider();
        }
        else
        {
            ret = breadcrumb(post.BannerTypeID);
        }

        return ret;

    }

    private string Slider()
    {
        string ret = StringUtility.GetTemplate("Slider");
        return ret;
    }

    private string breadcrumb(byte type)
    {
        string FileName = "breadcrumbs-product";
        switch (type)
        {
            case 1:
                FileName = "breadcrumbs";
                break;
            case 2:
                FileName = "breadcrumbs-product";
                break;
        }
        string ret = StringUtility.GetTemplate(FileName);
        return ret;
    }
}