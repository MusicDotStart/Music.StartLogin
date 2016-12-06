using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class CreateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void checkUName(object sender, EventArgs e)
    {
        string uname = tbUserName.Text.Trim();
        StaticUtil.MyConnection.ConnectionString = StaticUtil.ConnectionString;
        string selectusers = "SELECT uUsername FROM users";
        SqlCommand Command = new SqlCommand();
        SqlDataReader MyReader = default(SqlDataReader);
        string result = null;
        try
        {
            StaticUtil.MyConnection.Open();
            Command = new SqlCommand(selectusers, StaticUtil.MyConnection);
            MyReader = Command.ExecuteReader();
            //then authenticate user
            //add hashing

            while(MyReader.Read())
            {
                result = (string)MyReader["uUsername"];                
                if(result == uname)
                {
                    StaticUtil.MsgBox("Username already exist. Try Again.", this.Page, this);
                    return;
                }
               
            }
            if (!StaticUtil.UserReqmet(uname))
            {
                StaticUtil.MsgBox("Username needs to be at least 5 characters. Try Again.", this.Page, this);
                return;
            }

            if (!StaticUtil.PasswordReqMet(tbPassword.Text.Trim()))
            {
                StaticUtil.MsgBox("Password must contain a capital and a number or one of !@#$%^&. Try Again.", this.Page, this);
                return;
            }

            if(tbPassword2.Text.Trim() != tbPassword.Text.Trim())
            {
                StaticUtil.MsgBox("Passwords must match. Try Again.", this.Page, this);
                return;
            }


            if (!StaticUtil.ValidateEmail(tbAddress.Text.Trim()))
            {
                StaticUtil.MsgBox("Please enter a valid email address. Try Again.", this.Page, this);
                return;
            }


            StaticUtil.MyConnection.Close();
            //StaticUtil.MsgBox("Username Availible", this.Page, this);
            int vCode = StaticUtil.GetRandomVerifyCode();
            StaticUtil.insertUser(tbUserName.Text.Trim(), tbPassword.Text.Trim(), tbAddress.Text.Trim());
            StaticUtil.WriteVerifyCodeToUser(tbUserName.Text.Trim(), tbAddress.Text.Trim(), vCode);
            StaticUtil.SendVerify(tbAddress.Text.Trim(), vCode);
            Response.Redirect("Login.aspx");
            
        }
        catch (SqlException ex)
        {
            StaticUtil.MyConnection.Close();
            StaticUtil.MsgBox(ex.Message, this.Page, this);
            //Finally never caught
            //Cursor = Cursors.Default
            //MyConnection.Close()
        }
        finally
        {
            StaticUtil.MyConnection.Close();
        }
        
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}