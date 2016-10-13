using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text;
using System.Data;

public partial class Login : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)  
    {
        //StaticUtil.SendMail("cncox5150@gmail.com", 8765);
        //tbUserName.Attributes.Add("onfocus", "UserFocused(this)");
    }
    protected void tbPassword_TextChanged(object sender, EventArgs e) 
    {
        MsgBox("changed", this.Page, this);
    }
    protected void tbUserName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username;
        string password;
        //insert text handling for bad inputs
        username = tbUserName.Text;
        password = tbPassword.Text;
        login(username, password);


    }



    private void login(string username, string password)
    {
        StaticUtil.MyConnection.ConnectionString = StaticUtil.ConnectionString;
        object passwordObj = StaticUtil.hash(password);
        string selectuser = "SELECT uType FROM users WHERE uUsername = @uUsername AND uPassword = @uPassword";
        SqlCommand Command = new SqlCommand();
        SqlDataReader MyReader = default(SqlDataReader);
        string result = null;
        try
        {
            StaticUtil.MyConnection.Open();
            //then authenticate user
            //add hashing
            Command = new SqlCommand(selectuser, StaticUtil.MyConnection);
            Command.Parameters.AddWithValue("@uUsername", username);
            Command.Parameters.AddWithValue("@uPassword", passwordObj);
            MyReader = Command.ExecuteReader(CommandBehavior.SingleRow);
            if (MyReader.Read())
            {
                result = (string)MyReader["uType"];
                StaticUtil.MyConnection.Close();
                StaticUtil.Username = username;
                if (result != "Verified" && result != "Administrator")
                {
                    Verify(username);
                }
                LoggedIn(username);
                return;
            }
            else
            {
                StaticUtil.MyConnection.Close();
                MsgBox("Username and/or Password is wrong or doesn't exist. Try again.", this.Page, this);
                return;
            }
        }
        catch (SqlException ex)
        {
            StaticUtil.MyConnection.Close();
            MsgBox(ex.Message, this.Page, this);
            //Finally never caught
            //Cursor = Cursors.Default
            //MyConnection.Close()
        }
       MsgBox("Authentication Failed", this.Page, this);
    }




    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }


    private void LoggedIn(string username)
    {

        MsgBox("logged in as " + username, this.Page, this);

    }

    private void Verify(string username)
    {
        MsgBox("please verify" + username, this.Page, this);
        Response.Redirect("verifyAccount.aspx");
    }


    protected void btnMakeAcct_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateAccount.aspx");
    }
    protected void tbUserName_TextChanged1(object sender, EventArgs e)
    {

    }
}