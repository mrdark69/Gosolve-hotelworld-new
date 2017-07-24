using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Page : BasePage
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
                    lblstatus.Text = (p.Status ? "Published" : "Draft");
                    lbldatepublish.Text = p.DatePublish.ToThaiDateTime().ToString("dd MMM yyyy HH:mm tt");

                    txtTitle.Text = p.Title;
                    txtContent.Text = p.BodyContent;
                    Model_MainSetting setting = new Model_MainSetting();
                    setting = setting.GetMainSetting();

                    url.Text = setting.WebSiteURL;
                    slug.Text = p.Slug;


                    CoverType.Value = p.BannerTypeID.ToString();
                    radioshowmMS.SelectedValue = p.ShowMasterSlider.ToString();

                }

            }


        }
    }



    protected void btnPubish_Click(object sender, EventArgs e)
    {
        

        if (!string.IsNullOrEmpty(Request.QueryString["PostID"]))
        {
            Model_Post p = new Model_Post
            {
                PostID = int.Parse(Request.QueryString["PostID"]),
                PostTypeID = 1,
                Title = txtTitle.Text.Trim(),
                Short = "",
                Slug = slug.Text.GenerateSlug(),
                DateSubmit = DatetimeHelper._UTCNow(),
                UserID = this.UserActive.UserID,
                DatePublish = DatetimeHelper._UTCNow(),
                Status = true,
                ShowComment = false,
                BodyContent = txtContent.Text.Trim(),
                BannerTypeID = byte.Parse(CoverType.Value),
                ShowMasterSlider = bool.Parse(radioshowmMS.SelectedValue),
                ViewCount = 1
            };

            if (p.UpdatePost(p))
                Response.Redirect(Request.Url.ToString());
        }
       

    }
}