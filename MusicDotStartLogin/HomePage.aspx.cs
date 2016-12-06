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
       // StaticUtil.globalUser = "amc";


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
        // Stream stream = new MemoryStream(data);
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "Passing", String.Format("playByteArray('{0}');", data), false);    
        //string tempPath = Path.GetTempFileName();
        //FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate);
        //fs.Write(data, 0, data.Length);
        //fs.Close();
        //tempPath = RenameTempFile(tempPath);
        //tempPath = "C:\\data\\audio2.mp3";
        string uri = GetDataURL(data);
        AudioPlayer.Src = uri; //;//"C:\\Users\\Aaron Cox\\AppData\\Local\\Temp\\audio.mp3";//tempPath;  

            



    }


    private string RenameTempFile(string tfile)
    {
        string afile = tfile.Substring(0, tfile.Length - 4) + ".mp3";
        System.IO.File.Move(tfile, afile);
        return afile;
    }


        public static string GetDataURL(string imgFile)
        {
            return "data:audio/mp3;base64," + Convert.ToBase64String(File.ReadAllBytes(imgFile));
        }

        public static string GetDataURL(byte[] bytes)
        {
            return "data:audio/mp3;base64," + Convert.ToBase64String(bytes);
        }
        






}