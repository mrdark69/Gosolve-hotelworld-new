using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Page_New : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            byte intPostTypeID = byte.Parse(this.PostTypeID);

            Model_PostType cp = new Model_PostType();

            cp = cp.GetPostTypeByID(intPostTypeID);
            Literal hTitle = this.Page.Master.FindControl("PageTitleHeader") as Literal;

            string Title = cp.Title;
            hTitle.Text = ": " + Title;

            //titlepage.Text = Title + " List";


        }
    }



    protected void btnPubish_Click(object sender, EventArgs e)
    {
        

        Model_Post p = new Model_Post
        {
            PostTypeID = byte.Parse(Request.QueryString["PostTypeID"]),
            Title = txtTitle.Text.Trim(),
            Short = "",
            Slug = txtTitle.Text.GenerateSlug(),
            DateSubmit = DatetimeHelper._UTCNow(),
            UserID = this.UserActive.UserID,
            DatePublish = DatetimeHelper._UTCNow(),
            Status = true,
            ShowComment = false,
            BodyContent = txtContent.Text.Trim(),
            BannerTypeID = byte.Parse(CoverType.Value),
            ShowMasterSlider = bool.Parse(radioshowmMS.SelectedValue),
            ViewCount= 1
        };

        int postid = p.InsertPost(p);
        if (postid > 0)
            Response.Redirect("Post?PostID=" + postid);

        //Response.Write(txtContent.Text);
        //Response.End();
    }
}