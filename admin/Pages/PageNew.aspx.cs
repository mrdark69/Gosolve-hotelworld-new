using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _PageNew : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

         


        }
    }



    protected void btnPubish_Click(object sender, EventArgs e)
    {
        

        Model_Post p = new Model_Post
        {
            PostTypeID = 1,
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
            Response.Redirect("Page?PostID=" + postid);

        //Response.Write(txtContent.Text);
        //Response.End();
    }
}