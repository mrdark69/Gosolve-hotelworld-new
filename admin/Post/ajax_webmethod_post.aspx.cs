﻿using MVCDatatableApp;
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

public partial class admin_Staff_ajax_webmethod_post : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}


    [WebMethod]
    public static void GetAll(Model_Post parameters)
    {
        //Model_Post p = new Model_Post { PostTypeID = 1 };
        IList<Model_Post> ret = parameters.GetPostListByPostType(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetTaxMain(Model_PostTaxonomy parameters)
    {
        //Model_Post p = new Model_Post { PostTypeID = 1 };
        List<Model_PostTaxonomy> ret = parameters.GetTaxonomyByIDMain(parameters);


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void GetPostype(Model_PostType parameters)
    {
        //Model_Post p = new Model_Post { PostTypeID = 1 };
        List<Model_PostType> ret = parameters.GetPostTypeAll();


        AppTools.SendResponse(HttpContext.Current.Response, ret.ObjectToJSON());
    }

    [WebMethod]
    public static void UpdateSortMenu(dynamic parameters)
    {





        bool ret = CmsController.UpdateSortMenu(parameters);

        bool success = false;
        string msg = "no";

        if (ret)
        {
            success = true;
            msg = "Insert Completed";
        }


        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);
    }

    [WebMethod]
    public static void AddMenu(dynamic parameters)
    {

       
        


        bool ret = CmsController.InsertMenu(parameters);

        bool success = false;
        string msg = "no";

        if (ret)
        {
            success = true;
            msg = "Insert Completed";
        }


        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);
    }
    [WebMethod]
    public static void DeleteMenu(dynamic parameters)
    {





        bool ret = CmsController.DeleteMenu(parameters);

        bool success = false;
        string msg = "no";

        if (ret)
        {
            success = true;
            msg = "Insert Completed";
        }


        string res = (new BaseWebMethodAJax
        {
            success = success,
            msg = msg

        }).ObjectToJSON();

        AppTools.SendResponse(HttpContext.Current.Response, res);
    }
}