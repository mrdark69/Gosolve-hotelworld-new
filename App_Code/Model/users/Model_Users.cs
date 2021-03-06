﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;
using Microsoft.AspNet.Identity;
using gs_newsletter;
using System.Web.Providers.Entities;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Model_User
/// </summary>
public class Model_Users : BaseModel<Model_Users>
{

    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateofBirth { get; set; }
    public byte Gender { get; set; }
    public int Nationality { get; set; }
    public string MobileNumber { get; set; }
    public string FC { get; set; }
    public string CurrentJob { get; set; }
    public byte UserCatId { get; set; }
    public byte UsersRoleId { get; set; }
    public bool Status { get; set; }
    public bool EmailVerify { get; set; }

    public string UserRoleName { get; set; }

    public bool IsResetPassword { get; set; } = false;

    public Model_Users()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertUserAdmin(Model_Users users)
    {
        int ret = 0;
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmdcheck = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserName=@UserName AND Password=@Password AND UserCatId=2", cn);
            cmdcheck.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.UserName;
            cmdcheck.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);
            cn.Open();
            if((int)ExecuteScalar(cmdcheck) > 0)
            {
                ret = -1;
            }
            else
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Users (FirstName,LastName,UserName,Password,Status,UserCatId,UsersRoleId)
VALUES(@FirstName,@LastName,@UserName,@Password,@Status,@UserCatId,@UsersRoleId)", cn);

                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = users.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = users.LastName;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.UserName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@UserCatId", SqlDbType.TinyInt).Value = users.UserCatId;
                cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = users.UsersRoleId;

                ret = ExecuteNonQuery(cmd);
            }
           
        }
        return ret;
    }


    public bool UpdateUserAdmin(Model_Users users)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            string w = string.Empty;
           
            SqlCommand cmd = new SqlCommand();
            if (IsResetPassword)
            {
                w = ", Password=@Password";
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Hotels2MD5EncryptedData(users.Password);
            }
            string q = @"UPDATE Users SET FirstName=@FirstName ,LastName=@LastName, UserName=@UserName " + w + " ,UsersRoleId=@UsersRoleId WHERE UserID=@UserID";
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = users.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = users.LastName;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = users.UserName;
           
            cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = users.UsersRoleId;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = users.UserID;
            cmd.CommandText = q;
            cmd.Connection = cn;
           
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;
        }

    }

    public Model_Users CheckLoginAdmin(string strUserName, string strPassword)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserName=@UserName AND Password=@Password", cn);
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = strUserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Hotels2MD5EncryptedData(strPassword);
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return  MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }


    //Encode by MD5 (cant Decode)
    private string Hotels2MD5EncryptedData(string input)
    {
        MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
        byte[] data = Encoding.ASCII.GetBytes(input);
        byte[] encryptedData = md5Provider.ComputeHash(data);
        string encryptedString = Convert.ToBase64String(encryptedData);
        return encryptedString;
    }

    public Model_Users getUserbyID(int intUserID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            StringBuilder cText = new StringBuilder();
            cText.Append("SELECT * FROM  Users WHERE UserID=@UserID");
            
            SqlCommand cmd = new SqlCommand(cText.ToString(), cn);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = intUserID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public IList<Model_Users> getUserAll(Model_Users mu)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder cText = new StringBuilder();
           
            string w = string.Empty;

            if (mu.UsersRoleId > 0)
            {
                w = "WHERE u.UsersRoleId =@UsersRoleId";
                cmd.Parameters.Add("@UsersRoleId", SqlDbType.TinyInt).Value = mu.UsersRoleId;

            }
            cText.Append(@"SELECT u.*,ur.Title AS UserRoleName FROM  Users u 
INNER JOIN UsersRole ur ON ur.UsersRoleId =u.UsersRoleId " + w);

            cmd.CommandText = cText.ToString();
            cmd.Connection = cn;
          
          
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }


}