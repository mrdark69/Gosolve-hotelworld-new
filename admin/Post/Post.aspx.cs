using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

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

                    url.Text = this.MainSetting.WebSiteURL + (p.PostTypeID != 1 ? p.PostTypeClass.Slug + "/" : string.Empty);
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

                        Model_PostMedia feature = p.PostMedia.FirstOrDefault(r => r.PostID == PostID && r.PostMediaTypeID == PostMediaType.FeatureImage);
                        if (feature != null)
                        {
                            feature_image_mid.Value = feature.MID.ToString();
                            feature_image_url.Value = this.MainSetting.WebSiteURL + feature.MediaFullPath;
                            //hd_postMeidaID.Value = cover.PostMediaID.ToString();
                        }
                    }


                    //Chcek Defaul Postype Field Charactor
                    //if PostType = product 
                    if(p.PostTypeID == 3)
                    {
                        Model_TaxMap ctm = new Model_TaxMap();
                        List<Model_TaxMap> ctm_cat = ctm.GetTaxByPostIDandTaxType(PostID, (byte)PostTaxonomyType.Categories);
                        List<Model_TaxMap> ctm_tag = ctm.GetTaxByPostIDandTaxType(PostID, (byte)PostTaxonomyType.Tags);

                        pn_product_default.Visible = true;
                        Model_PostTaxonomy pt = new Model_PostTaxonomy
                        {
                            PostTypeID = p.PostTypeID,
                            TaxTypeID = (byte)PostTaxonomyType.Categories
                        };
                        List<Model_PostTaxonomy> Taxlist = pt.GetTaxonomyActiveOnly(pt);
                        CategoryTax.Text = getCatProduct(Taxlist, ctm_cat);
                        Model_PostTaxonomy pttags = new Model_PostTaxonomy
                        {
                            PostTypeID = p.PostTypeID,
                            TaxTypeID = (byte)PostTaxonomyType.Tags
                        };
                        List<Model_PostTaxonomy> TaxlistTags = pt.GetTaxonomyActiveOnly(pttags);
                        TagsTax.Text = getTagsProductList(TaxlistTags, ctm_tag);

                        List<Model_PostMedia> gall = p.PostMedia.Where(r => r.PostID == PostID && r.PostMediaTypeID == PostMediaType.Gallery).ToList();
                        if (gall.Count()>0 )
                        {

                            string ele = string.Empty;
                            foreach(Model_PostMedia m in gall)
                            {
                                string mid = m.MID.ToString();
                               

                                ele += "<div class=\"media_item_box_gall\" id=\"media_item_box_gall_" + mid + "\" style=\"margin-top:5px;\">";
                                ele += "<label class=\"box_media_fucus_block\" onclick=\"return false;\" style=\"background-image: url(" + m.MediaFullPath + ");\"><button data-idmediab=\"media_item_box_8\" onclick=\"removeMedia_gall(this);\" class=\"btn btn-warning btn-circle btn-media-focus\" type=\"button\"><i class=\"fa fa-times\"></i></button></label>";
                                ele += "<input type=\"checkbox\" checked=\"checked\" name=\"checkGall\" style=\"display:none;\"  value=\"" + mid + "\">";
                                ele += "<input type=\"hidden\" name=\"p_gall_" + mid + "\" id=\"p_gall_" + mid + "\" value=\"" + m.MediaFullPath + "\">";
                                ele += "<input type=\"hidden\" name=\"p_gall_mid" + mid + "\" id=\"p_gall_mid" + mid + "\" value=\"" + mid + "\">";
                                ele += "<input type=\"hidden\" name=\"p_gall_pri" + mid + "\" id=\"p_gall_pri" + mid + "\"value=\"" + m.Priority + "\">";
                                ele += "</div>";
                            }
                          
                            //hd_MID.Value = cover.MID.ToString();
                            //CoverImage1.Value = this.MainSetting.WebSiteURL + cover.MediaFullPath;
                            //hd_postMeidaID.Value = cover.PostMediaID.ToString();

                            gal_server.Text = ele;
                        }


                    }
                   


                    //Check Cutom Post Field
                    Model_PostCustomGroup pct = new Model_PostCustomGroup();
                    List<Model_PostCustomGroup> pctList = pct.getCustomByPostID(PostID);

                    foreach (Model_PostCustomGroup pci in pctList)
                    {
                        switch (pci.PcGroupName)
                        {
                            case "HomeGroup":
                                pn_home_custom.Visible = true;
                                List<Model_PostCustomItem> itemList = pci.CustomItem;
                                Model_PostCustomItem bannerAnn = itemList.SingleOrDefault(r => r.PcName == "banner-announce");
                                if (bannerAnn != null)
                                {
                                    b1_url.Value = bannerAnn.URL;
                                    b1_id.Value = bannerAnn.MID.ToString();
                                    banner_home_1.Text = bannerAnn.Caption1;
                                }



                                Model_PostCustomItem bannerright = itemList.SingleOrDefault(r => r.PcName == "banner-announce-right");
                                if (bannerright != null)
                                {
                                    b2_url.Value = bannerright.URL;
                                    b2_id.Value = bannerright.MID.ToString();
                                    banner_home_2.Text = bannerright.Caption1;
                                }

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


                            case "ProductGroup":
                                pn_product_custom.Visible = true;
                                main_post_content.Visible = false;
                            
                                //TagsTax



                                //bing
                                //product_detail = 1,
                                //product_information = 2,
                                //product_b_announce = 3,
                                //product_b_rigth = 4

                                List<Model_PostCustomItem> ProductitemList = pci.CustomItem;
                                Model_PostCustomItem PbannerAnn = ProductitemList.SingleOrDefault(r => r.PcName == "product-b-announce");

                                if (PbannerAnn != null)
                                {
                                    p_banner_ann_8.Value = PbannerAnn.URL;
                                    p_banner_ann_mid_8.Value = PbannerAnn.MID.ToString();
                                    p_banner_ann_caption.Text = PbannerAnn.Caption1;
                                }



                                Model_PostCustomItem Pbannerright = ProductitemList.SingleOrDefault(r => r.PcName == "product-b-rigth");
                                if (Pbannerright != null)
                                {
                                    p_banner_9.Value = Pbannerright.URL;
                                    p_banner_mid_9.Value = Pbannerright.MID.ToString();
                                    p_banner_rigth.Text = Pbannerright.Caption1;
                                }


                                Model_PostCustomItem P_pro_de = ProductitemList.SingleOrDefault(r => r.PcName == "product-detail");
                                if (P_pro_de != null)
                                {
                                    ProductDetail.Text = P_pro_de.ContentHTML;
                                }

                                Model_PostCustomItem P_pro_info = ProductitemList.SingleOrDefault(r => r.PcName == "product-information");
                                if (P_pro_info != null)
                                {
                                    ProductInformation.Text = P_pro_info.ContentHTML;
                                }


                                break;
                        }
                    }

                }






            }


        }
    }

    public string getTagsProductList(List<Model_PostTaxonomy> Taxlist, List<Model_TaxMap> taxmap)
    {
        StringBuilder ret = new StringBuilder();


        ret.Append("<div class='tax_parent'>");

        List<Model_PostTaxonomy> Taxlistdrop = new List<Model_PostTaxonomy>();



        foreach (Model_PostTaxonomy i in Taxlist.Where(g => g.RefID == 0).OrderBy(o => o.Priority))
        {
            ret.Append("<p class='parent_main_item'><input type='checkbox' "+ (taxmap.Where(x => x.TaxID == i.TaxID).Count() > 0 ? "checked='checked'" : "") + " value='" + i.TaxID+"' name='product_tax_tags' />");
            ret.Append( i.Title + "</p>");

           

        }


        ret.Append("</div>");
        return ret.ToString();
    }
    public string getCatProduct(List<Model_PostTaxonomy> Taxlist, List<Model_TaxMap> taxmap)
    {
        StringBuilder ret = new StringBuilder();


        ret.Append("<div class='tax_parent'>");

        List<Model_PostTaxonomy> Taxlistdrop = new List<Model_PostTaxonomy>();

        

        foreach (Model_PostTaxonomy i in Taxlist.Where(g => g.RefID == 0).OrderBy(o=>o.Priority))
        {
            //ret.Append("<input type='checkbox' value='"+i.TaxID+"' name='product_tax_cat' />");
            ret.Append("<p class='parent_main_item'><i class=\"fa fa-star\"></i> "+i.Title+"</p>");
           
            if (Taxlist.Where(f => f.RefID == i.TaxID).Count() > 0)
            {
                ret.Append("<div class='tax_child'>");
                ret.Append(getchild(Taxlist.Where(f => f.RefID == i.TaxID).ToList(), Taxlist, i.TaxID, taxmap));
                ret.Append("</div>");
            }

        }
        

        ret.Append("</div>");
        return ret.ToString();
    }


    public string getchild(List<Model_PostTaxonomy> data, List<Model_PostTaxonomy> raw, int id, List<Model_TaxMap> taxmap)
    {
        StringBuilder ret = new StringBuilder();
        List<Model_PostTaxonomy> retdataret = new List<Model_PostTaxonomy>();
        foreach (Model_PostTaxonomy c in data)
        {
            
            ret.Append("<p class='child_item'><input type='checkbox' "+(taxmap.Where(x=>x.TaxID == c.TaxID).Count() > 0? "checked='checked'":"") +" value='" + c.TaxID+"' name='product_tax_cat' />");
            ret.Append( c.Title + "</p>");
            if (raw.Where(f => f.RefID == c.TaxID).Count() > 0)
            {
                ret.Append("<div class='tax_child'>");
                ret.Append(getchild(raw.Where(f => f.RefID == c.TaxID).ToList(), raw, c.TaxID, taxmap));
                ret.Append("</div>");
            }
        }
        return ret.ToString();
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

            //Cover 
            if (!string.IsNullOrEmpty(feature_image_mid.Value))
            {
                Model_PostMedia pm = new Model_PostMedia
                {

                    PostMediaTypeID = PostMediaType.FeatureImage,
                    PostID = intPostID,
                    MID = int.Parse(feature_image_mid.Value)
                };

                pm.insertMediaPost(pm);
            }
            else
            {
                Model_PostMedia pm = new Model_PostMedia
                {

                    PostMediaTypeID = PostMediaType.FeatureImage,
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
                cpi.MID = !string.IsNullOrEmpty(b1_id.Value) ? int.Parse(b1_id.Value) : 0; 
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
                cpi_1.MID = !string.IsNullOrEmpty(b2_id.Value) ? int.Parse(b2_id.Value) : 0;  
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
                        cpi_2.MID = !string.IsNullOrEmpty(Request.Form["b3_id_" + i]) ? int.Parse(Request.Form["b3_id_" + i]) : 0;
                        cpi_2.Caption1 = Request.Form["caption_s_" + i];
                        cpi_2.URL = Request.Form["b3_url_" + i];
                        cpi_2.PcName = "banner-client";
                        cpi_2.Insert(cpi_2);
                    }
                }

            }



            if (pctList.SingleOrDefault(i => i.PcGroupName == "ProductGroup") != null)
            {
                //            product_detail = 1,
                //product_information = 2,
                //product_b_announce = 3,
                //product_b_rigth = 4

                //banner announce
                Model_PostCustomItem cpi = new Model_PostCustomItem();
                cpi.PostID = intPostID;
                cpi.PCDID = (int)CustomGroup.ProductGroup;
                cpi.PcGroupName = "ProductGroup";
                cpi.MID = !string.IsNullOrEmpty(p_banner_ann_mid_8.Value) ? int.Parse(p_banner_ann_mid_8.Value) : 0;
                cpi.Caption1 = p_banner_ann_caption.Text.Trim();
                cpi.URL = p_banner_ann_8.Value;
                cpi.PcName = "product-b-announce";

                cpi.ClearCustomByPostIDandName(intPostID, "product-b-announce");
                cpi.Insert(cpi);


                //banner left
                Model_PostCustomItem cpi_1 = new Model_PostCustomItem();
                cpi_1.PCDID = (int)CustomGroup.ProductGroup;
                cpi_1.PostID = intPostID;
                cpi_1.PcGroupName = "ProductGroup";
                cpi_1.MID = !string.IsNullOrEmpty(p_banner_mid_9.Value) ? int.Parse(p_banner_mid_9.Value) :0;
                cpi_1.Caption1 = p_banner_rigth.Text.Trim();
                cpi_1.URL = p_banner_9.Value;
                cpi_1.PcName = "product-b-rigth";
                cpi_1.ClearCustomByPostIDandName(intPostID, "product-b-rigth");
                cpi_1.Insert(cpi_1);

                //product detail
                Model_PostCustomItem p_detail = new Model_PostCustomItem();
                p_detail.PCDID = (int)CustomGroup.ProductGroup;
                p_detail.PostID = intPostID;
                p_detail.PcGroupName = "ProductGroup";
                p_detail.ContentHTML = ProductDetail.Text;
                p_detail.PcName = "product-detail";
                p_detail.ClearCustomByPostIDandName(intPostID, "product-detail");
                p_detail.Insert(p_detail);

                //product information
                Model_PostCustomItem p_information = new Model_PostCustomItem();
                p_information.PCDID = (int)CustomGroup.ProductGroup;
                p_information.PostID = intPostID;
                p_information.PcGroupName = "ProductGroup";
                p_information.ContentHTML = ProductInformation.Text;
                p_information.PcName = "product-information";
                p_information.ClearCustomByPostIDandName(intPostID, "product-information");
                p_information.Insert(p_information);
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
            //}product_tax_cat product_tax_tags
            Model_TaxMap ctm = new Model_TaxMap();
            string product_tax_cat = Request.Form["product_tax_cat"];
            string product_tax_tags = Request.Form["product_tax_tags"];

            if (!string.IsNullOrEmpty(product_tax_cat))
            {
                ctm.ClearRaxPostMap(intPostID, (byte)PostTaxonomyType.Categories);

                string[] arrcat = product_tax_cat.Split(',');
                foreach(string i in arrcat)
                {
                    ctm.UpdateInsertPostTax(int.Parse(i), intPostID, (byte)PostTaxonomyType.Categories);
                }
            }
            if (!string.IsNullOrEmpty(product_tax_tags))
            {
                ctm.ClearRaxPostMap(intPostID, (byte)PostTaxonomyType.Tags);
                string[] arrtag = product_tax_tags.Split(',');
                foreach (string i in arrtag)
                {
                    ctm.UpdateInsertPostTax(int.Parse(i), intPostID, (byte)PostTaxonomyType.Tags);
                }
            }


            string gall = Request.Form["checkGall"];
            if (!string.IsNullOrEmpty(gall))
            {
                Model_PostMedia pm = new Model_PostMedia
                {

                    PostMediaTypeID = PostMediaType.Gallery,
                    PostID = intPostID

                };
                pm.DeletePostMedia(pm);
                string[] arrGall = gall.Split(',');
                foreach(string i in arrGall)
                {
                    Model_PostMedia cpm = new Model_PostMedia
                    {
                        PostMediaTypeID = PostMediaType.Gallery,
                        PostID = intPostID,
                        MID = int.Parse(i),
                        Priority = int.Parse(Request.Form["p_gall_pri" + i])
                    };
                    cpm.insertMediaPostGall(cpm);
                }
            }
            else
            {
                Model_PostMedia pm = new Model_PostMedia
                {

                    PostMediaTypeID = PostMediaType.Gallery,
                    PostID = intPostID

                };
                pm.DeletePostMedia(pm);
            }

            //Media Gallery


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