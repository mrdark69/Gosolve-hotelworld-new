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
            Model_PostSeo posttype_postseo = null;
            Model_PostSeo tax_postseo = null;
            Model_PostSeo post_postseo = null;
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


            Pagetitle = checklv(posttype_postseo, tax_postseo, post_postseo, "SEOTitle");
            //setting.WebSiteTitle;
            this.Page.Title = Pagetitle;
            var keywords = new HtmlMeta { Name = "keywords", Content = "one,two,three" };
            Header.Controls.Add(keywords);

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