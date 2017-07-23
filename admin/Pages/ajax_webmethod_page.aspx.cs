using MVCDatatableApp;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNet.Identity;
using Excel;
using System.Data;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Collections.Generic;

public partial class admin_Staff_ajax_webmethod_page : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}


    [WebMethod]
    public static void GetAll()
    {
        Model_Post p = new Model_Post { PostTypeID = 1 };
        IList<Model_Post> ret = p.GetPostListByPostType(p);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

}