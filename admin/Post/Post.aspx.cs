using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Post : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
           

            if (!string.IsNullOrEmpty(Request.QueryString["PostID"]))
            {
                int PostID = int.Parse(Request.QueryString["PostID"]);
                Model_Post p = new Model_Post();
               
                p = p.GetPostByID(PostID);
                if (p != null)
                {

                    string btnEdit = "<select name=\"content_status\" class=\"form-control\"><option "+ (p.Status ? "Selected=\"Selected\"" : "") + " value=\"True\" >Publish</option><option "+ (!p.Status ? "Selected=\"Selected\"" : "") + " value=\"False\">Draft</option></select>";
                    lblstatus.Text =  btnEdit;
                    //"<label>" + (p.Status ? "Published" : "Draft") + "</label>" +

                    lbldatepublish.Text = p.DatePublish.ToThaiDateTime().ToString("dd MMM yyyy HH:mm tt");

                    txtTitle.Text = p.Title;
                    txtContent.Text = p.BodyContent;
                    Model_MainSetting setting = new Model_MainSetting();
                    setting = setting.GetMainSetting();

                    url.Text = setting.WebSiteURL;
                    slug.Text = p.Slug;
                    viewcount.Text = p.ViewCount.ToString();


                    CoverType.Value = p.BannerTypeID.ToString();
                    radioshowmMS.SelectedValue = p.ShowMasterSlider.ToString();

                    if(p.PostSEO != null)
                    {
                        Model_PostSeo seo = p.PostSEO;

                        seotitle.Text = seo.SEOTitle;
                        metades.Text = seo.MetaDescription;
                        Canonical.Text = seo.CanonicalUrl;
                        droprebot.SelectedValue = seo.Metarobotsfollow.ToString();
                        facebookTitle.Text = seo.FaceBookTitle;
                        facebookDes.Text = seo.FacebookDescription;
                        facebookImg.Value = seo.FacebookImage;
                        twTitle.Text = seo.TwitterTitle;
                        twDes.Text = seo.TwitterDescription;
                        twimg.Value = seo.TwitterImages;
                        analytic.Text = seo.GoogleAnalytic;
                    }

                    if (p.PostMedia.Count > 0)
                    {
                        Model_PostMedia cover = p.PostMedia.FirstOrDefault(r => r.PostID == PostID && r.PostMediaTypeID == PostMediaType.CoverImage);
                        if (cover != null)
                        {
                            hd_MID.Value = cover.MID.ToString();
                            CoverImage1.Value = this.MainSetting.WebSiteURL + cover.MediaFullPath;
                            //hd_postMeidaID.Value = cover.PostMediaID.ToString();
                        }
                    }

                }

               

            }


        }
    }



    protected void btnPubish_Click(object sender, EventArgs e)
    {
        

        if (!string.IsNullOrEmpty(Request.QueryString["PostID"]))
        {
            int intPostID = int.Parse(Request.QueryString["PostID"]);

            Model_Post p = new Model_Post
            {
                PostID = intPostID,
                PostTypeID = 1,
                Title = txtTitle.Text.Trim(),
                Short = "",
                Slug = slug.Text.GenerateSlug(),
                DateSubmit = DatetimeHelper._UTCNow(),
                UserID = this.UserActive.UserID,
                DatePublish = DatetimeHelper._UTCNow(),
                Status = bool.Parse(Request.Form["content_status"]),
                ShowComment = false,
                BodyContent = txtContent.Text.Trim(),
                BannerTypeID = byte.Parse(CoverType.Value),
                ShowMasterSlider = bool.Parse(radioshowmMS.SelectedValue),
                ViewCount = 1
            };


            Model_PostSEOMap seomap = new Model_PostSEOMap();
            seomap = seomap.GetSEOID(intPostID);

            Model_PostSeo seo = new Model_PostSeo {

                SEOTitle = seotitle.Text.Trim(),
                MetaDescription = metades.Text.Trim(),
                CanonicalUrl = Canonical.Text.Trim(),
                Metarobotsfollow = bool.Parse(droprebot.SelectedValue),
                FaceBookTitle = facebookTitle.Text.Trim(),
                FacebookDescription = facebookDes.Text.Trim(),
                FacebookImage = facebookImg.Value,
                TwitterTitle = twTitle.Text.Trim(),
                TwitterDescription = twDes.Text.Trim(),
                TwitterImages = twimg.Value,
                GoogleAnalytic = analytic.Text.Trim(),
            };

            if(seomap != null)
            {
                seo.PSID = seomap.PSID;
                seo.UpdateSEO(seo);
            }
            else
            {
                int PSID = seo.InsertSEO_step1(seo);
                if (PSID > 0)
                {
                    seomap = new Model_PostSEOMap
                    {
                        PostID = intPostID,
                        PSID = PSID
                    };
                   
                    seomap.InsertMApSeo(seomap);
                }
                    
            }
            
            if (!string.IsNullOrEmpty(hd_MID.Value))
            {
                Model_PostMedia pm = new Model_PostMedia
                {

                    PostMediaTypeID = PostMediaType.CoverImage,
                    PostID = intPostID,
                    MID = int.Parse(hd_MID.Value)
                };

                pm.insertMediaPost(pm);
            }
           
            

            if (p.UpdatePost(p))
                Response.Redirect(Request.Url.ToString());
        }
       

    }
}