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

   
    

  

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string MID = Request.Form["menu_checked"];

        if (!string.IsNullOrEmpty(MID))
        {
            Model_Menu m = new Model_Menu();
            string[] arrArg = MID.Split(',');

            foreach(string ar in arrArg)
            {
                string Url = Request.Form["custom_url_" + ar];
                string Title = Request.Form["label_" + ar];
                string TitleTag = Request.Form["TagTitle_" + ar];

                string[] d = ar.Split('_');

                int intMID = int.Parse(d[0]);
                byte bytCat = byte.Parse(d[1]);

                m.Title = Title;
                m.TitleTag = TitleTag;
                m.MID = intMID;
                m.CustomUrl =  (string.IsNullOrEmpty(Url)?string.Empty: Url) ;

                m.Update(m);

            }

            
        }


        Response.Redirect(Request.Url.ToString());
        Response.End();
    }
}