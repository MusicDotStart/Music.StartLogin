using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;

/// <summary>
/// Summary description for StaticUtil
/// </summary>
public static class StaticUtil
{

    public static string globalUser;

    static string[] mediaExtensions = {  ".MP3" }; //etc



    public static string Username
    {
        get
        {
            return globalUser;

        }
        set
        {
            globalUser = value;

        }

    }

    public static string ConnectionString = "Server=PQSERVER; Database=MusicDotStart; User ID=mtmanage; Password=mtmanage;";
    public static SqlConnection MyConnection = new SqlConnection();



    public static object hash(string t)
    {
        UnicodeEncoding encode = new UnicodeEncoding();
        byte[] bytes = encode.GetBytes(t);
        string result = Convert.ToBase64String(new SHA1Managed().ComputeHash(bytes));
        result = result.Substring(0, result.Length - 1);
        return result;
    }


    public static void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    public static void SendVerify(string address, int code)
    {
        MailMessage mail = new MailMessage();
        SmtpClient client = new SmtpClient();
        mail.From = new MailAddress("alerts@proactivequality.com");
        client.Host = "mail.proactivequality.com";
        client.Port = 25;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.EnableSsl = true;
        client.Timeout = 10000;
        client.Credentials = new System.Net.NetworkCredential("alerts@proactivequality.com", "cncAlerts1");
        mail.Subject = "Music.Start verification code";
        mail.Body = "Please log in and enter this verification code: " + code.ToString();
        //mail.Body = "TESTINGGGG";
        mail.To.Add(address);
        ServicePointManager.ServerCertificateValidationCallback = delegate(
            Object obj, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors errors)
        {
            return (true);
        };

        try
        {
            client.Send(mail);
        }
        catch(Exception ex)
        {
            //handle
        }


    }

