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
public enum CustomGroup : int
{
    HomeGroup = 4,
    ProductGroup = 5


}

public enum HOMECustom_PostID_1 : int
{
    banner_announce = 1,
    banner_announce_right = 2,
    banner_client = 3
  
}
public enum ProductCustom_PostTypID_1 : int
{
    product_detail = 1,
    product_information =2,
    product_b_announce =3,
    product_b_rigth=4

}


public class Model_PostCustomGroup : BaseModel<Model_PostCustomGroup>
{
    public int PostID { get; set; }
    public int PCDID { get; set; }
    public string PcGroupName { get; set; }
    private List<Model_PostCustomItem> _customItem = null;
    public List<Model_PostCustomItem> CustomItem {
        get
        {
            if(this._customItem == null)
            {
                Model_PostCustomItem c = new Model_PostCustomItem();
                _customItem = c.GetItemCustomByGRoupID(this.PCDID,this.PostID);
            }
            return _customItem;
        }
    }

    public List<Model_PostCustomGroup> getCustomByPostID(int PostID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"
                        SELECT p.PCDID, pc.PcGroupName,  ISNULL(pt.PostID,p.PostID) AS PostID FROM PostCustomeMap p
                        INNER JOIN PostCustomData pc ON pc.PCDID = p.PCDID
                        LEFT JOIN Post pt ON pt.PostTypeID=p.PostTypeID 
                        WHERE p.PostID =@PostID OR  pt.PostID= @PostID
                        GROUP BY p.PCDID,pc.PcGroupName,ISNULL(pt.PostID,p.PostID)", cn);

            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
}
//banner-announce
//banner-announce-right
//banner-client

//SELECT* FROM PostCustomData
//SELECT* FROM PostCustomeMap
//SELECT* FROM PostCustomItem
//HomeGroup


//SELECT p.PCDID FROM PostCustomeMap p
//LEFT JOIN Post pt ON pt.PostTypeID= p.PostTypeID
//WHERE p.PostID = 1 OR pt.PostID= 1
//GROUP BY p.PCDID



public class Model_PostCustomItem : BaseModel<Model_PostCustomItem>
{
    public int PCIID { get; set; }
    public int PostID { get; set; }
    public int PCDID { get; set; }
    public string PcGroupName { get; set; }
    public string PcName { get; set; }
    public int? MID { get; set; }
    public string Slug { get; set; }
    public string Caption1 { get; set; }
    public string Caption2 { get; set; }
    public string URL { get; set; }
    public string ContentHTML { get; set; }
    public string ExtraLink { get; set; }
    public string Embbed { get; set; }
    public string MapTag { get; set; }

    public string DropTextFile { 
            get{
            return this.Caption1 + "#" + this.URL;
            }
        }


    public List<Model_PostCustomItem> GetItemCustomByGRoupID(int PCDID,int PostID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM PostCustomItem WHERE PCDID=@PCDID AND PostID=@PostID", cn);
            cmd.Parameters.Add("@PCDID", SqlDbType.Int).Value = PCDID;
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
    public List<Model_PostCustomItem> GetItemCustomByPostID(int PostID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM PostCustomItem WHERE  PostID=@PostID", cn);
            //cmd.Parameters.Add("@PCDID", SqlDbType.Int).Value = PCDID;
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public int Insert(Model_PostCustomItem item)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PostCustomItem (PCDID,PostID,PcName,PcGroupName,MID,Slug,Caption1,Caption2,URL,ContentHTML,ExtraLink,Embbed,MapTag) 
VALUES(@PCDID,@PostID,@PcName,@PcGroupName,@MID,@Slug,@Caption1,@Caption2,@URL,@ContentHTML,@ExtraLink,@Embbed,@MapTag) SET @PCIID = SCOPE_IDENTITY()", cn);

            cmd.Parameters.Add("@PCDID", SqlDbType.Int).Value = item.PCDID;
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = item.PostID;
            if (!string.IsNullOrEmpty(item.PcName))
                cmd.Parameters.Add("@PcName", SqlDbType.NVarChar).Value = item.PcName;
            else
                cmd.Parameters.AddWithValue("@PcName", DBNull.Value);


            if (!string.IsNullOrEmpty(item.PcGroupName))
                cmd.Parameters.Add("@PcGroupName", SqlDbType.NVarChar).Value = item.PcGroupName;
            else
                cmd.Parameters.AddWithValue("@PcGroupName", DBNull.Value);


            if (item.MID.HasValue)
                cmd.Parameters.Add("@MID", SqlDbType.Int).Value = item.MID;
            else
                cmd.Parameters.AddWithValue("@MID", DBNull.Value);



            if (!string.IsNullOrEmpty(item.Slug))
                cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = item.Slug;
            else
                cmd.Parameters.AddWithValue("@Slug", DBNull.Value);

            if (!string.IsNullOrEmpty(item.Caption1))
                cmd.Parameters.Add("@Caption1", SqlDbType.NVarChar).Value = item.Caption1;
            else
                cmd.Parameters.AddWithValue("@Caption1", DBNull.Value);

            if (!string.IsNullOrEmpty(item.Caption2))
                cmd.Parameters.Add("@Caption2", SqlDbType.NVarChar).Value = item.Caption2;
            else
                cmd.Parameters.AddWithValue("@Caption2", DBNull.Value);

            if (!string.IsNullOrEmpty(item.URL))
                cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = item.URL;
            else
                cmd.Parameters.AddWithValue("@URL", DBNull.Value);

            if (!string.IsNullOrEmpty(item.ContentHTML))
                cmd.Parameters.Add("@ContentHTML", SqlDbType.NVarChar).Value = item.ContentHTML;
            else
                cmd.Parameters.AddWithValue("@ContentHTML", DBNull.Value);

            if (!string.IsNullOrEmpty(item.ExtraLink))
                cmd.Parameters.Add("@ExtraLink", SqlDbType.NVarChar).Value = item.ExtraLink;
            else
                cmd.Parameters.AddWithValue("@ExtraLink", DBNull.Value);


            if (!string.IsNullOrEmpty(item.Embbed))
                cmd.Parameters.Add("@Embbed", SqlDbType.NVarChar).Value = item.Embbed;
            else
                cmd.Parameters.AddWithValue("@Embbed", DBNull.Value);

            if (!string.IsNullOrEmpty(item.MapTag))
                cmd.Parameters.Add("@MapTag", SqlDbType.NVarChar).Value = item.MapTag;
            else
                cmd.Parameters.AddWithValue("@MapTag", DBNull.Value);
          

            cmd.Parameters.Add("@PCIID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@PCIID"].Value;

            }
        }
        return ret;

    }

