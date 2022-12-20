
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class relats : MonoBehaviour
{

    //Create a List of new Dropdown options
    List<string> m_DropOptions = new List<string> {};

    [SerializeField]
    public static string dbname = "relations";
    [SerializeField]
    public static string tableName = "tab1";
    static string sqlQuery;
    static int lng;
    // Start is called before the first frame update
    void Start()
    {
        lng = Language_Manager.lang;
        RTchngr();
    }
    void RTchngr()
    {
        RT_opt_chg.changeScript(RTgetter());
    }

    List<string> RTgetter()
    {    sqlQuery  = "Select RT from " + tableName + ";";
        if(lng ==1)  sqlQuery = "Select RTF from " + tableName + ";";
        return(sqliteExecuter(sqlQuery));
    }

    public static void DCgetter(string RT)
    {
         sqlQuery = "Select DC from " + tableName + " where  RT = '" + RT + "';";
        if(lng ==1)  sqlQuery = "Select DCF from " + tableName + " where  RTF = '" + RT + "';";
        DC_opt_chg.changeScript(sqliteExecuter(sqlQuery));

    }

    public static void DSCgetter(string RT, string DC)
    {
        sqlQuery = "Select DSC from " + tableName + " where  RT = '" + RT + "' AND DC = '" + DC + "' ;";
        if(lng ==1)  sqlQuery = "Select DSCF from " + tableName + " where  RTF = '" + RT + "' AND DCF = '" + DC + "' ;";
        DSC_opt_chg.changeScript(sqliteExecuter(sqlQuery));
    }


    public static void Translator()
    {

        if (lng == 0)
        {
            string RT = playerPrefsMANAGER.ins_list["RT"];
            string DC = playerPrefsMANAGER.ins_list["DC"];
            string DSC = playerPrefsMANAGER.ins_list["DSC"];
            sqlQuery = "Select RTF , DCF , DSCF from " + tableName + " where  RT = '" + RT + "' AND DC = '" + DC + "' AND DSC = '" + DSC + "' ;";

        }
        if (lng == 1)
        {
            string RT = playerPrefsMANAGER.ins_list["RTF"];
            string DC = playerPrefsMANAGER.ins_list["DCF"];
            string DSC = playerPrefsMANAGER.ins_list["DSCF"];
            sqlQuery = "Select RT , DC , DSC from " + tableName + " where  RTF = '" + RT + "' AND DCF = '" + DC + "' AND DSCF = '" + DSC + "' ;";

        }
        add_tranlation(sqliteExecuter_for_translation(sqlQuery));
    }
    static void add_tranlation(List<string> vals)
    {
        if(lng == 0)
        {
            playerPrefsMANAGER.ins_list["RTF"] = vals[0];
            playerPrefsMANAGER.ins_list["DCF"] = vals[1];
            playerPrefsMANAGER.ins_list["DSCF"] = vals[2];
        }
        if (lng == 1)
        {
            playerPrefsMANAGER.ins_list["RT"] = vals[0];
            playerPrefsMANAGER.ins_list["DC"] = vals[1];
            playerPrefsMANAGER.ins_list["DSC"] = vals[2];
        }
    }

    public static List<string> sqliteExecuter(string _sqlQuery)
    {
        List<string> list = new List<string> { };
        try
        {


            IDbConnection dbcon;
            IDbCommand dbcmd;
            IDataReader reader;
            string conn = SetDataBaseClass.SetDataBase(dbname + ".db");
            dbcon = new SqliteConnection(conn);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = _sqlQuery;
            reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    string str = reader.GetString(0);

                    if (str != null && !list.Contains(str)) { list.Add(str); }
                }
                catch (Exception e)
                {
                    Debug.Log("reader sql problem" + _sqlQuery);
                    Debug.Log(e);
                }
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;

        }
        catch (Exception e)
        {
            Debug.Log("sql problem"+_sqlQuery);
            Debug.Log(e);
        }



            return (list);
       
        
    }

    public static List<string> sqliteExecuter_for_translation(string _sqlQuery)
    {
        List<string> list = new List<string> { };
        try
        {


            IDbConnection dbcon;
            IDbCommand dbcmd;
            IDataReader reader;
            string conn = SetDataBaseClass.SetDataBase(dbname + ".db");
            dbcon = new SqliteConnection(conn);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = _sqlQuery;
            reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    string str = reader.GetString(0);
                    list.Add(str);
                    str = reader.GetString(1);
                    list.Add(str);
                    str = reader.GetString(2);
                    list.Add(str);
                    //if (str != null && !list.Contains(str)) { list.Add(str); }
                }
                catch (Exception e)
                {
                    Debug.Log("reader sql problem" + _sqlQuery);
                    Debug.Log(e);
                }
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;

        }
        catch (Exception e)
        {
            Debug.Log("sql problem"+_sqlQuery);
            Debug.Log(e);
        }



            return (list);
       
        
    }



}