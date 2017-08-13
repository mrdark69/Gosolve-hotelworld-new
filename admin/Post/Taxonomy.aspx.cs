using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Taxonomy : BasePage
{
   


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (this.TaxTypeID == "2")
                taxParent.Visible = false;

            byte intPostTypeID = byte.Parse(this.PostTypeID);
            byte intTaxTypeID = byte.Parse(this.TaxTypeID);

            Model_PostTaxonomy pt = new Model_PostTaxonomy
            {
                PostTypeID = intPostTypeID,
                TaxTypeID = intTaxTypeID
            };
            List<Model_PostTaxonomy> Taxlistdrop = new List<Model_PostTaxonomy>();

            List<Model_PostTaxonomy> Taxlist = pt.GetTaxonomyActiveOnly(pt);

            foreach(Model_PostTaxonomy i in Taxlist.Where(g=>g.RefID == 0))
            {
                Taxlistdrop.Add(i);

                if(Taxlist.Where(f => f.RefID == i.TaxID).Count() > 0)
                {
                    Taxlistdrop.AddRange(getchild(Taxlist.Where(f => f.RefID == i.TaxID).ToList(),Taxlist, i.TaxID));
                }
                
            }

            Model_PostType cp = new Model_PostType();
            
           cp = cp.GetPostTypeByID(intPostTypeID);


         


           Literal hTitle = this.Page.Master.FindControl("PageTitleHeader") as Literal;
            hTitle.Text = ": " + cp.Title + "-" + (intTaxTypeID == 1 ? "Category" : "Tags");

            ListItem listitem = new ListItem("None", "0");
            if (!string.IsNullOrEmpty(this.Mode))
            {
                switch (this.Mode)
                {
                    case "Add":

                        slug_form.Visible = false;
                        btnPubish.Text = "Add New Now";
                        tab_seo.Visible = false;
                        tab_facebook.Visible = false;
                        tab_twitter.Visible = false;
                        //form_status.Visible = false;
                        //form_publish.Visible = false;
                        //form_viewcount.Visible = false;
                        cover_img.Visible = false;
                        //cover_type.Visible = false;
                        //master_slider.Visible = false;



                        lbldatepublish.Text = "----";
                        dropStatus.SelectedValue = "True";
                        viewcount.Text = "0";


                        dropParent.DataSource = Taxlistdrop;
                        dropParent.DataValueField = "TaxID";
                        dropParent.DataTextField = "TitleLevel";
                        dropParent.DataBind();


                       
                        dropParent.Items.Insert(0, listitem);
                        break;
                    case "Edit":

                        HyperLink addTax = this.Page.Master.FindControl("AdnewBtn") as HyperLink;
                        addTax.Visible = true;
                        addTax.NavigateUrl = "/admin/Post/Taxonomy.aspx?TaxTypeID=" + this.TaxTypeID + "&PostTypeID=" + this.PostTypeID + "&Mode=Add";


                        Model_PostTaxonomy tax = new Model_PostTaxonomy();
                        int TaxID = int.Parse(Request.QueryString["TaxID"]);
                        tax = tax.GetTaxonomyByID(int.Parse(Request.QueryString["TaxID"]));
                        slug.Text = tax.Slug.Trim();
                        slug_form.Visible = true;
                        viewcount.Text = tax.ViewCount.ToString();
                        txtTitle.Text = tax.Title.Trim();
                        lbldatepublish.Text = tax.DatePublish.ToThaiDateTime().ToString("dd MMM yyyy HH:mm tt");
                        dropStatus.SelectedValue = tax.Status.ToString();



                        txtContentBuilder.Text = tax.BodyContentBuilder;
                        txtContent.Text = tax.BodyContent;

                        if (tax.Trash)
                        {
                            linktrash.Visible = true;
                            linkrestore.Visible = false;
                        }
                        else
                        {
                            linktrash.Visible = false;
                            linkrestore.Visible = true;

                        }

                        if (tax.TaxSEO != null)
                        {
                            Model_PostSeo seo = tax.TaxSEO;
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

                        if (tax.TaxMedia.Count > 0)
                        {
                            Model_TaxMedia cover = tax.TaxMedia.FirstOrDefault(r => r.TaxID == TaxID && r.TaxMediaTypeID == TaxMediaType.CoverImage);
                            if (cover != null)
                            {
                                hd_MID.Value = cover.MID.ToString();
                                CoverImage1.Value = this.MainSetting.WebSiteURL + cover.MediaFullPath;
                                //hd_postMeidaID.Value = cover.PostMediaID.ToString();
                            }

                            Model_TaxMedia feature = tax.TaxMedia.FirstOrDefault(r => r.TaxID == TaxID && r.TaxMediaTypeID == TaxMediaType.FeatureImage);
                            if (feature != null)
                            {
                                feature_image_mid.Value = feature.MID.ToString();
                                feature_image_url.Value = this.MainSetting.WebSiteURL + feature.MediaFullPath;
                                //hd_postMeidaID.Value = cover.PostMediaID.ToString();
                            }

                            Model_TaxMedia feature_full = tax.TaxMedia.FirstOrDefault(r => r.TaxID == TaxID && r.TaxMediaTypeID == TaxMediaType.Feature_Image_full_Width);
                            if (feature_full != null)
                            {
                                image_full_width_mid.Value = feature_full.MID.ToString();
                                image_full_width_url.Value = this.MainSetting.WebSiteURL + feature_full.MediaFullPath;
                                //hd_postMeidaID.Value = cover.PostMediaID.ToString();
                            }
                        }


                        CoverType.Value = tax.BannerTypeID.ToString();
                        radioshowmMS.SelectedValue = tax.ShowMasterSlider.ToString();
                        
                        dropParent.DataSource = Taxlistdrop.Where(r => r.TaxID != TaxID);
                        dropParent.DataValueField = "TaxID";
                        dropParent.DataTextField = "TitleLevel";
                        dropParent.DataBind();


                        
                        dropParent.Items.Insert(0, listitem);

                        dropParent.SelectedValue = tax.RefID.ToString();
                        break;
                }

              
               

            }
            

        }
    }

   public List<Model_PostTaxonomy> getchild(List<Model_PostTaxonomy> data, List<Model_PostTaxonomy> raw, int id)
   {
        List<Model_PostTaxonomy> ret = new List<Model_PostTaxonomy>();
        foreach (Model_PostTaxonomy c in data)
        {
            ret.Add(c);

            if (raw.Where(f => f.RefID == c.TaxID).Count() > 0)
            {
                ret.AddRange(getchild(raw.Where(f => f.RefID == c.TaxID).ToList() ,raw, c.TaxID));
            }
        }
        return ret;
    }

    protected void btnPubish_Click(object sender, EventArgs e)
    {



        if (!string.IsNullOrEmpty(this.Mode))
        {
            switch (this.Mode)
            {
                case "Add":
                    slug_form.Visible = false;
                    InsertMode();
                    break;
                case "Edit":

                    Update();
                    //slug_form.Visible = true;
                    break;
            }
        }

    }

    public void Update()
    {
        int TaxID = int.Parse(Request.QueryString["TaxID"]);


        int lv = 0;
        int Taxref = int.Parse(dropParent.SelectedValue);
        if (Taxref > 0)
        {
            Model_PostTaxonomy t = new Model_PostTaxonomy();
            lv = t.GetTaxonomyByID(Taxref).Lv + 1;
        }
        else
            lv = Taxref + 1;


        Model_PostTaxonomy tax = new Model_PostTaxonomy
        {
            TaxID = TaxID,
            Lv = lv,
            Title = txtTitle.Text.Trim(),
            RefID = Taxref,
            Slug = slug.Text.GenerateSlug(),
            BodyContent = txtContent.Text.Trim(),
            BodyContentBuilder = txtContentBuilder.Text.Trim(),
            Status = bool.Parse(dropStatus.SelectedValue),
            BannerTypeID = byte.Parse(CoverType.Value),
            ShowMasterSlider = bool.Parse(radioshowmMS.SelectedValue),
         
        };
        

        Model_TaxSEOMap seomap = new Model_TaxSEOMap();
        seomap = seomap.GetSEOID(TaxID);

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
                seomap = new Model_TaxSEOMap
                {
                    TaxID = TaxID,
                    PSID = PSID
                };

                seomap.InsertMApSeo(seomap);
            }

        }

        if (!string.IsNullOrEmpty(hd_MID.Value))
        {
            Model_TaxMedia pm = new Model_TaxMedia
            {

                TaxMediaTypeID = TaxMediaType.CoverImage,
                TaxID = TaxID,
                MID = int.Parse(hd_MID.Value)
            };

            pm.insertMediaPost(pm);
        }
        else
        {
            Model_TaxMedia pm = new Model_TaxMedia
            {

                TaxMediaTypeID = TaxMediaType.CoverImage,
                TaxID = TaxID
               
            };
            pm.DeleteTaxMedia(pm);
        }


        //Feature image 
        if (!string.IsNullOrEmpty(feature_image_mid.Value))
        {
            Model_TaxMedia pm = new Model_TaxMedia
            {

                TaxMediaTypeID = TaxMediaType.FeatureImage,
                TaxID = TaxID,
                MID = int.Parse(feature_image_mid.Value)
            };

            pm.insertMediaPost(pm);
        }
        else
        {
            Model_TaxMedia pm = new Model_TaxMedia
            {

                TaxMediaTypeID = TaxMediaType.FeatureImage,
                TaxID = TaxID

            };

            pm.DeleteTaxMedia(pm);
        }

        //Feature image full 
        if (!string.IsNullOrEmpty(feature_image_mid.Value))
        {
            Model_TaxMedia pm = new Model_TaxMedia
            {

                TaxMediaTypeID = TaxMediaType.Feature_Image_full_Width,
                TaxID = TaxID,
                MID = int.Parse(image_full_width_mid.Value)
            };

            pm.insertMediaPost(pm);
        }
        else
        {
            Model_TaxMedia pm = new Model_TaxMedia
            {

                TaxMediaTypeID = TaxMediaType.Feature_Image_full_Width,
                TaxID = TaxID

            };

            pm.DeleteTaxMedia(pm);
        }


        bool ret = tax.UpdateTaxonomy(tax);
        if (ret)
            Response.Redirect("Taxonomy.aspx?TaxTypeID=" + this.TaxTypeID + "&PostTypeID=" + this.PostTypeID + "&Mode=Edit&TaxID=" + TaxID);
    }

    public void InsertMode()
    {
        int lv = 0;
        int Taxref = int.Parse(dropParent.SelectedValue);
        if (Taxref > 0)
        {
            Model_PostTaxonomy t = new Model_PostTaxonomy();
            lv = t.GetTaxonomyByID(Taxref).Lv + 1;
        }
        else
            lv = Taxref + 1;

        Model_PostTaxonomy tax = new Model_PostTaxonomy
        {
            PostTypeID = byte.Parse(this.PostTypeID),
            TaxTypeID = byte.Parse(this.TaxTypeID),
            Title = txtTitle.Text.Trim(),
            RefID = Taxref,
            Lv = lv,
            Slug = txtTitle.Text.GenerateSlug(),
            DateSubmit = DatetimeHelper._UTCNow(),
            UserID = this.UserActive.UserID,
            DatePublish = DatetimeHelper._UTCNow(),
            BodyContent = txtContent.Text.Trim(),
            BodyContentBuilder = txtContentBuilder.Text.Trim(),
            Status = true,
            BannerTypeID = byte.Parse(CoverType.Value),
            ShowMasterSlider = bool.Parse(radioshowmMS.SelectedValue),
            ViewCount = 0,
            
        };

        int TaxID = tax.InsertTaxonomy(tax);
        if (TaxID > 0)
            Response.Redirect("Taxonomy.aspx?TaxTypeID=" + this.TaxTypeID + "&PostTypeID=" + this.PostTypeID + "&Mode=Edit&TaxID=" + TaxID);
    }

    protected void linktrash_Click(object sender, EventArgs e)
    {
        int TaxTypeID = int.Parse(this.TaxTypeID);
        byte intPostTypeID = byte.Parse(this.PostTypeID);
        int TaxID = int.Parse(Request.QueryString["TaxID"]);

        Model_PostTaxonomy tax = new Model_PostTaxonomy();
        if (tax.UPdateTaxonomyTrash(TaxID, false))
        {
            Response.Redirect("TaxonomyEdit?PostTypeID=" + intPostTypeID + "&TaxTypeID="+ TaxTypeID);
        }


    }

    protected void linkrestore_Click(object sender, EventArgs e)
    {
       
        int TaxID = int.Parse(Request.QueryString["TaxID"]);

        Model_PostTaxonomy tax = new Model_PostTaxonomy();
        if (tax.UPdateTaxonomyTrash(TaxID, true))
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}