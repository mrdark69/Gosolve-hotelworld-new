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

public class Model_PostSeo : BaseModel<Model_PostSeo>
{
    public int PSID { get; set; }

   // public int PostID { get; set; }
    public string SEOTitle { get; set; }
    public string MetaDescription { get; set; }
    public string CanonicalUrl { get; set; }
    public bool Metarobotsfollow { get; set; }
    public string FaceBookTitle { get; set; }
    public string FacebookDescription { get; set; }
    public string FacebookImage { get; set; }
    public string TwitterTitle { get; set; }

    public string TwitterDescription { get; set; }
    public string TwitterImages { get; set; }
    public string GoogleAnalytic { get; set; }
   


    public Model_PostSeo()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public Model_PostSeo GetPostSeoByPostID(int PostID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 se.* FROM PostSEOMap sm INNER JOIN PostSEO se ON se.PSID=sm.PSID WHERE sm.PostID=@PostID", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;
            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    
    public int InsertSEO_step1(Model_PostSeo seo)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmdinsert = new SqlCommand(@"INSERT INTO PostSEO (PostID,SEOTitle,MetaDescription,CanonicalUrl,Metarobotsfollow,FaceBookTitle,
FacebookDescription,FacebookImage,TwitterTitle,TwitterDescription,TwitterImages,GoogleAnalytic
) VALUES(@PostID,@SEOTitle,@MetaDescription,@CanonicalUrl,@Metarobotsfollow,@FaceBookTitle,
@FacebookDescription,@FacebookImage,@TwitterTitle,@TwitterDescription,@TwitterImages,@GoogleAnalytic);SET @PSID=SCOPE_IDENTITY(); ", cn);


            cmdinsert.Parameters.Add("@SEOTitle", SqlDbType.NVarChar).Value = seo.SEOTitle;
            cmdinsert.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = seo.MetaDescription;
            cmdinsert.Parameters.Add("@CanonicalUrl", SqlDbType.NVarChar).Value = seo.CanonicalUrl;
            cmdinsert.Parameters.Add("@Metarobotsfollow", SqlDbType.Bit).Value = seo.Metarobotsfollow;
            cmdinsert.Parameters.Add("@FaceBookTitle", SqlDbType.NVarChar).Value = seo.FaceBookTitle;
            cmdinsert.Parameters.Add("@FacebookDescription", SqlDbType.NVarChar).Value = seo.FacebookDescription;
            cmdinsert.Parameters.Add("@FacebookImage", SqlDbType.NVarChar).Value = seo.FacebookImage;
            cmdinsert.Parameters.Add("@TwitterTitle", SqlDbType.NVarChar).Value = seo.TwitterTitle;
            cmdinsert.Parameters.Add("@TwitterDescription", SqlDbType.NVarChar).Value = seo.TwitterDescription;
            cmdinsert.Parameters.Add("@TwitterImages", SqlDbType.NVarChar).Value = seo.TwitterImages;
            cmdinsert.Parameters.Add("@GoogleAnalytic", SqlDbType.NVarChar).Value = seo.GoogleAnalytic;


            cmdinsert.Parameters.Add("@PSID", SqlDbType.Int).Direction = ParameterDirection.Output;

            if (ExecuteNonQuery(cmdinsert) > 0)
            {
                ret = (int)cmdinsert.Parameters["@PSID"].Value;

            }
        }

        return ret;
    }

    public bool UpdateSEO(Model_PostSeo seo)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE PostSEO SET SEOTitle=@SEOTitle, MetaDescription=@MetaDescription, 
CanonicalUrl=@CanonicalUrl, Metarobotsfollow=@Metarobotsfollow, FaceBookTitle=@FaceBookTitle,FacebookDescription=@FacebookDescription,
FacebookImage=@FacebookImage ,TwitterTitle=@TwitterTitle, TwitterDescription=@TwitterDescription,TwitterImages=@TwitterImages,GoogleAnalytic=@GoogleAnalytic  WHERE PSID=@PSID ", cn);

            cn.Open();
            cmd.Parameters.Add("@PSID", SqlDbType.Int).Value = seo.PSID;
            cmd.Parameters.Add("@SEOTitle", SqlDbType.NVarChar).Value = seo.SEOTitle;
            cmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = seo.MetaDescription;
            cmd.Parameters.Add("@CanonicalUrl", SqlDbType.NVarChar).Value = seo.CanonicalUrl;
            cmd.Parameters.Add("@Metarobotsfollow", SqlDbType.Bit).Value = seo.Metarobotsfollow;
            cmd.Parameters.Add("@FaceBookTitle", SqlDbType.NVarChar).Value = seo.FaceBookTitle;
            cmd.Parameters.Add("@FacebookDescription", SqlDbType.NVarChar).Value = seo.FacebookDescription;
            cmd.Parameters.Add("@FacebookImage", SqlDbType.NVarChar).Value = seo.FacebookImage;
            cmd.Parameters.Add("@TwitterTitle", SqlDbType.NVarChar).Value = seo.TwitterTitle;
            cmd.Parameters.Add("@TwitterDescription", SqlDbType.NVarChar).Value = seo.TwitterDescription;
            cmd.Parameters.Add("@TwitterImages", SqlDbType.NVarChar).Value = seo.TwitterImages;
            cmd.Parameters.Add("@GoogleAnalytic", SqlDbType.NVarChar).Value = seo.GoogleAnalytic;
            return ExecuteNonQuery(cmd) == 1;
        }
     }

    public int InsertSEO(Model_PostSeo seo)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE PostSEO SET SEOTitle=@SEOTitle, MetaDescription=@MetaDescription, 