    public bool ClearCustomByPostIDandName(int PostID, string PcName)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM PostCustomItem WHERE PostID=@PostID AND PcName=@PcName", cn);
            cn.Open();

            cmd.Parameters.Add("@PcName", SqlDbType.NVarChar).Value = PcName;
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;
            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public bool Update(Model_PostCustomItem item)
    {
        int ret = 0;

        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE  PostCustomItem SET PCDID=@PCDID,PostID=@PostID,PcName=@PcName,MID=@MID,PcGroupName=@PcGroupName, 
    Slug=@Slug,Caption1=@Caption1,Caption2=@Caption2,URL=@URL,ContentHTML=@ContentHTML,ExtraLink=@ExtraLink,Embbe=@Embbedd,MapTag=@MapTag 
    WHERE PCIID=@PCIID", cn);

            cmd.Parameters.Add("@PCDID", SqlDbType.Int).Value = item.PCDID;
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = item.PostID;
            if (!string.IsNullOrEmpty(item.PcName))
                cmd.Parameters.Add("@PcName", SqlDbType.NVarChar).Value = item.PcName;
            else
                cmd.Parameters.AddWithValue("@PcName", DBNull.Value);


            if (!string.IsNullOrEmpty(item.PcGroupName))
                cmd.Parameters.Add("@PcGroupName", SqlDbType.NVarChar).Value = item.PcGroupName;
            else
                cmd.Parameters.AddWithValue("@PcGroupName", DBNull.Value);

            if (item.MID.HasValue)
                cmd.Parameters.Add("@MID", SqlDbType.Int).Value = item.MID;
            else
                cmd.Parameters.AddWithValue("@MID", DBNull.Value);


            if (!string.IsNullOrEmpty(item.Slug))
                cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = item.Slug;
            else
                cmd.Parameters.AddWithValue("@Slug", DBNull.Value);

            if (!string.IsNullOrEmpty(item.Caption1))
                cmd.Parameters.Add("@Caption1", SqlDbType.NVarChar).Value = item.Caption1;
            else
                cmd.Parameters.AddWithValue("@Caption1", DBNull.Value);

            if (!string.IsNullOrEmpty(item.Caption2))
                cmd.Parameters.Add("@Caption2", SqlDbType.NVarChar).Value = item.Caption2;
            else
                cmd.Parameters.AddWithValue("@Caption2", DBNull.Value);

            if (!string.IsNullOrEmpty(item.URL))
                cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = item.URL;
            else
                cmd.Parameters.AddWithValue("@URL", DBNull.Value);

            if (!string.IsNullOrEmpty(item.ContentHTML))
                cmd.Parameters.Add("@ContentHTML", SqlDbType.NVarChar).Value = item.ContentHTML;
            else
                cmd.Parameters.AddWithValue("@ContentHTML", DBNull.Value);

            if (!string.IsNullOrEmpty(item.ExtraLink))
                cmd.Parameters.Add("@ExtraLink", SqlDbType.NVarChar).Value = item.ExtraLink;
            else
                cmd.Parameters.AddWithValue("@ExtraLink", DBNull.Value);


            if (!string.IsNullOrEmpty(item.Embbed))
                cmd.Parameters.Add("@Embbed", SqlDbType.NVarChar).Value = item.Embbed;
            else
                cmd.Parameters.AddWithValue("@Embbed", DBNull.Value);

            if (!string.IsNullOrEmpty(item.MapTag))
                cmd.Parameters.Add("@MapTag", SqlDbType.NVarChar).Value = item.MapTag;
            else
                cmd.Parameters.AddWithValue("@MapTag", DBNull.Value);

            cmd.Parameters.Add("@PCIID", SqlDbType.Int).Value = item.PCIID;
            cn.Open();
            ret = ExecuteNonQuery(cmd);
        }

        return ret == 1;

    }



}

