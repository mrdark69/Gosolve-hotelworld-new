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
        //    {
        //public int PostID { get; set; }
        //public int PostTypeID { get; set; }
        //public string Title { get; set; }
        //public string Short { get; set; }
        //public string Slug { get; set; }
        //public DateTime DateSubmit { get; set; }
        //public int UserID { get; set; }
        //public DateTime DatePublish { get; set; }
        //public bool Status { get; set; }
        //public bool ShowComment { get; set; }

        //public string BodyContent { get; set; }
        //public byte BannerTypeID { get; set; }

        //public bool ShowMasterSlider { get; set; }

        //public int ViewCount { get; set; }

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

        p.InsertPost(p);

        //Response.Write(txtContent.Text);
        //Response.End();
    }
}