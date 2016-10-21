using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Media;
using WMPLib; //Add this COM Component Reference to your project

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StaticUtil.globalUser = "amc";


        lblUser.Text = StaticUtil.globalUser;

        PlayRandomMusic();


    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Response.Redirect("Upload.aspx");
    }



    private void PlayRandomMusic()
    {
        byte[] data = { };
        StaticUtil.GetData(StaticUtil.GeRandomDataID(), ref data);

        ScriptManager.RegisterStartupScript(this, typeof(Page), "Passing", String.Format("playByteArray('{0}');", data), false);   


    }







}