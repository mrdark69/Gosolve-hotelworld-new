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
public class Model_PostSEOMap : BaseModel<Model_PostSEOMap>
{
    public int PostID { get; set; }
    public int PSID { get; set; }


    public Model_PostSEOMap GetSEOID(int PostID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostSEOMap WHERE PostID=@PostID", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    
    public int InsertMApSeo(Model_PostSEOMap seomap)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PostSEOMap (PostID,PSID) VALUES(@PostID,@PSID)", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = seomap.PostID;
            cmd.Parameters.Add("@PSID", SqlDbType.Int).Value = seomap.PSID;
            cn.Open();
            return ExecuteNonQuery(cmd);
        }
    }
}

public class Model_Post : BaseModel<Model_Post>
{
    public int PostID { get; set; }
    public byte PostTypeID { get; set; }
    public string Title { get; set; }
    public string Short { get; set; }
    public string Slug { get; set; }
    public DateTime DateSubmit { get; set; }
    public int UserID { get; set; }
    public DateTime DatePublish { get; set; }
    public bool Status { get; set; }
    public bool ShowComment { get; set; }

    public string BodyContent { get; set; }
    public string BodyContentBuilder { get; set; }
    public byte BannerTypeID { get; set; }

    public bool ShowMasterSlider { get; set; }

    public int ViewCount { get; set; }

    public bool Trash { get; set; }

    public string DatePublishFormat
    {
        get
        {
            return this.DatePublish.ToThaiDateTime().ToString("dd MMM yyy HH:mm tt");
        }
    }

    public string UserFirstName { get; set; }


    private Model_PostSEOMap _postSEOMap = null;
    public Model_PostSEOMap PostSEOMap
    {
        get
        {
            if(_postSEOMap == null)
            {
                Model_PostSEOMap seo = new Model_PostSEOMap();
                _postSEOMap = seo.GetSEOID(this.PostID);
            }
            return _postSEOMap;
        }
    }

    private Model_PostSeo _postSEO = null;
    public Model_PostSeo PostSEO
    {
        get
        {
            if (_postSEO == null && this.PostSEOMap != null)
            {
                Model_PostSeo ps = new Model_PostSeo();
                _postSEO = ps.GetPostSeoByID(this.PostSEOMap.PSID);
            }

            return _postSEO;
        }
    }

    private List<Model_PostMedia> _postmedia = null;
    public List<Model_PostMedia> PostMedia
    {
        get
        {
            if (_postmedia == null)
            {
                Model_PostMedia ps = new Model_PostMedia();
                _postmedia = ps.getPostMediaByPostID(this.PostID);
            }

            return _postmedia;
        }
    }


    public Model_Post()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public List<Model_Post> GetPostArchiveByPostType(byte PostTypeID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT p.*,u.FirstName AS UserFirstName FROM POST p INNER JOIN Users u ON u.UserID=p.UserID WHERE  PostTypeID=@PostTypeID AND Status = 1 ORDER BY DatePublish ASC", cn);
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = PostTypeID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public List<Model_Post> GetPostListByPostType(Model_Post p)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT p.*,u.FirstName AS UserFirstName FROM POST p INNER JOIN Users u ON u.UserID=p.UserID WHERE PostTypeID=@PostTypeID ORDER BY DateSubmit ASC, DatePublish ASC", cn);
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = p.PostTypeID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public List<Model_Post> GetPostListByPostType(byte PostTypeID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT p.*,u.FirstName AS UserFirstName FROM POST p INNER JOIN Users u ON u.UserID=p.UserID WHERE PostTypeID=@PostTypeID ORDER BY DateSubmit ASC, DatePublish ASC", cn);
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = PostTypeID; ;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_Post GetPostByID(int PostID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM  POST WHERE PostID=@PostID AND Status = 1", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
           
        }
    }
   
    public Model_Post GetPostBySlug(string Slug)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM  POST WHERE Slug=@Slug AND Status = 1", cn);
            cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = Slug;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;

        }
    }

    public bool UPDATETrash(int inPostID,bool trash)
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
    public int InsertPost(Model_Post p)
    {
        int ret = 0;
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO POST (PostTypeID,Title,Short,Slug,DateSubmit,UserID,DatePublish,Status,
                    ShowComment,BodyContent,BannerTypeID,ShowMasterSlider,ViewCount,BodyContentBuilder) 
                    VALUES (@PostTypeID,@Title,@Short,@Slug,@DateSubmit,@UserID,@DatePublish,@Status,
                    @ShowComment,@BodyContent,@BannerTypeID,@ShowMasterSlider,@ViewCount,@BodyContentBuilder) ;SET @PostID = SCOPE_IDENTITY();", cn);


            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = p.PostTypeID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = p.Title;
            cmd.Parameters.Add("@Short", SqlDbType.NVarChar).Value = p.Short;
            cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = p.Slug;
            cmd.Parameters.Add("@DateSubmit", SqlDbType.SmallDateTime).Value = p.DateSubmit;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = p.UserID;
            cmd.Parameters.Add("@DatePublish", SqlDbType.SmallDateTime).Value = p.DatePublish;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = p.Status;
            cmd.Parameters.Add("@ShowComment", SqlDbType.Bit).Value = p.ShowComment;
            cmd.Parameters.Add("@BannerTypeID", SqlDbType.TinyInt).Value = p.BannerTypeID;
            cmd.Parameters.Add("@ShowMasterSlider", SqlDbType.Int).Value = p.ShowMasterSlider;
            cmd.Parameters.Add("@BodyContent", SqlDbType.NVarChar).Value = p.BodyContent;
            cmd.Parameters.Add("@BodyContentBuilder", SqlDbType.NVarChar).Value = p.BodyContentBuilder;
            
            cmd.Parameters.Add("@ViewCount", SqlDbType.Int).Value = p.ViewCount;

            cmd.Parameters.Add("@PostID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@PostID"].Value;

            }

            
        }

        return ret;
    }

    public bool UpdatePost (Model_Post p)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE Post SET  Title=@Title, Short=@Short ,Slug=@Slug 
,Status=@Status,ShowComment=@ShowComment,BannerTypeID=@BannerTypeID,ShowMasterSlider=@ShowMasterSlider
,BodyContent=@BodyContent,ViewCount=@ViewCount,BodyContentBuilder=@BodyContentBuilder 
WHERE PostID=@PostID", cn);

           
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = p.Title;
            cmd.Parameters.Add("@Short", SqlDbType.NVarChar).Value = p.Short;
            cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = p.Slug;
            //cmd.Parameters.Add("DateSubmit", SqlDbType.SmallDateTime).Value = p.DateSubmit;
            //cmd.Parameters.Add("UserID", SqlDbType.Int).Value = p.UserID;
            //cmd.Parameters.Add("DatePublish", SqlDbType.SmallDateTime).Value = p.DatePublish;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = p.Status;
            cmd.Parameters.Add("@ShowComment", SqlDbType.Bit).Value = p.ShowComment;
            cmd.Parameters.Add("@BannerTypeID", SqlDbType.TinyInt).Value = p.BannerTypeID;
            cmd.Parameters.Add("@ShowMasterSlider", SqlDbType.Int).Value = p.ShowMasterSlider;
            cmd.Parameters.Add("@BodyContent", SqlDbType.NVarChar).Value = p.BodyContent;
            cmd.Parameters.Add("@ViewCount", SqlDbType.Int).Value = p.ViewCount;
            cmd.Parameters.Add("@BodyContentBuilder", SqlDbType.NVarChar).Value = p.BodyContentBuilder;
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = p.PostID;


            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
            
    }




}