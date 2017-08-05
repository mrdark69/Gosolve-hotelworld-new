using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _Menu : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {


            //lefpant.Text = GenMenuLeftPan();


            MenuList.Text = GenMenuList();

        }
    }

   
    public string GenMenuLeftPan()
    {
        StringBuilder ret = new StringBuilder();

        Model_PostType cPostType = new Model_PostType();

        Model_Post cPost = new Model_Post();
        Model_PostTaxonomy cTax = new Model_PostTaxonomy();
        List<Model_PostType> posttpyList = cPostType.GetPostTypeAll();

        foreach(Model_PostType mm in posttpyList.Where(p=>p.PostTypeID != 4))
        {
            ret.Append("<div class=\"ibox float-e-margins border-bottom\" style=\"margin-bottom:0px;\">");
            ret.Append("<div class=\"ibox-title\">");
            ret.Append("<h5>"+ mm.Title+" </h5>");
            ret.Append("<div class=\"ibox-tools\">");
            ret.Append("<a class=\"collapse-link\">");
            ret.Append("<i class=\"fa fa-chevron-down\"></i>");
            ret.Append("</a>");
            ret.Append("</div>");
            ret.Append("</div>");
            ret.Append("<div class=\"ibox-content\" style=\"display: none;\">");
            if(mm.PostTypeID != 1)
            {
                ret.Append("<p><input type=\"checkbox\"  /> All</p>");
            }
           
            List<Model_Post> cPostlist = cPost.GetPostListByPostType(mm.PostTypeID);
            foreach(Model_Post p in cPostlist)
            {
                ret.Append("<p><input type=\"checkbox\"  /> " + p.Title + "</p>");
            }
            //type=\"submit\
            ret.Append("<a>Select all</a>");
            ret.Append("<button  class=\"btn btn-sm\" style=\"float:right\">Add to Menu</button>");

            ret.Append("</div>");
            ret.Append("</div>");

        }


        List<Model_PostTaxonomy> cTaxList = null;

        ret.Append("<div class=\"ibox float-e-margins border-bottom\" style=\"margin-bottom:0px;\">");
        ret.Append("<div class=\"ibox-title\">");
        ret.Append("<h5>Product Categories</h5>");
        ret.Append("<div class=\"ibox-tools\">");
        ret.Append("<a class=\"collapse-link\">");
        ret.Append("<i class=\"fa fa-chevron-down\"></i>");
        ret.Append("</a>");
        ret.Append("</div>");
        ret.Append("</div>");
        ret.Append("<div class=\"ibox-content\" style=\"display: none;\">");
 

        //ret.Append("<p><input type=\"checkbox\"  /> All</p>");
        cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(3, 1);
        foreach (Model_PostTaxonomy p in cTaxList)
        {
            ret.Append("<p><input type=\"checkbox\"  /> " + p.Title + "</p>");
        }

        ret.Append("<a>Select all</a>");
        ret.Append("<button class=\"btn btn-sm\" style=\"float:right\">Add to Menu</button>");

        ret.Append("</div>");
        ret.Append("</div>");

        ret.Append("<div class=\"ibox float-e-margins border-bottom\" style=\"margin-bottom:0px;\">");
        ret.Append("<div class=\"ibox-title\">");
        ret.Append("<h5>Product Tags </h5>");
        ret.Append("<div class=\"ibox-tools\">");
        ret.Append("<a class=\"collapse-link\">");
        ret.Append("<i class=\"fa fa-chevron-down\"></i>");
        ret.Append("</a>");
        ret.Append("</div>");
        ret.Append("</div>");
        ret.Append("<div class=\"ibox-content\" style=\"display: none;\">");

        //ret.Append("<p><input type=\"checkbox\"  /> All</p>");
        cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(3, 2);
        foreach (Model_PostTaxonomy p in cTaxList)
        {
            ret.Append("<p><input type=\"checkbox\"  /> " + p.Title + "</p>");
        }

        ret.Append("<a>Select all</a>");
        ret.Append("<button class=\"btn btn-sm\" style=\"float:right\">Add to Menu</button>");

        ret.Append("</div>");
        ret.Append("</div>");

        ret.Append("<div class=\"ibox float-e-margins border-bottom\" style=\"margin-bottom:0px;\">");
        ret.Append("<div class=\"ibox-title\">");
        ret.Append("<h5>Blog Categories</h5>");
        ret.Append("<div class=\"ibox-tools\">");
        ret.Append("<a class=\"collapse-link\">");
        ret.Append("<i class=\"fa fa-chevron-down\"></i>");
        ret.Append("</a>");
        ret.Append("</div>");
        ret.Append("</div>");
        ret.Append("<div class=\"ibox-content\" style=\"display: none;\">");
        //ret.Append("<p><input type=\"checkbox\"  /> All</p>");
        cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(2, 1);
        foreach (Model_PostTaxonomy p in cTaxList)
        {
            ret.Append("<p><input type=\"checkbox\"  /> " + p.Title + "</p>");
        }

        ret.Append("<a>Select all</a>");
        ret.Append("<button class=\"btn btn-sm\" style=\"float:right\">Add to Menu</button>");

        ret.Append("</div>");
        ret.Append("</div>");


        ret.Append("<div class=\"ibox float-e-margins border-bottom\" style=\"margin-bottom:0px;\">");
        ret.Append("<div class=\"ibox-title\">");
        ret.Append("<h5>Blog Tags</h5>");
        ret.Append("<div class=\"ibox-tools\">");
        ret.Append("<a class=\"collapse-link\">");
        ret.Append("<i class=\"fa fa-chevron-down\"></i>");
        ret.Append("</a>");
        ret.Append("</div>");
        ret.Append("</div>");
        ret.Append("<div class=\"ibox-content\" style=\"display: none;\">");
        //ret.Append("<p><input type=\"checkbox\"  /> All</p>");
        cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(2, 2);
        foreach (Model_PostTaxonomy p in cTaxList)
        {
            ret.Append("<p><input type=\"checkbox\"  /> " + p.Title + "</p>");
        }

        ret.Append("<a>Select all</a>");
        ret.Append("<button class=\"btn btn-sm\" style=\"float:right\">Add to Menu</button>");
        ret.Append("</div>");
        ret.Append("</div>");



        ret.Append("<div class=\"ibox float-e-margins border-bottom\" style=\"margin-bottom:0px;\">");
        ret.Append("<div class=\"ibox-title\">");
        ret.Append("<h5>Custom Link </h5>");
        ret.Append("<div class=\"ibox-tools\">");
        ret.Append("<a class=\"collapse-link\">");
        ret.Append("<i class=\"fa fa-chevron-down\"></i>");
        ret.Append("</a>");
        ret.Append("</div>");
        ret.Append("</div>");
        ret.Append("<div class=\"ibox-content\" style=\"display: none;\">");





        ret.Append("<div  class=\"form-horizontal\">");

        ret.Append("<div class=\"form-group\"  ><label class=\"col-sm-2 control-label\">Url</label>");
        ret.Append("<div class=\"col-sm-10\"> ");

        ret.Append("<input type=\"text\" class=\"form-control\" />");
        ret.Append("</div>");

        ret.Append(" </div>");
        ret.Append("<div class=\"hr-line-dashed\"></div>");
        ret.Append("<div class=\"form-group\"  ><label class=\"col-sm-2 control-label\">Link Text</label>");
        ret.Append("<div class=\"col-sm-10\"> ");
        ret.Append("<input type=\"text\" class=\"form-control\" />");
        ret.Append("</div>");

        ret.Append("</div>");
        ret.Append("</div>");


        ret.Append("</div>");
        ret.Append("</div>");


        return ret.ToString();
    }


    public string GenMenuList()
    {
        StringBuilder ret = new StringBuilder();


        return ret.ToString();
    }

    protected void cmdAction_Click(object sender, EventArgs e)
    {
        Response.Write("ss");
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        Response.Write("ss");
    }
}