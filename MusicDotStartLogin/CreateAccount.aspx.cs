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
                if(result == tbUserName.Text.Trim())
                {
                    StaticUtil.MsgBox("Username already exist. Try Again.", this.Page, this);
                    return;
                }
               
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