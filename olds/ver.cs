using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ver : MonoBehaviour
{
    public InputField Name;
    public InputField Family;
    public InputField Phone;
    public InputField Email;
    public string dbname;
    public void InsertInto(){

        var _name =  Name.text.Trim();
        var _family =  Family.text.Trim();
        var _phone =  Phone.text.Trim();
        var _email =  Email.text.Trim();
        string conn = SetDataBaseClass.SetDataBase(dbname+".db");
        
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        //For us replase we need
        string SqlQuery="Replace Into Users(Name,Family,Phone,Email)"+
                        "Values('" + _name + "','" + _family + "','" + _phone + "','" + _email + "')";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

    }

    public void FindItem(){
        var _name =  Name.text.Trim();
        var _family =  Family.text.Trim();
        var _phone =  Phone.text.Trim();
        var _email =  Email.text.Trim();

        string conn = SetDataBaseClass.SetDataBase(dbname+".db");
        
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string SqlQuery="Select Family, Email , Phone from Users where Name =  '" + _name + "'";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            Debug.Log(reader);
            Family.text = reader.GetString(0);
            Phone.text = reader.GetString(1);
            Email.text = reader.GetString(2);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

    }

    public void Start(){
    }

    void connOrcreateSqliteDB(string tableName){
        
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;
        string conn = SetDataBaseClass.SetDataBase(dbname+".db");
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string SqlQuery="CREATE TABLE IF NOT EXISTS "+ tableName +" (Name text PRIMARY KEY,  Family text , Email text ,  Phone text );";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }
    public void changeScrn(){   
        SceneManager.LoadScene("ReportScene");
    }

}