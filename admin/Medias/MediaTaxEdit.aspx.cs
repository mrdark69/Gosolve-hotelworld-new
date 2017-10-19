using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _TaxonomyEdit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {


            //byte intPostTypeID = byte.Parse(this.PostTypeID);
            //byte intTaxTypeID = byte.Parse(this.TaxTypeID);
            //Model_PostType cp = new Model_PostType();

            //cp = cp.GetPostTypeByID(intPostTypeID);
            //Literal hTitle = this.Page.Master.FindControl("PageTitleHeader") as Literal;

            //string Title = cp.Title + "-" + (intTaxTypeID == 1 ? "Category" : "Tags");
            //hTitle.Text = ": " + Title;

            //titlepage.Text = Title + " List";
            //addTax.Visible = false;
            //addTax.NavigateUrl = "/admin/Post/Taxonomy?TaxTypeID=" + this.TaxTypeID + "&PostTypeID=" + this.PostTypeID + "&Mode=Add";

            //HyperLink addTax = this.Page.Master.FindControl("AdnewBtn") as HyperLink;
            //addTax.Visible = true;
            //addTax.NavigateUrl = "/admin/Post/Taxonomy?TaxTypeID=" + this.TaxTypeID + "&PostTypeID=" + this.PostTypeID + "&Mode=Add";
        }
    }

  
}