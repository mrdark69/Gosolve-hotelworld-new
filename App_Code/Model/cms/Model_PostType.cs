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

public class Model_PostType : BaseModel<Model_PostType>
{
  
    public byte PostTypeID { get; set; }
    public string Title { get; set; }
 
    public string Slug { get; set; }

    public bool  Status { get; set; }

    public bool ShowComment { get; set; }
    public byte BannerTypeID { get; set; }
    public int ViewCount { get; set; }
    public bool ShowMasterSlider { get; set; }


    private Model_PostTypeSEOMap _posttypeSEOMap = null;
    public Model_PostTypeSEOMap PostTypeSEOMap
    {
        get
        {
            if (_posttypeSEOMap == null)
            {
                Model_PostTypeSEOMap seo = new Model_PostTypeSEOMap();
                _posttypeSEOMap = seo.GetSEOID(this.PostTypeID);
            }
            return _posttypeSEOMap;
        }
    }

    private Model_PostSeo _posttypeSEO = null;
    public Model_PostSeo PosTypetSEO
    {
        get
        {
            if (_posttypeSEO == null && this.PostTypeSEOMap != null)
            {
                Model_PostSeo ps = new Model_PostSeo();
                _posttypeSEO = ps.GetPostSeoByID(this.PostTypeSEOMap.PSID);
            }

            return _posttypeSEO;
        }
    }

    private List<Model_PostTypeMedia> _posttypemedia = null;
    public List<Model_PostTypeMedia> PostTypeMedia
    {
        get
        {
            if (_posttypemedia == null)
            {
                Model_PostTypeMedia ps = new Model_PostTypeMedia();
                _posttypemedia = ps.getPostTypeMediaByPostTypeID(this.PostTypeID);
            }

            return _posttypemedia;
        }
    }

    public Model_PostType()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public List<Model_PostType> GetPostTypeAll()
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostType WHERE Status =1 ", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
   
    public Model_PostType GetPostTypeByID(byte PostTypeID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostType WHERE   PostTypeID=@PostTypeID ", cn);
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = PostTypeID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
            
        }
    }


    public bool UPDATETrash(int inPostID, bool trash)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE POST SET Trash=@Trash WHERE PostID=@PostID", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = inPostID;

            cmd.Parameters.Add("@Trash", SqlDbType.Bit).Value = trash;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }


    public bool UpdatePostType(Model_PostType p)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE PostType SET Title=@Title,ShowComment=@ShowComment,BannerTypeID=@BannerTypeID,ShowMasterSlider=@ShowMasterSlider
                ,ViewCount=@ViewCount
            WHERE PostTypeID=@PostTypeID", cn);


            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = p.Title;
            //cmd.Parameters.Add("@Short", SqlDbType.NVarChar).Value = p.Short;
           // cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = p.Slug;
            //cmd.Parameters.Add("DateSubmit", SqlDbType.SmallDateTime).Value = p.DateSubmit;
            //cmd.Parameters.Add("UserID", SqlDbType.Int).Value = p.UserID;
            //cmd.Parameters.Add("DatePublish", SqlDbType.SmallDateTime).Value = p.DatePublish;
            //cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = p.Status;
            cmd.Parameters.Add("@ShowComment", SqlDbType.Bit).Value = p.ShowComment;
            cmd.Parameters.Add("@BannerTypeID", SqlDbType.TinyInt).Value = p.BannerTypeID;
            cmd.Parameters.Add("@ShowMasterSlider", SqlDbType.Int).Value = p.ShowMasterSlider;
            //cmd.Parameters.Add("@BodyContent", SqlDbType.NVarChar).Value = p.BodyContent;
            cmd.Parameters.Add("@ViewCount", SqlDbType.Int).Value = p.ViewCount;
            //cmd.Parameters.Add("@BodyContentBuilder", SqlDbType.NVarChar).Value = p.BodyContentBuilder;
            cmd.Parameters.Add("@PostTypeID", SqlDbType.Int).Value = p.PostTypeID;


            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }

    }




    //Binding to Front
    public Model_PostType GetPostTypeBySlug(string slug)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostType WHERE   Slug=@Slug ", cn);
            cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = slug;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;

        }
    }




}

public class Model_PostTypeSEOMap : BaseModel<Model_PostTypeSEOMap>
{
    public byte PostTypeID { get; set; }
    public int PSID { get; set; }


    public Model_PostTypeSEOMap GetSEOID(int PostTypeID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostTypeSEOMap WHERE PostTypeID=@PostTypeID", cn);
            cmd.Parameters.Add("@PostTypeID", SqlDbType.Int).Value = PostTypeID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public int InsertMApSeo(Model_PostTypeSEOMap seomap)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PostTypeSEOMap (PostTypeID,PSID) VALUES(@PostTypeID,@PSID)", cn);
            cmd.Parameters.Add("@PostTypeID", SqlDbType.Int).Value = seomap.PostTypeID;
            cmd.Parameters.Add("@PSID", SqlDbType.Int).Value = seomap.PSID;
            cn.Open();
            return ExecuteNonQuery(cmd);
        }
    }
}