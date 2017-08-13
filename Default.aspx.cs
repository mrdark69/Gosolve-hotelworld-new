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

    public List<Model_PostCustomItem> CTF  { get; set; }
    public Model_Post PostDataUI { get; set; }

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

            Model_Post post = new Model_Post();
            Model_Menu m = new Model_Menu();
            Model_PostTaxonomy tax = new Model_PostTaxonomy();
            List<Model_Post> postArchive = new List<Model_Post>();
            Model_Archive archive = new Model_Archive();

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
           
            
            string RouteSlug_1 = Page.RouteData.Values["Param1"] as string;
            string RouteSlug_2 = Page.RouteData.Values["Param2"] as string;
            string RouteSlug_3 = Page.RouteData.Values["Param3"] as string;
            string RouteSlug_4 = Page.RouteData.Values["Param4"] as string;
            Model_PostCustomItem pct = new Model_PostCustomItem();

            //Case Route Slug
            if (!string.IsNullOrEmpty(RouteSlug_1))
            {

                //1. Check Is Archive
               
                archive = archive.GetPostArchive(RouteSlug_1);


                if(archive !=null)
                {
                    //Is Archive
                    bytPostTypeID = archive.PostTypeID;
                    StrPost_slug = (string.IsNullOrEmpty(archive.Slug) ? archive.PostTypeSlug : archive.Slug);

                    //postArchive = CmsController.GetPostArchive(bytPostTypeID);

                    //Check  PostType Archive 
                    switch (StrPost_slug)
                    {

                        case "hotelworld-products":
                            //check Route Param2
                            if (string.IsNullOrEmpty(RouteSlug_2))
                            {
                                //Case Product Page Archive
                                SectionProductArchive.Visible = true;
                            }
                            else
                            {
                                //check Is Paging of Product Page Archive
                                if(RouteSlug_2 == "page")
                                {
                                    //Case Archive Paging
                                    SectionProductArchive.Visible = true;
                                    string pageno = RouteSlug_3;

                                    
                                }
                                else
                                {

                                    //Check Product SinglePage
                                    post = CmsController.GetPostSlug(RouteSlug_2, PostType.Products);
                                    if(post != null)
                                    {
                                        SectionProductSingle.Visible = true;
                                    }
                                    else
                                    {
                                        //Tax Archive 

                                        tax = tax.GetTaxBySlugAndPostType(RouteSlug_2, bytPostTypeID);
                                        if (tax != null)
                                        {
                                            //case Tax approve
                                            SectionProductTaxArchive.Visible = true;

                                            //Case tax Archive Paging
                                            if (RouteSlug_3 == "page")
                                            {
                                                string pageno = RouteSlug_4;

                                                //Do something with paging
                                                
                                            }
                                            
                                        }
                                    }



                                   
                                }
                                

                            }
                            

                            break; 
                        case "ข่าวสาร":

                            //check Route Param2
                            if (string.IsNullOrEmpty(RouteSlug_2))
                            {
                                //Case Product Page Archive
                                SectionBlogPageArchive.Visible = true;
                            }
                            else
                            {
                                //check Is Paging of Product Page Archive
                                if (RouteSlug_2 == "page")
                                {
                                    //Case Archive Paging
                                    SectionBlogPageArchive.Visible = true;
                                    string pageno = RouteSlug_3;


                                }
                                else
                                {


                                    //Check Product SinglePage
                                    post = CmsController.GetPostSlug(RouteSlug_2, PostType.Blog);
                                    if (post != null)
                                    {
                                        SectionBlogPageSingle.Visible = true;
                                    }
                                    else
                                    {
                                        //Tax Archive 

                                        tax = tax.GetTaxBySlugAndPostType(RouteSlug_2, bytPostTypeID);
                                        if (tax != null)
                                        {
                                            //case Tax approve 
                                            //Same layout with blog archive
                                           // SectionBlogPageTaxArchive.Visible = true;
                                            SectionBlogPageArchive.Visible = true;

                                            //Case tax Archive Paging
                                            if (RouteSlug_3 == "page")
                                            {
                                                string pageno = RouteSlug_4;

                                                //Do something with paging

                                                
                                            }


                                        }
                                    }


                                    

                                }


                            }
                            
                            break; 
                    }
                    HeaderSection.Text = GenerateHeaderBannerAndSlider(post, tax);
                }
                else
                {
                    //Case PostType Page
                    StrPost_slug = RouteSlug_1;
                    post = CmsController.GetPostSlug(StrPost_slug,PostType.Pages);

                    if (post != null)
                    {
                        bytPostTypeID = post.PostTypeID;
                        intPostID = post.PostID;

                        //page_header.Visible = true;
                        page_content.Visible = true;




                        HeaderSection.Text = GenerateHeaderBannerAndSlider(post);
                        this.PostDataUI = post;
                        this.ContentBody = post.BodyContent;
                        this.PageContentTitle = post.Title;
                    }
                    

                }

                
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


                    this.CTF = pct.GetItemCustomByPostID(intPostID);

                   
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

    private string GenerateHeaderBannerAndSlider(Model_Post post, Model_PostTaxonomy tax = null)
    {
        string ret = string.Empty;

        //case Post 
        //The Post Can Manange Show Master Slide Or Type of Banner cover page.
        if(post != null)
        {
            if (post.ShowMasterSlider)
                ret = Slider();
            else
                ret = breadcrumb(post.BannerTypeID);
            if (post.BannerTypeID == 1)
                ret = ret.Replace("<!--##THE_TITLE##-->", post.Title);

            List<Model_PostMedia> pm = post.PostMedia;

            ret = ret.Replace("<!--##THE_COVER##-->", pm.SingleOrDefault(m => m.PostMediaTypeID == PostMediaType.CoverImage).MediaFullPath);
        }
        else
        {
            //case Archive Page 
            // Can display Title postype name only.
            if(tax != null)
            {
                if (tax.ShowMasterSlider)
                    ret = Slider();
                else
                    ret = breadcrumb(tax.BannerTypeID);
            }else
            {
                ret = breadcrumb(2);
            }
           

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