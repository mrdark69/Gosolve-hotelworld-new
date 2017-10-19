using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _MediaTax : BasePage
{
   


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
           


         


           //Literal hTitle = this.Page.Master.FindControl("PageTitleHeader") as Literal;
           // hTitle.Text = ": " + cp.Title + "-" + (intTaxTypeID == 1 ? "Category" : "Tags");

            ListItem listitem = new ListItem("None", "0");
            if (!string.IsNullOrEmpty(this.Mode))
            {
                switch (this.Mode)
                {
                    case "Add":

                        //slug_form.Visible = false;
                        btnPubish.Text = "Add New Now";
                      
                        //form_status.Visible = false;
                        //form_publish.Visible = false;
                        //form_viewcount.Visible = false;
                      
                        //cover_type.Visible = false;
                        //master_slider.Visible = false;



                        lbldatepublish.Text = "----";
                        //dropStatus.SelectedValue = "True";



                        linkrestore.Visible = false;
                        linktrash.Visible = false;
                        
                        break;
                    case "Edit":

                        HyperLink addTax = this.Page.Master.FindControl("AdnewBtn") as HyperLink;
                        addTax.Visible = true;
                        addTax.NavigateUrl = "/admin/Medias/MediaTax.aspx?Mode=Add";


                        //Model_PostTaxonomy tax = new Model_PostTaxonomy();
                        int TaxID = int.Parse(Request.QueryString["TaxID"]);
                        //tax = tax.GetTaxonomyByID(int.Parse(Request.QueryString["TaxID"]));
                        //slug.Text = tax.Slug.Trim();
                        //slug_form.Visible = true;


                     
                        //dropStatus.SelectedValue = tax.Status.ToString();
                        MediaTaxonomy tax = new MediaTaxonomy();
                        tax = tax.model_GetTaxonomyById(TaxID);

                        txtTitle.Text = tax.Title.Trim();
                        lbldatepublish.Text = tax.DatePublish.ToThaiDateTime().ToString("dd MMM yyyy HH:mm tt");
                        //txtContentBuilder.Text = tax.BodyContentBuilder;
                        //txtContent.Text = tax.BodyContent;

                        if (tax.Status)
                        {
                            linktrash.Visible = true;
                            linkrestore.Visible = false;
                        }
                        else
                        {
                            linktrash.Visible = false;
                            linkrestore.Visible = true;

                        }



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
                    //slug_form.Visible = false;
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
        

        MediaTaxonomy tax = new MediaTaxonomy
        {
            TaxID = TaxID,
           
            Title = txtTitle.Text.Trim(),
           
        };
        
        

        bool ret = tax.model_updateMediaTaxonomy(tax);
        if (ret)
            Response.Redirect("MediaTax.aspx?Mode=Edit&TaxID=" + TaxID);
    }

    public void InsertMode()
    {
       
        MediaTaxonomy tax = new MediaTaxonomy
        {

            Priority = 1,
            DatePublish = DatetimeHelper._UTCNow(),
            Title = txtTitle.Text.Trim(),
            KeyRef = 1,
            TaxType = "child",
            KeyID = 0,

        };
       

        int TaxID = tax.model_InsertChildTaxonomy(tax);
        if (TaxID > 0)
            Response.Redirect("MediaTax.aspx?Mode=Edit&TaxID=" + TaxID);
    }

    protected void linktrash_Click(object sender, EventArgs e)
    {
        //int TaxTypeID = int.Parse(this.TaxTypeID);
        //byte intPostTypeID = byte.Parse(this.PostTypeID);
        int TaxID = int.Parse(Request.QueryString["TaxID"]);

        MediaTaxonomy tax = new MediaTaxonomy();
        if (tax.model_updateMediaTaxonomyTrash(TaxID, false))
        {
            Response.Redirect("MediaTax.aspx?Mode=Edit&TaxID=" + TaxID);
        }


    }

    protected void linkrestore_Click(object sender, EventArgs e)
    {
       
        int TaxID = int.Parse(Request.QueryString["TaxID"]);

        MediaTaxonomy tax = new MediaTaxonomy();
        if (tax.model_updateMediaTaxonomyTrash(TaxID, true))
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}