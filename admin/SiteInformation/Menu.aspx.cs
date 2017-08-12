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



    public string getCatProduct(List<Model_PostTaxonomy> Taxlist)
    {
        StringBuilder ret = new StringBuilder();


        ret.Append("<div class='tax_parent' style='max-height:300px;overflow:scroll;'>");

        List<Model_PostTaxonomy> Taxlistdrop = new List<Model_PostTaxonomy>();



        foreach (Model_PostTaxonomy i in Taxlist.Where(g => g.RefID == 0).OrderBy(o => o.Priority))
        {
            //ret.Append("<input type='checkbox' value='"+i.TaxID+"' name='product_tax_cat' />");
            ret.Append("<p class='parent_main_item'><i class=\"fa fa-star\"></i> " + i.Title + "</p>");

            if (Taxlist.Where(f => f.RefID == i.TaxID).Count() > 0)
            {
                
                ret.Append("<div class='tax_child' style='margin-left:15px;'>");
                ret.Append(getchild(Taxlist.Where(f => f.RefID == i.TaxID).ToList(), Taxlist, i.TaxID));
                ret.Append("</div>");
            }

        }


        ret.Append("</div>");
        return ret.ToString();
    }


    public string getchild(List<Model_PostTaxonomy> data, List<Model_PostTaxonomy> raw, int id)
    {
        StringBuilder ret = new StringBuilder();
        List<Model_PostTaxonomy> retdataret = new List<Model_PostTaxonomy>();
        foreach (Model_PostTaxonomy c in data)
        {
            ////name="TaxID_<% Response.Write(p.PostTypeID); %>_<% Response.Write(p.TaxTypeID); %>" 
            ret.Append("<p class='child_item' style='position:relative;'><input type='checkbox'  value='" + c.TaxID + "' name='TaxID_"+c.PostTypeID+"_"+c.TaxTypeID+"' />");
            ret.Append(c.Title + "</p>");
            if (raw.Where(f => f.RefID == c.TaxID).Count() > 0)
            {
                ret.Append("<div class='tax_child'  style='position:relative;margin-left:15px;'>");
                ret.Append(getchild(raw.Where(f => f.RefID == c.TaxID).ToList(), raw, c.TaxID));
               ret.Append("</div>");
            }
        }
        return ret.ToString();
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