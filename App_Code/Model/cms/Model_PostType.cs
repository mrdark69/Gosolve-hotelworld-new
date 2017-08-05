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

}