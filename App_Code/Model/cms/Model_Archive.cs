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
public class Model_Archive : BaseModel<Model_Archive>
{
    public byte ArchiveID { get; set; }
    public byte PostTypeID { get; set; }
    public string Slug { get; set; }

    public string PostTypeSlug { get; set; }


    public Model_Archive GetPostArchive(string Slug)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT ar.*,pt.Slug AS PostTypeSlug FROM ArchiveMap ar INNER JOIN PostType pt ON pt.PostTypeID = ar.PostTypeID WHERE pt.Slug =@Slug OR ar.Slug =@Slug ", cn);
            cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = Slug;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

}