    public static int GetRandomVerifyCode()
    {
        int _min = 0000;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);         
    }

    public static void WriteVerifyCodeToUser(string username, string address, int code)
    {
        //UPDATE users SET uVerifyCode = @uVerifyCode WHERE uUserName = @uUserName
        MyConnection.ConnectionString = ConnectionString;
        string selectuser = "UPDATE users SET uVerifyCode = @uVerifyCode, uNotifyMeAddress = @uNotifyMeAddress WHERE uUserName = @uUserName";
        SqlCommand Command = new SqlCommand();   
        try
        {
            StaticUtil.MyConnection.Open();
            //then authenticate user
            //add hashing
            Command = new SqlCommand(selectuser, StaticUtil.MyConnection);
            Command.Parameters.AddWithValue("@uUsername", username);
            Command.Parameters.AddWithValue("@uNotifyMeAddress", address);   
            Command.Parameters.AddWithValue("@uVerifyCode", code.ToString());   
            Command.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {
            // and do what?
            //StaticUtil.MyConnection.Close();   -- handled in finally
            
        }
        finally
        {
            MyConnection.Close();
        }
    }

    public static string GetUserVerifyCode(string username)
    {
        string code = string.Empty;

        MyConnection.ConnectionString = ConnectionString;
        string selectuser = "SELECT uVerifyCode FROM users WHERE uUsername = @uUsername";
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
            MyReader = Command.ExecuteReader(CommandBehavior.SingleRow);
            if (MyReader.Read())
            {
                int icode = (int)MyReader["uVerifyCode"];
                code = icode.ToString();
                StaticUtil.MyConnection.Close();
            } 
        }
        catch (SqlException ex)
        {
            
            //what here

        }
        finally
        {
            StaticUtil.MyConnection.Close();
        }

        return code;
    }



    public static void MarkAccountVerified(string username)
    {
        //UPDATE users SET uVerifyCode = @uVerifyCode WHERE uUserName = @uUserName
        MyConnection.ConnectionString = ConnectionString;
        string selectuser = "UPDATE users SET uType = 'Verified' WHERE uUserName = @uUserName";
        SqlCommand Command = new SqlCommand();
        try
        {
            StaticUtil.MyConnection.Open();
            //then authenticate user
            //add hashing
            Command = new SqlCommand(selectuser, StaticUtil.MyConnection);
            Command.Parameters.AddWithValue("@uUsername", username);
            Command.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {
            // and do what?
            //StaticUtil.MyConnection.Close();   -- handled in finally

        }
        finally
        {
            MyConnection.Close();
        }
    }


    //create user if doesn't exist


    public static void insertUser(string username, string password, string address)
    {
        string code = string.Empty;

        MyConnection.ConnectionString = ConnectionString;
        string selectuser = "INSERT INTO users (uUsername, uPassword, uNotifyMeAddress, uType) VALUES (@uUsername, @uPassword, @uNotifyMeAddress, @uType)";
        SqlCommand Command = new SqlCommand();
        try
        {
            StaticUtil.MyConnection.Open();
            //then authenticate user
            //add hashing
            Command = new SqlCommand(selectuser, StaticUtil.MyConnection);
            Command.Parameters.AddWithValue("@uUsername", username);
            Command.Parameters.AddWithValue("@uPassword", hash(password));
            Command.Parameters.AddWithValue("@uNotifyMeAddress", address);
            Command.Parameters.AddWithValue("@uType", "Unverified");
            Command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {

            //what here

        }
        finally
        {
            StaticUtil.MyConnection.Close();
        }  

    }

    public static bool UploadFile(string path, ref byte[] data, string name, int owner, string genre)
    {
        bool success = false;
        int id;
        try
        {
            using (MusicDotStartEntities obj = new MusicDotStartEntities())
            {
               id  = obj.genres.Where(g => g.genre1 == genre).Select(i => i.id).FirstOrDefault();
            }
                if (!IsAudioFile(path, ref mediaExtensions)) throw new Exception("This is not a supported file type.");
            //byte[] data = File.ReadAllBytes(path);
            MyConnection.ConnectionString = ConnectionString;
            StaticUtil.MyConnection.Open();
            string insert_audio = "INSERT INTO audio (name, data, owner, genre) VALUES (@name, @data, @owner, @genre)";
            SqlCommand Command = new SqlCommand(insert_audio, StaticUtil.MyConnection);
            Command.Parameters.AddWithValue("@name", name);
            Command.Parameters.AddWithValue("@data", data);
            Command.Parameters.AddWithValue("@owner", owner);
            Command.Parameters.AddWithValue("genre", id);
            Command.ExecuteNonQuery();
            success = true;
        }
        catch(Exception ex)
        {

        }
        finally
        {
            MyConnection.Close();
        }
        return success;
    }



    static bool IsAudioFile(string path, ref string[] fileExtensions)
    {
        return -1 != Array.IndexOf(fileExtensions, Path.GetExtension(path).ToUpperInvariant());
    }






    public static bool GetData(int id, ref byte[] data)
    {
        bool success = false;
        try
        {
            SqlDataReader MyReader = default(SqlDataReader);
            MyConnection.ConnectionString = ConnectionString;
            StaticUtil.MyConnection.Open();
            string select_audio = "SELECT data FROM audio WHERE id = @id"; 
            SqlCommand Command = new SqlCommand(select_audio, StaticUtil.MyConnection);
            Command.Parameters.AddWithValue("@id", id);
            MyReader = Command.ExecuteReader(CommandBehavior.SingleRow);
            if (MyReader.Read())
            {
                data = (byte[])MyReader["data"];
            }
            success = true;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            MyConnection.Close();
        }
        return success;
    }



    public static int GeRandomDataID()
    {
        int id = -1;
        MyConnection.ConnectionString = ConnectionString;
        string selectuser = "SELECT TOP 1 id FROM audio ORDER BY NEWID()";
        SqlCommand Command = new SqlCommand();
        SqlDataReader MyReader = default(SqlDataReader);
        try
        {
            StaticUtil.MyConnection.Open();
            //then authenticate user
            //add hashing
            Command = new SqlCommand(selectuser, StaticUtil.MyConnection);
            MyReader = Command.ExecuteReader(CommandBehavior.SingleRow);
            if (MyReader.Read())
            {
                id = (int)MyReader["Id"];
            }
        }
        catch (SqlException ex)
        {

        }
        finally
        {
            StaticUtil.MyConnection.Close();
        }

        return id;
    }

    public static int GetUserID(string user)
    {
        int id = -1;
        MyConnection.ConnectionString = ConnectionString;
        string selectuser = "SELECT uID FROM users WHERE uUsername = @uUsername";
        SqlCommand Command = new SqlCommand();
        SqlDataReader MyReader = default(SqlDataReader);
        string result = null;
        try
        {
            StaticUtil.MyConnection.Open();
            //then authenticate user
            //add hashing
            Command = new SqlCommand(selectuser, StaticUtil.MyConnection);
            Command.Parameters.AddWithValue("@uUsername", user);
            MyReader = Command.ExecuteReader(CommandBehavior.SingleRow);
            if (MyReader.Read())
            {
                id = (int)MyReader["uId"];    
            }
        }
        catch (SqlException ex)
        {

            //what here

        }
        finally
        {
            StaticUtil.MyConnection.Close();
        }

        return id;
    }


    public static bool PasswordReqMet(string p)
    {
        bool met = false;
        var cap = p.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()) != -1;
        var num = p.IndexOfAny("0123456789".ToCharArray()) != -1;
        var spe = p.IndexOfAny("!@#$%^&".ToCharArray()) != -1;
        if (cap && (num || spe))
            met = true;
        return met;      
    }

    public static bool UserReqmet(string u)
    {
        bool met = false;
        met = true;//impl me
        return met;
    }


    public static bool ValidateEmail(string email)
    {
        try
        {
            var address = new System.Net.Mail.MailAddress(email);
            return address.Address == email;
        }
        catch { return false; }
    }






}