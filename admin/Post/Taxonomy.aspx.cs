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
                        break;
                    case "Edit":
                        Model_PostTaxonomy tax = new Model_PostTaxonomy();
                        int TaxID = int.Parse(Request.QueryString["TaxID"]);
                        tax = tax.GetTaxonomyByID(int.Parse(Request.QueryString["TaxID"]));
                        slug.Text = tax.Slug.Trim();
                        slug_form.Visible = true;

                        txtTitle.Text = tax.Title.Trim();


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


                        break;
                }

                Model_PostTaxonomy pt = new Model_PostTaxonomy
                {
                    PostTypeID = byte.Parse(this.PostTypeID),
                    TaxTypeID = byte.Parse(this.TaxTypeID)
                };

                dropParent.DataSource = pt.GetTaxonomyByIDMain(pt);
                dropParent.DataValueField = "TaxID";
                dropParent.DataTextField = "Title";
                dropParent.DataBind();


                ListItem listitem = new ListItem("No Parent", "0");
                dropParent.Items.Insert(0, listitem);

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
        Model_PostTaxonomy tax = new Model_PostTaxonomy
        {
            TaxID = TaxID,
         
            Title = txtTitle.Text.Trim(),
            RefID = int.Parse(dropParent.SelectedValue),
            Slug = slug.Text.GenerateSlug(),
          
            Status = true,
            BannerTypeID = byte.Parse(CoverType.Value),
            ShowMasterSlider = bool.Parse(radioshowmMS.SelectedValue),
         
        };

        bool ret = tax.UpdateTaxonomy(tax);
        if (ret)
            Response.Redirect("Taxonomy.aspx?TaxTypeID=" + this.TaxTypeID + "&PostTypeID=" + this.PostTypeID + "&Mode=Edit&TaxID=" + TaxID);
    }

    public void InsertMode()
    {
        Model_PostTaxonomy tax = new Model_PostTaxonomy
        {
            PostTypeID = byte.Parse(this.PostTypeID),
            TaxTypeID = byte.Parse(this.TaxTypeID),
            Title = txtTitle.Text.Trim(),
            RefID = int.Parse(dropParent.SelectedValue),
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