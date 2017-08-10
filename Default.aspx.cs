using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : Page
{
    public string ContentBody{ get; set; }
    public string PageContentTitle { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(HttpUtility.UrlDecode(Request.Url.AbsolutePath)));Response.End();
        if (!this.Page.IsPostBack)
        {
            this.Page.Title = "XXXXXX";
            Model_SiteInfo st = new Model_SiteInfo();
            Model_MainSetting setting = new Model_MainSetting();
            setting = setting.GetMainSetting();

            Model_PageEngine PageEngine = new Model_PageEngine();
            PageEngine.SiteInfo = st.GetSiteInfo();
            PageEngine.MainSetting = setting;


            Model_Menu m = new Model_Menu();
          
            PageEngine.NavMenu = m.GetMenuAll(1);
            PageEngine.FooterMenu = m.GetMenuAll(2);

            //string[] dd = { "fixed-sidebar", "no-skin-config", "full-height-layout" };
            //StyleCore dd = new StyleCore();
            //StyleCore.arrayClass = dd;


            //Set Setting to MasterPage Class
            Master.PageEngine = PageEngine;


            



            byte bytPostTypeID = 0;
            string StrPost_slug = string.Empty;
            int intPostID = 0;
            Model_Post post = null;
           List< Model_Post> postArchive = null;
            string RouteSlug_1 = Page.RouteData.Values["Param1"] as string;

            if (!string.IsNullOrEmpty(RouteSlug_1))
            {

                //1. Check Is Archive
                Model_Archive archive = new Model_Archive();
                archive = archive.GetPostArchive(RouteSlug_1);

                if(archive !=null)
                {
                    bytPostTypeID = archive.PostTypeID;
                    StrPost_slug = (string.IsNullOrEmpty(archive.Slug) ? archive.PostTypeSlug : archive.Slug);

                    postArchive = CmsController.GetPostArchive(bytPostTypeID);

                }
                else
                {
                    //Case PostType Page
                    StrPost_slug = RouteSlug_1;
                    post = CmsController.GetPostSlug(StrPost_slug);

                    if (post != null)
                    {
                        bytPostTypeID = post.PostTypeID;
                        intPostID = post.PostID;

                        page_header.Visible = true;
                        page_content.Visible = true;
                    }
                    

                }




                HeaderSection.Text = GenerateHeaderBannerAndSlider(post);
             
                this.ContentBody = post.BodyContent;
                this.PageContentTitle = post.Title;
                // content.Text = post.BodyContent;


            }
            else
            {
                //Case HomePage No Slug 
                //Get PostID From Setting HomePage Slug

                intPostID = setting.HomePagePostID;
                  post = CmsController.GetPostByID(intPostID);

                if (post != null)
                {
                    StrPost_slug = post.Slug;


                    HeaderSection.Text = GenerateHeaderBannerAndSlider(post);
                    // content.Text = post.BodyContent;

                    this.ContentBody = post.BodyContent;
                    this.PageContentTitle = post.Title;
                    section_page_home.Visible = true;


                    home_content.Text = this.ContentBody;

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