CanonicalUrl=@CanonicalUrl, Metarobotsfollow=@Metarobotsfollow, FaceBookTitle=@FaceBookTitle,FacebookDescription=@FacebookDescription,
FacebookImage=@FacebookImage ,TwitterTitle=@TwitterTitle, TwitterDescription=@TwitterDescription,TwitterImages=@TwitterImages,GoogleAnalytic=@GoogleAnalytic  WHERE PSID=@PSID ", cn);

            cn.Open();
            cmd.Parameters.Add("@PSID", SqlDbType.Int).Value = seo.PSID;
            cmd.Parameters.Add("@SEOTitle", SqlDbType.NVarChar).Value = seo.SEOTitle;
            cmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = seo.MetaDescription;
            cmd.Parameters.Add("@CanonicalUrl", SqlDbType.NVarChar).Value = seo.CanonicalUrl;
            cmd.Parameters.Add("@Metarobotsfollow", SqlDbType.Bit).Value = seo.Metarobotsfollow;
            cmd.Parameters.Add("@FaceBookTitle", SqlDbType.NVarChar).Value = seo.FaceBookTitle;
            cmd.Parameters.Add("@FacebookDescription", SqlDbType.NVarChar).Value = seo.FacebookDescription;
            cmd.Parameters.Add("@FacebookImage", SqlDbType.NVarChar).Value = seo.FacebookImage;
            cmd.Parameters.Add("@TwitterTitle", SqlDbType.NVarChar).Value = seo.TwitterTitle;
            cmd.Parameters.Add("@TwitterDescription", SqlDbType.NVarChar).Value = seo.TwitterDescription;
            cmd.Parameters.Add("@TwitterImages", SqlDbType.NVarChar).Value = seo.TwitterImages;
            cmd.Parameters.Add("@GoogleAnalytic", SqlDbType.NVarChar).Value = seo.GoogleAnalytic;
            ret = ExecuteNonQuery(cmd);
            if ( ret== 0)
            {

                SqlCommand cmdinsert = new SqlCommand(@"INSERT INTO PostSEO (SEOTitle,MetaDescription,CanonicalUrl,Metarobotsfollow,FaceBookTitle,
FacebookDescription,FacebookImage,TwitterTitle,TwitterDescription,TwitterImages,GoogleAnalytic
) VALUES(@SEOTitle,@MetaDescription,@CanonicalUrl,@Metarobotsfollow,@FaceBookTitle,
@FacebookDescription,@FacebookImage,@TwitterTitle,@TwitterDescription,@TwitterImages,@GoogleAnalytic);SET @PSID=SCOPE_IDENTITY(); ", cn);

              
                cmdinsert.Parameters.Add("@SEOTitle", SqlDbType.NVarChar).Value = seo.SEOTitle;
                cmdinsert.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = seo.MetaDescription;
                cmdinsert.Parameters.Add("@CanonicalUrl", SqlDbType.NVarChar).Value = seo.CanonicalUrl;
                cmdinsert.Parameters.Add("@Metarobotsfollow", SqlDbType.Bit).Value = seo.Metarobotsfollow;
                cmdinsert.Parameters.Add("@FaceBookTitle", SqlDbType.NVarChar).Value = seo.FaceBookTitle;
                cmdinsert.Parameters.Add("@FacebookDescription", SqlDbType.NVarChar).Value = seo.FacebookDescription;
                cmdinsert.Parameters.Add("@FacebookImage", SqlDbType.NVarChar).Value = seo.FacebookImage;
                cmdinsert.Parameters.Add("@TwitterTitle", SqlDbType.NVarChar).Value = seo.TwitterTitle;
                cmdinsert.Parameters.Add("@TwitterDescription", SqlDbType.NVarChar).Value = seo.TwitterDescription;
                cmdinsert.Parameters.Add("@TwitterImages", SqlDbType.NVarChar).Value = seo.TwitterImages;
                cmdinsert.Parameters.Add("@GoogleAnalytic", SqlDbType.NVarChar).Value = seo.GoogleAnalytic;


                cmdinsert.Parameters.Add("@PSID", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (ExecuteNonQuery(cmdinsert) > 0)
                {
                    ret = (int)cmd.Parameters["@PSID"].Value;

                }

               

            }
        }

        return ret;
    }

}