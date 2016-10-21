using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerifyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void tbCode_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        if(tbCode.Text.Trim() == StaticUtil.GetUserVerifyCode(StaticUtil.Username))
        {
            StaticUtil.MarkAccountVerified(StaticUtil.Username);
            StaticUtil.MsgBox("You've been verified!", this.Page, this);
            Response.Redirect("HomePage.aspx");
        }
        else
        {
            StaticUtil.MsgBox("The verification code you entered was not correct. Try again.", this.Page, this);
           
        }
    }
}