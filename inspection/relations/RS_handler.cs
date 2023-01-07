using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RS_handler : MonoBehaviour
{

    static Dictionary<string, int> rsdict;
    static string RSdbname = "relations";
    [SerializeField]
    static string RStableName = "DSCRStable";
    public GameObject RS_parent;
    static Transform RS_parentTransform;
    public GameObject toggle;
    public static List<string> toggles_list = new List<string> { };
    static Toggle m_Toggle_rs;
    static string RS_toggles_str;
    [SerializeField]
    InputField searchbar_RS;

    void Start()
    {
        Clear_RSParent();
        string _sqlQuery = (Language_Manager.lang == 0 ?
            "Select RS,UN from " + RStableName + " where  DSC = '" + playerPrefsMANAGER.ins_list["DSC"] + "';" : "Select RSF,UN from " + RStableName + " where  DSCF = '" + playerPrefsMANAGER.ins_list["DSCF"] + "';");
        first_Instantiator(playerPrefsMANAGER.ins_list[Language_Manager.lang == 0 ? "RS" : "RSF"]);
        rsdict = sql_RS_dict(_sqlQuery);
        foreach (var i in rsdict.OrderByDescending(r => r.Value)) { 
            Instantiator(i.Key);
        }
        
    }


    void Awake()
    {
        RS_parentTransform = RS_parent.transform;
    }

    private static string togglePrinter_RS()
    {
        toggles_list = new List<string> { };

        foreach (Transform child in RS_parentTransform)
        {
            m_Toggle_rs = child.GetComponent<Toggle>();

            RS_toggles_str = m_Toggle_rs.GetComponentInChildren<Text>().text;
            //Debug.Log(RS_toggles_str);
            if (m_Toggle_rs.isOn)
            {
                toggles_list.Add(RS_toggles_str);
            }
            if (!m_Toggle_rs.isOn)
            {
                toggles_list.Remove(RS_toggles_str);
            }
        }

        RS_toggles_str = "";

        foreach (string i in toggles_list)
        {//ML for later recommende solution choosen UN will be +1
            sql_insertNU(i);
            RS_toggles_str += i + ", ";
        }

        return RS_toggles_str;

    }
    public static void RS_save_to_prefs()
    {
        string RS_str = togglePrinter_RS();
        //Debug.Log(defects_str);
        if (Language_Manager.lang == 0) 
        {
            playerPrefsMANAGER.ins_list["RS"] = RS_str;

            playerPrefsMANAGER.ins_list["RSF"] = relats.string_translator(RStableName, RS_str, "RSF", "RS");

            Debug.Log("inserting in RS:-->" + RS_str); 
        }
        
        if (Language_Manager.lang == 1)
        {

            playerPrefsMANAGER.ins_list["RSF"] = RS_str;
         
            playerPrefsMANAGER.ins_list["RS"] = relats.string_translator(RStableName, RS_str, "RS", "RSF");

            Debug.Log("inserting in RSFF:-->" + RS_str);
        }
    }

    void Clear_RSParent()
    {
        foreach (Transform child in RS_parentTransform)
        {
            Destroy(child.gameObject);
        }
    }
    void Instantiator(string i)
    {

        GameObject newtoggle = Instantiate(toggle) as GameObject;
        try { newtoggle.GetComponentInChildren<Text>().text = i; } catch { Debug.Log("failed to name toggle"); }
        newtoggle.transform.SetParent(RS_parentTransform, false);
    }
    void first_Instantiator(string i)
    {
        if (i == "-") return;
        GameObject newtoggle = Instantiate(toggle) as GameObject;
        try { newtoggle.GetComponentInChildren<Text>().text = i; } catch { Debug.Log("failed to name toggle"); }
        newtoggle.transform.SetParent(RS_parentTransform, false);
        newtoggle.GetComponent<Toggle>().isOn = true;
    }
    private Dictionary<string, int> sql_RS_dict(string _sqlQuery)
    {
        Dictionary<string, int> RSdict = new Dictionary<string, int>();
        try
        {
            IDbConnection dbcon;
            IDbCommand dbcmd;
            IDataReader reader;
            string conn = SetDataBaseClass.SetDataBase(RSdbname + ".db");
            dbcon = new SqliteConnection(conn);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = _sqlQuery;
            reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    //Debug.Log(reader[0]);
                    string rs = reader.GetString(0);
                    string unstr = (reader[1] == DBNull.Value) ? "0": reader[1].ToString();
                    int un = int.Parse( unstr);
                    if (rs != null) { RSdict.Add(rs, un); }
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
            Debug.Log("sql rs dict problem" + _sqlQuery);
            Debug.Log(e);
        }



        return (RSdict);


    }

    private static void sql_insertNU(string RS)
    {
        string UN = (rsdict[RS]+1).ToString();
        
        int lang = Language_Manager.lang;
        string _sqlquery = lang == 0 ? "UPDATE " + RStableName + " SET UN = '" + UN + "' where RS =  '" + RS + "';" : "UPDATE " + RStableName + "SET UN = '" + UN + "' where RSF =  '" + RS + "';";
        
        try
        {
            IDbConnection dbcon;
            IDbCommand dbcmd;
            IDataReader reader;
            string conn = SetDataBaseClass.SetDataBase(RSdbname + ".db");
            dbcon = new SqliteConnection(conn);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = _sqlquery;
            reader = dbcmd.ExecuteReader();
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;
            Debug.Log("inserted UN>>" + UN + " >> for RS >> " + RS);
        }
        catch (Exception e)
        {
            Debug.Log("sql rs dict problem" + _sqlquery);
            Debug.Log(e);
        }
    }

    public void search_in_toggles()
    {
        string search_str = searchbar_RS.GetComponentInChildren<InputField>().text;
        search_str = search_str.Replace("-", " ");
        foreach (Transform child in RS_parentTransform)
        {
            bool ActiveChecker = true;
            m_Toggle_rs = child.GetComponent<Toggle>();
            if (m_Toggle_rs.isOn) m_Toggle_rs.gameObject.transform.SetSiblingIndex(0); 
            string RS_toggles_str = m_Toggle_rs.GetComponentInChildren<Text>().text;
            //RS_toggles_str = RS_toggles_str.Replace("-", " ");
            //Debug.Log(RS_toggles_str+"- - -" + m_Toggle_rs.isOn);
            if (!m_Toggle_rs.isOn)
            {
                foreach (string search_word in search_str.Split(" "))
                {
                    //aval farz konim active bayad bashe
                    if (!RS_toggles_str.Contains(search_word, System.StringComparison.CurrentCultureIgnoreCase)) { ActiveChecker = false; break; }
                    if (RS_toggles_str.Contains(search_word, System.StringComparison.CurrentCultureIgnoreCase)&&ActiveChecker==true) ActiveChecker = true;
                }
                m_Toggle_rs.gameObject.SetActive(ActiveChecker);
            }
        }

    }

}