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
            Model_Group cMeg = new Model_Group();
            MenuIItem.DataSource = cMeg.GetMenuGroupAll();
            MenuIItem.DataValueField = "MGID";
            MenuIItem.DataTextField = "Title";
            MenuIItem.DataBind();


            int MID = int.Parse(MenuIItem.SelectedValue);
            if (string.IsNullOrEmpty(Request.QueryString["menu"]))
            {
                MID = int.Parse(MenuIItem.SelectedValue);
            }
            else
            {
                MID = int.Parse(Request.QueryString["menu"]);
                MenuIItem.SelectedValue = Request.QueryString["menu"];
            }

            cMeg = cMeg.GetMenuGroupByID(MID);


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

    
   
    protected void btndropSel_Click(object sender, EventArgs e)
    {

        Response.Redirect("Menu?menu=" + MenuIItem.SelectedValue);
        Response.End();
        //Model_Group cMeg = new Model_Group();
        //cMeg = cMeg.GetMenuGroupByID(int.Parse(MenuIItem.SelectedValue));

        //TxtMenuName.Text = cMeg.Title;
        
    }
}