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

public enum PostMediaType : byte
{
    CoverImage = 1,
    FeatureImage = 2,
   
}
public class Model_PostMedia : BaseModel<Model_PostMedia>
{
    public int PostMediaID { get; set; }

    public PostMediaType PostMediaTypeID { get; set; }
    public int PostID { get; set; }
    public int MID { get; set; }


    public string Title { get; set; }
    public string Alt { get; set; }
    public string Path { get; set; }
    public string FileName { get; set; }
    public string MediaFullPath
    {
        get
        {
            return this.Path + this.FileName;
        }
    }
    public Model_PostMedia()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int insertMediaPost(Model_PostMedia mp)
    {
       using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmddel = new SqlCommand(@"DELETE FROM PostMedia WHERE PostMediaTypeID=@PostMediaTypeID AND 
        PostID=@PostID AND MID=@MID", cn);
            cn.Open();

            cmddel.Parameters.Add("@PostMediaTypeID", SqlDbType.TinyInt).Value = mp.PostMediaTypeID;
            cmddel.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = mp.PostID;
            cmddel.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;

            ExecuteNonQuery(cmddel);

            SqlCommand cmd = new SqlCommand(@"INSERT INTO PostMedia (PostMediaTypeID,PostID,MID) VALUES(@PostMediaTypeID,@PostID,@MID) ", cn);
            cmd.Parameters.Add("@PostMediaTypeID", SqlDbType.TinyInt).Value = mp.PostMediaTypeID;
            cmd.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = mp.PostID;
            cmd.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;

           
            return ExecuteNonQuery(cmd);
          
        }
    }
    public bool DeletePostMedia(Model_PostMedia mp)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmddel = new SqlCommand(@"DELETE FROM PostMedia WHERE PostMediaTypeID=@PostMediaTypeID AND 
        PostID=@PostID ", cn);
            cn.Open();

            cmddel.Parameters.Add("@PostMediaTypeID", SqlDbType.TinyInt).Value = mp.PostMediaTypeID;
            cmddel.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = mp.PostID;



            


            return ExecuteNonQuery(cmddel) == 1;

        }
    }

    public List<Model_PostMedia> getPostMedia(int PostID, byte PostMediaTypeID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT pm.*,m.Title,m.Alt,m.Path,m.FileName FROM PostMedia pm INNER JOIN Media m ON m.MID=pm.MID WHERE PostID=@PostID AND PostMediaTypeID=@PostMediaTypeID", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = PostID;
            cmd.Parameters.Add("@PostMediaTypeID", SqlDbType.TinyInt).Value = PostMediaTypeID;
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

    public List<Model_PostMedia> getPostMediaByPostID(int PostID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT pm.*,m.Title,m.Alt,m.Path,m.FileName FROM PostMedia pm 
        INNER JOIN Media m ON m.MID=pm.MID WHERE  PostID=@PostID", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = PostID;
          
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

}