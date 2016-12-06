using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Media;
using System.IO;
using WMPLib; //Add this COM Component Reference to your project

public partial class HomePage : System.Web.UI.Page
{

    WMPLib.WindowsMediaPlayer Player;

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
        Stream stream = new MemoryStream(data);
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "Passing", String.Format("playByteArray('{0}');", data), false);    



        Player = new WMPLib.WindowsMediaPlayer();
        Player.ur
        Player.controls.play();

    }











}