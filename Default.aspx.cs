using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class _Default : Page
{
    public string ContentBody{ get; set; }
    public string PageContentTitle { get; set; }

    public List<Model_PostCustomItem> CTF { get; set; } = new List<Model_PostCustomItem>();
    public Model_Post PostDataUI { get; set; }
    public List<Model_PostTaxonomy> TaxList { get; set; }
    public Model_PostTaxonomy TaxForPostType { get; set; } 

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(HttpUtility.UrlDecode(Request.Url.AbsolutePath)));Response.End();
        if (!this.Page.IsPostBack)
        {
            string Pagetitle = string.Empty;
            string Pagedescription = string.Empty;
            string canonical = string.Empty;
            string fb_localte = string.Empty;
            string fb_type = string.Empty;
            string fb_title = string.Empty;
            string fb_des = string.Empty;
            string fb_url = string.Empty;
            string fb_site_name = string.Empty;
            string fb_image = string.Empty;

            string tw_card = string.Empty;
            string tw_title = string.Empty;
            string tw_des = string.Empty;
            string tw_image = string.Empty;


            string analytic = string.Empty;
            bool Metarobotfollow = false;

            Model_SiteInfo st = new Model_SiteInfo();
            Model_MainSetting setting = new Model_MainSetting();
            setting = setting.GetMainSetting();
            


            Model_PageEngine PageEngine = new Model_PageEngine();
            PageEngine.SiteInfo = st.GetSiteInfo();
            PageEngine.MainSetting = setting;
            Model_PostType cPostType = new Model_PostType();
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

                                cPostType = cPostType.GetPostTypeBySlug(StrPost_slug);
                                if(cPostType != null)
                                {
                                    //product-type = 24
                                    this.TaxForPostType = tax.FrontGetTaxonomyByID(24);
                                    
                                    if (this.TaxForPostType != null)
                                    {
                                        this.TaxList = tax.FrontGetTaxonomyByRefID(24);
                                    }
                                    
                                }


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
                                        this.PostDataUI = post;
                                        this.ContentBody = post.BodyContent;
                                        this.PageContentTitle = post.Title;
                                        this.CTF = pct.GetItemCustomByPostID(post.PostID);
                                    }
                                    else
                                    {
                                        //Tax Archive 

                                        tax = tax.GetTaxBySlugAndPostType(RouteSlug_2, bytPostTypeID);
                                        if (tax != null)
                                        {
                                            //case Tax approve
                                            SectionProductTaxArchive.Visible = true;
                                            this.TaxForPostType = tax;
                                            this.TaxList = tax.GetTaxonomyTaxTypeAndPostType(bytPostTypeID, (byte)PostTaxonomyType.Categories);
                                            this.ContentBody = tax.BodyContent;
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

                        if (StrPost_slug == "checkout")
                            section_checkout_page.Visible = true;
                        else
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

                    bytPostTypeID = post.PostTypeID;
                    HeaderSection.Text = GenerateHeaderBannerAndSlider(post);


                    this.CTF = pct.GetItemCustomByPostID(intPostID);


                    // content.Text = post.BodyContent;
                    this.PostDataUI = post;
                    this.ContentBody = post.BodyContent;
                    this.PageContentTitle = post.Title;
                    section_page_home.Visible = true;


                    home_content.Text = this.ContentBody;

                }
            }

           //= null;
            Model_PostSeo posttype_postseo = new Model_PostSeo(); 
            Model_PostSeo tax_postseo = new Model_PostSeo();
            Model_PostSeo post_postseo = new Model_PostSeo(); 
            if (bytPostTypeID != 0)
            {
                cPostType = cPostType.GetPostTypeByID(bytPostTypeID);
                 posttype_postseo = cPostType.PosTypetSEO;
            }


            if(tax != null)
            {
                 tax_postseo = tax.TaxSEO;
            }

            if (post != null)
            {
                 post_postseo = post.PostSEO;
            }


            Pagetitle =  checklv(posttype_postseo, tax_postseo, post_postseo, "SEOTitle");
            Pagedescription = checklv(posttype_postseo, tax_postseo, post_postseo, "MetaDescription");
            canonical = checklv(posttype_postseo, tax_postseo, post_postseo, "CanonicalUrl");
            fb_localte = setting.htmlTagSiteLang;
            fb_type = "website";
            fb_title = checklv(posttype_postseo, tax_postseo, post_postseo, "FaceBookTitle");
            fb_des = checklv(posttype_postseo, tax_postseo, post_postseo, "FacebookDescription");
            fb_url = Request.Url.ToString();
            fb_site_name = PageEngine.SiteInfo.Slogan;
            fb_image = checklv(posttype_postseo, tax_postseo, post_postseo, "FacebookImage");
            tw_card = "summary";
            tw_title = checklv(posttype_postseo, tax_postseo, post_postseo, "TwitterTitle");
            tw_des = checklv(posttype_postseo, tax_postseo, post_postseo, "TwitterDescription");
            tw_image = checklv(posttype_postseo, tax_postseo, post_postseo, "TwitterImages");

            analytic = checklv(posttype_postseo, tax_postseo, post_postseo, "GoogleAnalytic");

            Metarobotfollow = checklv_bool(posttype_postseo, tax_postseo, post_postseo, "Metarobotsfollow");

            this.Page.Title = string.IsNullOrEmpty(Pagetitle) ? setting.WebSiteTitle : Pagetitle;

            var MetaDescription = new HtmlMeta { Name = "description", Content = Pagedescription };
            Header.Controls.Add(MetaDescription);

            var MetaFB_locate = new HtmlMeta { Name = "og:locale", Content = fb_localte };
            Header.Controls.Add(MetaFB_locate);

            var MetaFB_Type = new HtmlMeta { Name = "og:type", Content = fb_type };
            Header.Controls.Add(MetaFB_Type);

            var MetaFB_title = new HtmlMeta { Name = "og:title", Content = !string.IsNullOrEmpty(fb_title)? fb_title :   string.IsNullOrEmpty(Pagetitle) ? setting.WebSiteTitle : Pagetitle
        };
            Header.Controls.Add(MetaFB_title);


            var MetaFB_Des = new HtmlMeta { Name = "og:description", Content = !string.IsNullOrEmpty(fb_des) ? fb_des: Pagedescription };
            Header.Controls.Add(MetaFB_Des);

            var MetaFB_Url = new HtmlMeta { Name = "og:url", Content = fb_url };
            Header.Controls.Add(MetaFB_Url);

            var MetaFB_SiteName = new HtmlMeta { Name = "og:site_name", Content = fb_site_name };
            Header.Controls.Add(MetaFB_SiteName);

            var MetaFB_image = new HtmlMeta { Name = "og:image", Content = fb_image };
            Header.Controls.Add(MetaFB_image);

            var MetaTW_Card = new HtmlMeta { Name = "twitter:card", Content = tw_card };
            Header.Controls.Add(MetaTW_Card);

            var MetaTW_Des = new HtmlMeta { Name = "twitter:description", Content = tw_des };
            Header.Controls.Add(MetaTW_Des);
            var MetaTW_Title = new HtmlMeta { Name = "twitter:title", Content = tw_title };
            Header.Controls.Add(MetaTW_Title);
            var Meta_Image = new HtmlMeta { Name = "twitter:image", Content = tw_image };
            Header.Controls.Add(Meta_Image);
           

        }
       

        
    }

    public string checklv(Model_PostSeo posttype_postseo, Model_PostSeo tax_postseo, Model_PostSeo post_postseo, string prop)
    {
        string ret = string.Empty;
        PropertyInfo ppost = (post_postseo != null? post_postseo.GetType().GetProperty(prop) : null);
        PropertyInfo ptax = (tax_postseo != null ? tax_postseo.GetType().GetProperty(prop) : null);
        PropertyInfo ppt = (posttype_postseo != null? posttype_postseo.GetType().GetProperty(prop) : null);

        string strppost = (string)(ppost != null ? ppost.GetValue(post_postseo, null) : null);
        string strptax = (string)(ptax != null ? ptax.GetValue(tax_postseo, null) : null);
        string strppt = (string)(ppt != null ? ppt.GetValue(posttype_postseo, null) : null);

        if (post_postseo != null && ppost!=null &&  !string.IsNullOrEmpty(strppost))
        {
         

            ret = (string)strppost;
            //ret = string.IsNullOrEmpty(ret) ? "" : (string)ret;
        }
        else
        {
            if(tax_postseo != null && ptax != null && !string.IsNullOrEmpty(strptax))
            {
                ret = (string)strptax;
                //ret = string.IsNullOrEmpty(ret) ? "" : (string)ret;
            }
            else
            {
                

                if (posttype_postseo != null && ppt != null && !string.IsNullOrEmpty(strppt))
                {
                    ret = (string)strppt;
                    //ret = string.IsNullOrEmpty(ret) ? "" : (string)ret;
                }
            }
        }

        return ret;
    }
    public bool checklv_bool(Model_PostSeo posttype_postseo, Model_PostSeo tax_postseo, Model_PostSeo post_postseo, string prop)
    {
        bool ret = false;
        PropertyInfo ppost = (post_postseo != null ? post_postseo.GetType().GetProperty(prop) : null);
        PropertyInfo ptax = (tax_postseo != null ? tax_postseo.GetType().GetProperty(prop) : null);
        PropertyInfo ppt = (posttype_postseo != null ? posttype_postseo.GetType().GetProperty(prop) : null);

        var strppost =(ppost != null ? ppost.GetValue(post_postseo, null) : null);
        var strptax = (ptax != null ? ptax.GetValue(tax_postseo, null) : null);
        var strppt = (ppt != null ? ppt.GetValue(posttype_postseo, null) : null);

        if (post_postseo != null && ppost != null && strppost!=null)
        {


            ret = (bool)strppost;
            //ret = string.IsNullOrEmpty(ret) ? "" : (string)ret;
        }
        else
        {
            if (tax_postseo != null && ptax != null && strptax !=null)
            {
                ret = (bool)strptax;
                //ret = string.IsNullOrEmpty(ret) ? "" : (string)ret;
            }
            else
            {


                if (posttype_postseo != null && ppt != null && strppt !=null)
                {
                    ret = (bool)strppt;
                    //ret = string.IsNullOrEmpty(ret) ? "" : (string)ret;
                }
            }
        }

        return ret;
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

            List<Model_PostMedia> pml = post.PostMedia;

            Model_PostMedia pm = pml.SingleOrDefault(m => m.PostMediaTypeID == PostMediaType.CoverImage);
            if(pm!=null)
            ret = ret.Replace("<!--##THE_COVER##-->", pm.MediaFullPath);
            
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

                if (tax.BannerTypeID == 1)
                    ret = ret.Replace("<!--##THE_TITLE##-->", tax.Title);

                List<Model_TaxMedia> pml = tax.TaxMedia;

                Model_TaxMedia pm = pml.SingleOrDefault(m => m.TaxMediaTypeID == TaxMediaType.CoverImage);
                if (pm != null)
                    ret = ret.Replace("<!--##THE_COVER##-->", pm.MediaFullPath);
            }
            else
            {
                ret = breadcrumb(2);
            }
           

        }
        

        return ret;

    }

    private string Slider()
    {
        Model_MasterSlider ms = new Model_MasterSlider();
        Model_MasterSliderItem mi = new Model_MasterSliderItem();
     // string ret = StringUtility.GetTemplate("Slider");

        List<Model_MasterSlider> mslist = ms.GetMasterList();

        StringBuilder template = new StringBuilder();
        template.Append("<style>");

        int count = 1;
        foreach (Model_MasterSlider m in mslist)
        {
            template.Append(".flexslider.top_slider .slide"+ count + " {");
            template.Append("width: 100%;");
            template.Append("background-image: url("+ m .MediaFullPath+ ");");
            template.Append("background-size: cover;");
            template.Append("}");

            count = count + 1;
        }
        
        template.Append("</style>");
        


        template.Append("<section id=\"home\" class=\"padbot30\">");
        template.Append("<div class=\"flexslider top_slider\">");
        template.Append("<ul class=\"slides\">");

        foreach (Model_MasterSlider m in mslist)
        {

            template.Append("<li class=\"slide1\" >");

            template.Append("<div class=\"container\">");

            template.Append("<div class=\"flex_caption1\">");
            template.Append("<p class=\"title1 captionDelay2 FromTop\"><!--###MASTERITEM_TEXT1###--></p>");
            template.Append("<p class=\"title2 captionDelay3 FromTop\"><!--###MASTERITEM_TEXT2###--></p>");
            template.Append("</div>");

            template.Append("<a class=\"flex_caption2\" href=\"javascript:void(0);\"><div class=\"middle\">Download<span> Brochure</span>Click</div></a>");
            template.Append("<div class=\"flex_caption3 slide_banner_wrapper\">");
            template.Append("<a class=\"slide_banner slide1_banner1 captionDelay4 FromBottom\" href=\"javascript:void(0);\"><img src = \"/Theme/maintheme/images/slider/slide1_baner1.jpg\" alt=\"\" /></a>");
            template.Append("<a class=\"slide_banner slide1_banner2 captionDelay5 FromBottom\" href=\"javascript:void(0);\"><img src = \"/Theme/maintheme/images/slider/slide1_baner2.jpg\" alt=\"\" /></a>");
            template.Append("<a class=\"slide_banner slide1_banner3 captionDelay6 FromBottom\" href=\"javascript:void(0);\"><img src = \"/Theme/maintheme/images/slider/slide1_baner3.jpg\" alt=\"\" /></a>");
            template.Append(" </div>");
            template.Append("</div>");
            template.Append("</li>");
        }
        
        template.Append("</ul>");
        template.Append("</div>");
        template.Append("</section>");


        //string body = ret.GetKeywordReplace("<!-- ###MASTERITEM_START### -->", "<!-- ###MASTERITEM_END### -->");
        //string style = ret.GetKeywordReplace(" <!-- ###STYLE_START### -->", "<!-- ###STYLE_END### -->");
        //StringBuilder strStyle = new StringBuilder();
        //StringBuilder strBody = new StringBuilder();

        //return ret.Replace(body, strBody.ToString());

        return template.ToString();
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

    public string getCatProduct(List<Model_PostTaxonomy> Taxlist)
    {
        StringBuilder ret = new StringBuilder();


        ret.Append("<div class='tax_parent' style='max-height:300px;overflow:scroll;'>");

        List<Model_PostTaxonomy> Taxlistdrop = new List<Model_PostTaxonomy>();



        foreach (Model_PostTaxonomy i in Taxlist.Where(g => g.RefID == 0).OrderBy(o => o.Priority))
        {
            //ret.Append("<input type='checkbox' value='"+i.TaxID+"' name='product_tax_cat' />");
            ret.Append("<p class='parent_main_item'><i class=\"fa fa-star\"></i> " + i.Title + "</p>");

            if (Taxlist.Where(f => f.RefID == i.TaxID).Count() > 0)
            {

                ret.Append("<div class='tax_child' style='margin-left:15px;'>");
               // ret.Append(getchild(Taxlist.Where(f => f.RefID == i.TaxID).ToList(), Taxlist, i.TaxID));
                ret.Append("</div>");
            }

        }


        ret.Append("</div>");
        return ret.ToString();
    }


    public string getchild( List<Model_PostTaxonomy> data, int id)
    {
        StringBuilder ret = new StringBuilder();
        List<Model_PostTaxonomy> retdataret = data.Where(r => r.RefID == id).ToList();
        foreach (Model_PostTaxonomy c in retdataret)
        {
            ////name="TaxID_<% Response.Write(p.PostTypeID); %>_<% Response.Write(p.TaxTypeID); %>" 
            ret.Append("<input type=\"checkbox\" id=\"tax_name_"+c.TaxID+"\" value=\""+c.Slug+ "\" /><label for=\"tax_name_" + c.TaxID + "\"><a href=\"" + c.Permarlink + "\" title=\""+c.Title+"\" >" + c.Title+ " <span>(24)</span></a></label>");
            ////ret.Append("<p class='child_item' style='position:relative;'><input type='checkbox'  value='" + c.TaxID + "' name='TaxID_" + c.PostTypeID + "_" + c.TaxTypeID + "' />");
            //ret.Append(c.Title + "</p>");
            if (data.Where(f => f.RefID == c.TaxID).Count() > 0)
            {
                ret.Append("<div class='tax_child'  style='position:relative;margin-left:15px;'>");
                ret.Append(getchild(data.Where(f => f.RefID == c.TaxID).ToList(), c.TaxID));
                ret.Append("</div>");
            }
        }
        return ret.ToString();
    }

}