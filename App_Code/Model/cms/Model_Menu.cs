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


public enum MenuCategory : byte
{
    Post = 1,
    Archive = 2,
    Taxonomy = 3,
    CustomLink = 4

}
//Menu Position
//public class Model_Type : BaseModel<Model_Type>
//{
//    public byte MenuTypeID { get; set; }
//    public string Title { get; set; }
//    public bool Status { get; set; }

//    public List<Model_Type> GetMenuPositionAll()
//    {
//        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
//        {
//            SqlCommand cmd = new SqlCommand("SELECT * FROM MenuType WHERE Status =1 ", cn);
//            cn.Open();
//            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
//        }
//    }
//}

//menu Group
public class Model_Group : BaseModel<Model_Group>
{
    public int MGID { get; set; }
    public string Title { get; set; }
    public bool Status { get; set; }


    public List<Model_Group> GetMenuGroupAll()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM MenuGroup WHERE Status =1 ", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

   



    public Model_Group GetMenuGroupByID(int MGID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM MenuGroup WHERE Status =1 AND  MGID=@MGID ", cn);
            cmd.Parameters.Add("@MGID", SqlDbType.Int).Value = MGID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
           // return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
}

public class Model_Menu : BaseModel<Model_Menu>
{
    public int MID { get; set; }
    public int MGID { get; set; }
    public string Title { get; set; }
    public string TitleOrigin { get; set; }
    public string Slug { get; set; }
   
    public string CustomUrl { get; set; }
 
    public bool Status { get; set; }

    public int MenuRefID { get; set; }
    public int Lv { get; set; }

    public int Priority { get; set; }

    public byte MCategory { get; set; }


    public string TitleTag { get; set; } = string.Empty;

    public int? TaxID { get; set; }
    public byte? PostTypeID { get; set; }
    public int? PostID { get; set; }

    public Model_Menu()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool DeleteArr(string notIN)
    {
        bool ret = false;
        if (!string.IsNullOrEmpty(notIN))
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE  FROM Menu WHERE MID NOT IN (" + notIN + ")", cn);
                cn.Open();
                ret = ExecuteNonQuery(cmd) == 1;
            }
        }
        

        return ret;
    }

    public bool DeleteMenu(int MID)
    {
        bool ret = false;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE  FROM Menu WHERE MID =@MID", cn);
            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = MID;
            cn.Open();
            ret = ExecuteNonQuery(cmd) == 1;
        }


        return ret;
    }


    public bool UpdateSort(int MID,int MenuRefID, int Priority)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE  Menu SET MenuRefID=@MenuRefID , Priority=@Priority WHERE MID=@MID", cn);
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = Priority;
            cmd.Parameters.Add("@MenuRefID", SqlDbType.Int).Value = MenuRefID;
            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = MID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }
    public List<Model_Menu> GetMenuAll(int MGID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Menu 
            WHERE Status =1 AND MGID=@MGID
            ORDER BY MID ASC, MenuRefID ASC, Priority ASC
            ", cn);
            cmd.Parameters.Add("@MGID", SqlDbType.Int).Value = MGID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public Model_Menu GetMenuByID(int MID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Menu 
            WHERE MID=@MID", cn);
            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = MID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
           
        }
    }


    public bool Update(Model_Menu m)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Menu SET Title=@Title ,TitleTag=@TitleTag ,CustomUrl=@CustomUrl WHERE MID=@MID", cn);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = m.Title;
            cmd.Parameters.Add("@TitleTag", SqlDbType.NVarChar).Value = m.TitleTag;
            cmd.Parameters.Add("@CustomUrl", SqlDbType.NVarChar).Value = m.CustomUrl;
            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = m.MID;

            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }
    }

//    MID int No
//MGID int No
//Title nvarchar(200)   Yes
//TitleOrigin nvarchar(200)   Yes
//Slug    nvarchar(200)   Yes
//MenuTypeID  tinyint Yes
//CustomUrl nvarchar(200)   Yes
//Status  bit Yes((1))
//MenuRefID int No((0))
//Lv int No((0))
//IsCustomUrl bit No((0))
//Priority int No((1))
//MCategory tinyint No
//TaxID   int Yes
//PostTypeID tinyint Yes
//PostID  int Yes

    public int InsertMenuFirst(Model_Menu mu)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Menu (MGID,Title,TitleOrigin,Slug,CustomUrl,Status,MenuRefID,Lv,Priority,MCategory,TaxID,PostTypeID,PostID,TitleTag) 
            VALUES (@MGID,@Title,@TitleOrigin,@Slug,@CustomUrl,@Status,@MenuRefID,@Lv,@Priority,@MCategory,@TaxID,@PostTypeID,@PostID,@TitleTag) SET @MID = SCOPE_IDENTITY()", cn);


            cmd.Parameters.Add("@MGID",SqlDbType.Int).Value = mu.MGID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = mu.Title;
            cmd.Parameters.Add("@TitleOrigin", SqlDbType.NVarChar).Value = mu.TitleOrigin;
            cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = mu.Slug;
     
            cmd.Parameters.Add("@CustomUrl", SqlDbType.NVarChar).Value = mu.CustomUrl;
            cmd.Parameters.Add("@TitleTag", SqlDbType.NVarChar).Value = mu.TitleTag;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = mu.Status;
            cmd.Parameters.Add("@MenuRefID", SqlDbType.Int).Value = mu.MenuRefID;
            cmd.Parameters.Add("@Lv", SqlDbType.Int).Value = mu.Lv;
            
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = mu.Priority;
            cmd.Parameters.Add("@MCategory", SqlDbType.TinyInt).Value = mu.MCategory;

            if (mu.TaxID.HasValue)
                cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = mu.TaxID;
            else
                cmd.Parameters.AddWithValue("@TaxID",DBNull.Value);


            if (mu.PostID.HasValue)
                cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = mu.PostID;
            else
                cmd.Parameters.AddWithValue("@PostID", DBNull.Value);



            if (mu.PostTypeID.HasValue)
                cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = mu.PostTypeID;
            else
                cmd.Parameters.AddWithValue("@PostTypeID", DBNull.Value);

            

            cmd.Parameters.Add("@MID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@MID"].Value;

            }
        }
        return ret;

    }


}