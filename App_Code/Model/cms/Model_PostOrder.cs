using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;
using gs_newsletter;
using System.Web.Providers.Entities;

/// <summary>
/// Summary description for Model_SiteInfo
/// </summary>
/// 
public class Model_PostOrderItem : BaseModel<Model_PostOrderItem>
{
    public int OrderItem { get; set; }
    public int OrderID { get; set; }
    public int PostID { get; set; }
    public decimal Price { get; set; }
    public int UnitFrom { get; set; }
    public int? UnitTo { get; set; }

    public string Title { get; set; }
    public bool Status { get; set; }
}


public class Model_PostOrder : BaseModel<Model_PostOrder>
{
    public int OrderID { get; set; }
    public string SessionID { get; set; }
    public string Channel { get; set; }
    public string OS { get; set; }
    public string Device { get; set; }


    public bool  Status { get; set; }

   
    

    public Model_PostOrder()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //public List<Model_PostType> GetPostTypeAll()
    //{
    //    using(SqlConnection cn = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand cmd = new SqlCommand("SELECT * FROM PostType WHERE Status =1 ", cn);
    //        cn.Open();
    //        return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
    //    }
    //}
   
    //public Model_PostType GetPostTypeByID(byte PostTypeID)
    //{
    //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand cmd = new SqlCommand("SELECT * FROM PostType WHERE   PostTypeID=@PostTypeID ", cn);
    //        cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = PostTypeID;
    //        cn.Open();
    //        IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
    //        if (reader.Read())
    //            return MappingObjectFromDataReaderByName(reader);
    //        else
    //            return null;
            
    //    }
    //}

    ////Binding to Front
    //public Model_PostType GetPostTypeBySlug(string slug)
    //{
    //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand cmd = new SqlCommand("SELECT * FROM PostType WHERE   Slug=@Slug ", cn);
    //        cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = slug;
    //        cn.Open();
    //        IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
    //        if (reader.Read())
    //            return MappingObjectFromDataReaderByName(reader);
    //        else
    //            return null;

    //    }
    //}


}