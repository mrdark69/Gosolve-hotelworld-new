using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDatatableApp;
/// <summary>
/// Summary description for UsersController
/// </summary>
public class UsersController
{
    public UsersController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int InsertUserAdmin(Model_Users user)
    {
       
       return user.InsertUserAdmin(user);
    }

    public static Model_Users AdminChecklogin(string user, string pass)
    {
        Model_Users u = new Model_Users();
        return u.CheckLoginAdmin(user, pass);
    }

    public static object GetUserRole_DatatbleView(DTParameters param)
    {
        Model_usersRole cSG = new Model_usersRole();

        return cSG.getUserRoleAll_DataTable(param);
    }


    public static Model_Users GetUserbyID(int intUserID)
    {
        Model_Users u = new Model_Users();
        return u.getUserbyID(intUserID);
    }

    public static IList<Model_Users> GetUsers(Model_Users mu)
    {
        return mu.getUserAll(mu);
    }

    public static IList<Model_usersRole> GetRoleAll(Model_usersRole mu)
    {
        return mu.getRole();
    }

    public static Model_usersRole GetRoleByID(byte bytUserRoleID)
    {
        Model_usersRole u = new Model_usersRole();
        return u.getRoleByID(bytUserRoleID);
    }

    public static List<Model_usersRole> GetUserRole()
    {
        Model_usersRole mr = new Model_usersRole();
       return  mr.getRole();
    }


    public static bool  UpdateUserAdmin(Model_Users user)
    {
        
        return user.UpdateUserAdmin(user);
    }
    public static bool UpdateUserRole(Model_usersRole role)
    {
        return role.UpdateUsersRole(role);
    }

    public static byte AddUserRole(Model_usersRole role)
    {
        return role.AddeUsersRole(role);
    }

    public static List<Model_AppAction> GetActionAll()
    {
        Model_AppAction ma = new Model_AppAction();
        return ma.getListAppFeatureAll();
    }



    public static int InsertUserRole(Model_AppFeatureRole ma,bool Selected)
    {
    
        ma.DeleteAppFeature(ma);

        return (Selected ? ma.AddAppFeatureRole(ma) : 0);
    }

    public static List<Model_AppFeatureRole> GetAppFeature(byte UserRoleID)
    {
        Model_AppFeatureRole ma = new Model_AppFeatureRole();
        return ma.GetAppFeatureList(UserRoleID);
    }

    public static List<Model_AppFeatureRole> GetAppFeatureAuthen(byte UserRoleID)
    {
        Model_AppFeatureRole ma = new Model_AppFeatureRole();
        return ma.GetAppFeatureListAuthen(UserRoleID);
    }


}