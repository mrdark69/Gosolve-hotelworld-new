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

public class Model_Menu : BaseModel<Model_Menu>
{
  
    public byte PostTypeID { get; set; }
    public string Title { get; set; }
 
    public string Slug { get; set; }

    public bool  Status { get; set; }

   
    

    public Model_Menu()
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
   

}