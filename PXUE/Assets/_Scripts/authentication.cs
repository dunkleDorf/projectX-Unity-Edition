using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System;
using UnityEngine.UI;

public class authentication : MonoBehaviour {
    public SqliteConnection con_db;
    private string path;
    public SqliteCommand cmd_db;
    public SqliteDataReader rdr;

    public InputField login_field;
    public InputField pass_field;
    private string[] info = new string[3];
    public bool CheckUserInDB(string login,string pass)
    {
        try
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                path = Application.dataPath + "/StreamingAssets/login_db.bytes";
            }
            else
            {
                path = Application.persistentDataPath + "/login_db.bytes";                
                if (!File.Exists(path))
                {
                    WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "login_db.bytes");
                    while (!load.isDone) { }
                    File.WriteAllBytes(path, load.bytes);
                }
            }
            con_db = new SqliteConnection("URI=file:" + path);
            con_db.Open();
            cmd_db = new SqliteCommand("Select count(login), login, pass from 'logins' where login = '"+login+"'" , con_db);
            rdr = cmd_db.ExecuteReader();
            while (rdr.Read())
            {
                info[0] = rdr[0].ToString();
                info[1] = rdr[1].ToString();
                info[2] = rdr[2].ToString();             

            }
        }
        catch (Exception ex)
        {
            //Q.text = ex.ToString() + path;
        }
        if (info[0] == "1" && info[1] == login && info[2] == pass)
        {
            return true;

        }
        else {
            return false;
        }
    }

    public void Authentication_button() {
        if (CheckUserInDB(login_field.text, pass_field.text))
        {
            Debug.Log("u r in system");
        }
        else {
            Debug.Log("smth wrong");
        }
    }
}
