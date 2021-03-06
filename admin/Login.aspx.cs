﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Model_Users u = UserSessionController.AdminAppAuthLogin(this);
        }

    }

    protected void LogIn(object sender, EventArgs e)
    {



        Model_Users u = UsersController.AdminChecklogin(UserName.Text, Password.Text);
        if (u != null)
        {
            if (!u.Status)
            {
                HttpContext.Current.Response.Redirect("~/admin/accessdenie.aspx?error=noactivate");
            }
            else
            {
                //StaffSessionAuthorize StaffSession = new StaffSessionAuthorize();
                //StaffSession.CloseOtherCurrentLogin(clStaff.Staff_Id);
                UserSessionController.CloseOtherCurrentLogin(u.UserID);
                UserSessionController.SessionCreate(u);


            }
        }
        else
        {
            FailureText.Text = "UserName Invalid";
            ErrorMessage.Visible = true;
        }
        //if (IsValid)
        //{
        //    // Validate the user password
        //    //var manager = new UserManager();
        //    //ApplicationUser user = manager.Find(UserName.Text, Password.Text);
        //    //if (user != null)
        //    //{
        //    //    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
        //    //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        //    //}
        //    //else
        //    //{
        //    //    FailureText.Text = "Invalid username or password.";
        //    //    ErrorMessage.Visible = true;
        //    //}
        //}
    }
}