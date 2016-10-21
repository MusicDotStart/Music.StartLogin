using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string user;
        //StaticUtil.UploadFile("C:\\t1.wma", "test");

        // for testing -- remove
       // StaticUtil.globalUser = "amc";
 
        user = StaticUtil.globalUser;

        int userID = StaticUtil.GetUserID(user);

        if (userID < 0)
            return;
            
        if(tbName.Text.Trim().Length < 1)
        {
            StaticUtil.MsgBox("Please name your track.", this.Page, this);
            return;
        }
        if (btnBrowse.HasFile)
        {
            try
            {
                Stream fs = btnBrowse.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string filename = Path.GetFileName(btnBrowse.FileName);
                if (!StaticUtil.UploadFile(btnBrowse.FileName, ref bytes ,tbName.Text.Trim(), userID)) throw new Exception();
                lblStatus.Text = "Upload status: File uploaded!";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
        else
            lblStatus.Text = "No track selected.";
    }
}