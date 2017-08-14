using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _PTSManage : BasePage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
          
            byte intPostTypeID = byte.Parse(this.PostTypeID);
            //byte intTaxTypeID = byte.Parse(this.TaxTypeID);

            //Model_PostTaxonomy pt = new Model_PostTaxonomy
            //{
            //    PostTypeID = intPostTypeID,
            //    TaxTypeID = intTaxTypeID
            //};
            //List<Model_PostTaxonomy> Taxlistdrop = new List<Model_PostTaxonomy>();

            //List<Model_PostTaxonomy> Taxlist = pt.GetTaxonomyActiveOnly(pt);

            //foreach(Model_PostTaxonomy i in Taxlist.Where(g=>g.RefID == 0))
            //{
            //    Taxlistdrop.Add(i);

            //    if(Taxlist.Where(f => f.RefID == i.PostTypeID).Count() > 0)
            //    {
            //        Taxlistdrop.AddRange(getchild(Taxlist.Where(f => f.RefID == i.PostTypeID).ToList(),Taxlist, i.PostTypeID));
            //    }
                
            //}

            Model_PostType cp = new Model_PostType();
            
           cp = cp.GetPostTypeByID(intPostTypeID);

            if (cp != null)
            {

                slug.Text = cp.Slug.Trim();
                slug.Enabled = false;

                txtTitle.Text = cp.Title.Trim();
                viewcount.Text = cp.ViewCount.ToString();
                //HyperLink addTax = this.Page.Master.FindControl("AdnewBtn") as HyperLink;
                //addTax.Visible = true;
                //addTax.NavigateUrl = "/admin/Post/Taxonomy.aspx?TaxTypeID=" + this.TaxTypeID + "&PostTypeID=" + this.PostTypeID + "&Mode=Add";



                if (cp.PosTypetSEO != null)
                {
                    Model_PostSeo seo = cp.PosTypetSEO;
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




                CoverType.Value = cp.BannerTypeID.ToString();
                radioshowmMS.SelectedValue = cp.ShowMasterSlider.ToString();

                if (cp.PostTypeMedia.Count > 0)
                {
                    Model_PostTypeMedia cover = cp.PostTypeMedia.FirstOrDefault(r => r.PostTypeID == intPostTypeID && r.PostTypeMediaTypeID == PostTypeMediaType.CoverImage);
                    if (cover != null)
                    {
                        hd_MID.Value = cover.MID.ToString();
                        CoverImage1.Value = cover.MediaFullPath;
                        //hd_postMeidaID.Value = cover.PostMediaID.ToString();
                    }

                    Model_PostTypeMedia feature = cp.PostTypeMedia.FirstOrDefault(r => r.PostTypeID == intPostTypeID && r.PostTypeMediaTypeID == PostTypeMediaType.FeatureImage);
                    if (feature != null)
                    {
                        feature_image_mid.Value = feature.MID.ToString();
                        feature_image_url.Value = feature.MediaFullPath;
                        //hd_postMeidaID.Value = cover.PostMediaID.ToString();
                    }

                    Model_PostTypeMedia feature_full = cp.PostTypeMedia.FirstOrDefault(r => r.PostTypeID == intPostTypeID && r.PostTypeMediaTypeID == PostTypeMediaType.Feature_Image_full_Width);
                    if (feature_full != null)
                    {
                        image_full_width_mid.Value = feature_full.MID.ToString();
                        image_full_width_url.Value = feature_full.MediaFullPath;
                        //hd_postMeidaID.Value = cover.PostMediaID.ToString();
                    }

                    //Model_PostTypeMedia upsell = cp.PostTypeMedia.FirstOrDefault(r => r.PostTypeID == intPostTypeID && r.PostTypeMediaTypeID == PostTypeMediaType.Banner_Upsell);
                    //if (upsell != null)
                    //{
                    //    banner_upsale_mid.Value = upsell.MID.ToString();
                    //    banner_upsale_url.Value = this.MainSetting.WebSiteURL + upsell.MediaFullPath;
                    //    textCationUpsale.Text = upsell.Caption;
                    //    //hd_postMeidaID.Value = cover.PostMediaID.ToString();
                    //}
                }
            }
            

            //dropParent.DataSource = Taxlistdrop.Where(r => r.PostTypeID != PostTypeID);
            //dropParent.DataValueField = "PostTypeID";
            //dropParent.DataTextField = "TitleLevel";
            // dropParent.DataBind();



            //dropParent.Items.Insert(0, listitem);

            //dropParent.SelectedValue = tax.RefID.ToString();


        }
    }

   public List<Model_PostTaxonomy> getchild(List<Model_PostTaxonomy> data, List<Model_PostTaxonomy> raw, int id)
   {
        List<Model_PostTaxonomy> ret = new List<Model_PostTaxonomy>();
        foreach (Model_PostTaxonomy c in data)
        {
            ret.Add(c);

            if (raw.Where(f => f.RefID == c.PostTypeID).Count() > 0)
            {
                ret.AddRange(getchild(raw.Where(f => f.RefID == c.PostTypeID).ToList() ,raw, c.PostTypeID));
            }
        }
        return ret;
    }

    protected void btnPubish_Click(object sender, EventArgs e)
    {


        Update();

    }

    public void Update()
    {
        byte intPostTypeID = byte.Parse(this.PostTypeID);




        Model_PostType cp = new Model_PostType
        {
            PostTypeID = intPostTypeID,
          
            Title = txtTitle.Text.Trim(),
           
            Slug = slug.Text.GenerateSlug(),
           // BodyContent = txtContent.Text.Trim(),
            //BodyContentBuilder = txtContentBuilder.Text.Trim(),
            //Status = bool.Parse(dropStatus.SelectedValue),
            BannerTypeID = byte.Parse(CoverType.Value),
            ShowMasterSlider = bool.Parse(radioshowmMS.SelectedValue),

        };


        Model_PostTypeSEOMap seomap = new Model_PostTypeSEOMap();
        seomap = seomap.GetSEOID(intPostTypeID);

        Model_PostSeo seo = new Model_PostSeo
        {

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

        if (seomap != null)
        {
            seo.PSID = seomap.PSID;
            seo.UpdateSEO(seo);
        }
        else
        {
            int PSID = seo.InsertSEO_step1(seo);
            if (PSID > 0)
            {
                seomap = new Model_PostTypeSEOMap
                {
                    PostTypeID = intPostTypeID,
                    PSID = PSID
                };

                seomap.InsertMApSeo(seomap);
            }

        }

        if (!string.IsNullOrEmpty(hd_MID.Value))
        {
            Model_PostTypeMedia pm = new Model_PostTypeMedia
            {

                PostTypeMediaTypeID = PostTypeMediaType.CoverImage,
                PostTypeID = intPostTypeID,
                MID = int.Parse(hd_MID.Value)
            };

            pm.insertMediaPost(pm);
        }
        else
        {
            Model_PostTypeMedia pm = new Model_PostTypeMedia
            {

                PostTypeMediaTypeID = PostTypeMediaType.CoverImage,
                PostTypeID = intPostTypeID

            };
            pm.DeletePostTypeMedia(pm);
        }


        //Feature image 
        if (!string.IsNullOrEmpty(feature_image_mid.Value))
        {
            Model_PostTypeMedia pm = new Model_PostTypeMedia
            {

                PostTypeMediaTypeID = PostTypeMediaType.FeatureImage,
                PostTypeID = intPostTypeID,
                MID = int.Parse(feature_image_mid.Value)
            };

            pm.insertMediaPost(pm);
        }
        else
        {
            Model_PostTypeMedia pm = new Model_PostTypeMedia
            {

                PostTypeMediaTypeID = PostTypeMediaType.FeatureImage,
                PostTypeID = intPostTypeID

            };

            pm.DeletePostTypeMedia(pm);
        }

        //Feature image full
        if (!string.IsNullOrEmpty(image_full_width_mid.Value))
        {
            Model_PostTypeMedia pm = new Model_PostTypeMedia
            {

                PostTypeMediaTypeID = PostTypeMediaType.Feature_Image_full_Width,
                PostTypeID = intPostTypeID,
                MID = int.Parse(image_full_width_mid.Value)
            };

            pm.insertMediaPost(pm);
        }
        else
        {
            Model_PostTypeMedia pm = new Model_PostTypeMedia
            {

                PostTypeMediaTypeID = PostTypeMediaType.Feature_Image_full_Width,
                PostTypeID = intPostTypeID

            };

            pm.DeletePostTypeMedia(pm);
        }



        bool ret = cp.UpdatePostType(cp);
        if (ret)
            Response.Redirect(Request.Url.ToString());
            //Response.Redirect("Taxonomy.aspx?TaxTypeID=" + this.TaxTypeID + "&PostTypeID=" + this.PostTypeID + "&Mode=Edit&PostTypeID=" + PostTypeID);
    }
    


}