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

                    //string btnEdit = "<select name=\"content_status\" class=\"form-control\"><option "+ (p.Status ? "Selected=\"Selected\"" : "") + " value=\"True\" >Publish</option><option "+ (!p.Status ? "Selected=\"Selected\"" : "") + " value=\"False\">Draft</option></select>";
                    dropStatus.SelectedValue = p.Status.ToString();
                    //"<label>" + (p.Status ? "Published" : "Draft") + "</label>" +

                    lbldatepublish.Text = p.DatePublish.ToThaiDateTime().ToString("dd MMM yyyy HH:mm tt");

                    txtTitle.Text = p.Title;
                    txtContent.Text = p.BodyContent;

                    txtContentBuilder.Text = p.BodyContentBuilder;
                    //Model_MainSetting setting = new Model_MainSetting();
                    //setting = setting.GetMainSetting();

                    url.Text = this.MainSetting.WebSiteURL;
                    slug.Text = p.Slug;
                    viewcount.Text = p.ViewCount.ToString();

                    if (p.Trash)
                    {
                        linktrash.Visible = true;
                        linkrestore.Visible = false;
                    }
                    else
                    {
                        linktrash.Visible = false;
                        linkrestore.Visible = true;

                    }



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





                //Check Cutom Post Field
                Model_PostCustomGroup pct = new Model_PostCustomGroup();
                List<Model_PostCustomGroup> pctList = pct.getCustomByPostID(PostID);

                foreach(Model_PostCustomGroup pci in pctList)
                {
                    switch (pci.PcGroupName)
                    {
                        case "HomeGroup":
                            pn_home_custom.Visible = true;
                            List<Model_PostCustomItem> itemList = pci.CustomItem;
                            Model_PostCustomItem bannerAnn = itemList.SingleOrDefault(r => r.PcName == "banner-announce");
                            b1_url.Value = bannerAnn.URL;
                            b1_id.Value = bannerAnn.MID.ToString();
                            banner_home_1.Text = bannerAnn.Caption1;


                            Model_PostCustomItem bannerright = itemList.SingleOrDefault(r => r.PcName == "banner-announce-right");
                            b2_url.Value = bannerright.URL;
                            b2_id.Value = bannerright.MID.ToString();
                            banner_home_2.Text = bannerright.Caption1;
                            //"banner-announce"
                            //banner-announce-right
                            //banner-client
                            drop_b_client_ret.DataSource = itemList.Where(r => r.PcName == "banner-client");
                            //drop_b_client_ret.DataTextFormatString = "{0} - {1}";
                            drop_b_client_ret.DataTextField = "MID";
                            //drop_b_client_ret.DataTextField = "Caption1";
                          
                            drop_b_client_ret.DataValueField = "DropTextFile";
                            drop_b_client_ret.DataBind();
                            break;
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
                Status = bool.Parse(dropStatus.SelectedValue),
                ShowComment = false,
                BodyContent = txtContent.Text.Trim(),
                BodyContentBuilder = txtContentBuilder.Text.Trim(),
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
            
            //Cover 
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
            else
            {
                Model_PostMedia pm = new Model_PostMedia
                {

                    PostMediaTypeID = PostMediaType.CoverImage,
                    PostID = intPostID
                   
                };

                pm.DeletePostMedia(pm);
            }


            //Check Cutom Post Field
            Model_PostCustomGroup pct = new Model_PostCustomGroup();
            List<Model_PostCustomGroup> pctList = pct.getCustomByPostID(intPostID);

            if(pctList.SingleOrDefault(i=>i.PcGroupName == "HomeGroup") != null)
            {
                //"HomeGroup":
                //banner announce
                Model_PostCustomItem cpi = new Model_PostCustomItem();
                cpi.PostID = intPostID;
                cpi.PCDID = (int)CustomGroup.HomeGroup;
                cpi.PcGroupName = "HomeGroup";
                cpi.MID = int.Parse(b1_id.Value);
                cpi.Caption1 = banner_home_1.Text.Trim();
                cpi.URL = b1_url.Value;
                cpi.PcName = "banner-announce";

                cpi.ClearCustomByPostIDandName(intPostID, "banner-announce");
                cpi.Insert(cpi);


                //banner left
                Model_PostCustomItem cpi_1 = new Model_PostCustomItem();
                cpi_1.PCDID = (int)CustomGroup.HomeGroup;
                cpi_1.PostID = intPostID;
                cpi_1.PcGroupName = "HomeGroup";
                cpi_1.MID = int.Parse(b2_id.Value);
                cpi_1.Caption1 = banner_home_2.Text.Trim();
                cpi_1.URL = b2_url.Value;
                cpi_1.PcName = "banner-announce-right";
                cpi_1.ClearCustomByPostIDandName(intPostID, "banner-announce-right");
                cpi_1.Insert(cpi_1);

                //banner
                Model_PostCustomItem cpi_2_c = new Model_PostCustomItem();
                cpi_2_c.ClearCustomByPostIDandName(intPostID, "banner-client");
                string chk_banner_client = Request.Form["chk_banner_client"];
                if (!string.IsNullOrEmpty(chk_banner_client))
                {
                    string[] arr = chk_banner_client.Split(',');
                    foreach (string i in arr)
                    {
                        Model_PostCustomItem cpi_2 = new Model_PostCustomItem();
                        cpi_2.PCDID = (int)CustomGroup.HomeGroup;
                        cpi_2.PostID = intPostID;
                        cpi_2.PcGroupName = "HomeGroup";
                        cpi_2.MID = int.Parse(Request.Form["b3_id_" + i]);
                        cpi_2.Caption1 = Request.Form["caption_s_" + i];
                        cpi_2.URL = Request.Form["b3_url_" + i];
                        cpi_2.PcName = "banner-client";
                        cpi_2.Insert(cpi_2);
                    }
                }

            }



            //Model_PostCustomGroup pct = new Model_PostCustomGroup();
            //List<Model_PostCustomGroup> pctList = pct.getCustomByPostID(intPostID);

            //foreach (Model_PostCustomGroup pci in pctList)
            //{
            //    switch (pci.PcGroupName)
            //    {
            //        case "HomeGroup":
            //            pn_home_custom.Visible = true;




            //            break;
            //    }
            //}

            if (p.UpdatePost(p))
                Response.Redirect(Request.Url.ToString());
        }
       

    }

    protected void linktrash_Click(object sender, EventArgs e)
    {
        int intPostID = int.Parse(Request.QueryString["PostID"]);
        byte intPostTypeID = byte.Parse(Request.QueryString["PostTypeID"]);

        Model_Post p = new Model_Post();
        if (p.UPDATETrash(intPostID, false))
        {
            Response.Redirect("Edit?PostTypeID=" + intPostTypeID);
        }


    }

    protected void linkrestore_Click(object sender, EventArgs e)
    {
        int intPostID = int.Parse(Request.QueryString["PostID"]);
        //byte intPostTypeID = byte.Parse(Request.QueryString["PostTypeID"]);

        Model_Post p = new Model_Post();
        if (p.UPDATETrash(intPostID, true))
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}