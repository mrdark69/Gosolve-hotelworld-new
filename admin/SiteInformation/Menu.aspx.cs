using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _Menu : Page
{
    public int ArgProp { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {


            //Button dd = this.Master.FindControl("MainContent").FindControl("1") as Button;
            //dd.Enabled = false;
            //dd.Click += new EventHandler(btn_Click);


            //but dd = this.Master.FindControl("MainContent").Controls;
            //int count = 1;
            //foreach (Control ss in dd)
            //{
            //    if (ss.GetType().Name == "Button" && ss.ID == "btn")
            //    {
            //        //Button tblForm = ss as Button;
            //        ((Button)ss).CommandArgument = count.ToString();
            //        count = count + 1;
            //    }

            //    // Response.Write(ss.GetType().Name);
            //}

            Model_Group cMeg = new Model_Group();
            MenuIItem.DataSource = cMeg.GetMenuGroupAll();
            MenuIItem.DataValueField = "MGID";
            MenuIItem.DataTextField = "Title";
            MenuIItem.DataBind();

            cMeg = cMeg.GetMenuGroupByID(int.Parse(MenuIItem.SelectedValue));

            TxtMenuName.Text = cMeg.Title;
        }
    }

   
    

    protected void btn_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        string cmdAr = btn.CommandArgument;


        Response.Write(cmdAr);
        Response.End();

        switch (btn.CommandName)
        {
            case "menu_post":

               
                string PostType = Request.Form["postType"];
                if (!string.IsNullOrEmpty(PostType))
                {
                    string[] arrPostType = PostType.Split(',');

                    //foreach()
                }
                string PostID_Archive_ = Request.Form["PostID_Archive_" + PostType];
                string PostID_ = Request.Form["PostID_" + PostType];

                Response.Write(cmdAr);
                Response.End();

                break;
        }
        
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string dd = Request.Form["Nest_ret"];
    }
}