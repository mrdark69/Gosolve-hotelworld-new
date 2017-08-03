﻿using System;
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

            Model_PostTaxonomy pt = new Model_PostTaxonomy
            {
                PostTypeID = byte.Parse(this.PostTypeID),
                TaxTypeID = byte.Parse(this.TaxTypeID)
            };

            List<Model_PostTaxonomy> Taxlist = pt.GetTaxonomyByIDMain(pt);

           

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


                        dropParent.DataSource = Taxlist;
                        dropParent.DataValueField = "TaxID";
                        dropParent.DataTextField = "Title";
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
                        }


                        CoverType.Value = tax.BannerTypeID.ToString();
                        radioshowmMS.SelectedValue = tax.ShowMasterSlider.ToString();
                        
                        dropParent.DataSource = Taxlist.Where(r => r.TaxID != TaxID);
                        dropParent.DataValueField = "TaxID";
                        dropParent.DataTextField = "Title";
                        dropParent.DataBind();


                        
                        dropParent.Items.Insert(0, listitem);

                        dropParent.SelectedValue = tax.RefID.ToString();
                        break;
                }

              
               

            }
            

        }
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
          
            Status = true,
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
            Status = true,
            BannerTypeID = byte.Parse(CoverType.Value),
            ShowMasterSlider = bool.Parse(radioshowmMS.SelectedValue),
            ViewCount = 0
        };

        int TaxID = tax.InsertTaxonomy(tax);
        if (TaxID > 0)
            Response.Redirect("Taxonomy.aspx?TaxTypeID=" + this.TaxTypeID + "&PostTypeID=" + this.PostTypeID + "&Mode=Edit&TaxID=" + TaxID);
    }


}