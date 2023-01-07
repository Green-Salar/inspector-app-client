using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sql_handler : MonoBehaviour
{   
    [SerializeField]
    public static string dbname = "Reports";
    [SerializeField]
    public static string tableName = "inspectionsENFR";
    // Start is called before the first frame update
    void Start()
    {
          create_or_connect_all_seprated(tableName);
    }

    public static void create_or_connect_all_seprated(string tableName){
        
        string SqlQuery="CREATE TABLE IF NOT EXISTS " + tableName 
           + " (  'insID' text PRIMARY KEY,  'Location' text,'lang' text,  'RT' text,  'DC' text,  'DSC' text,  'D' text, 'RS' text,  'SN' text,  'SA' text,  'ST' text,  'SCA' text,  'SUA' text,  'comment' text, " +
            " 'img1' text,  'img2' text,  'img3' text,  'img4' text,  'img5' text,  'img6' text , 'json' text );";
        
        sqliteExecuter(SqlQuery);

    }
    public static void drop(){
 
        string SqlQuery="drop TABLE  " + tableName 
           + ";";
        
         sqliteExecuter(SqlQuery);
        create_or_connect_all_seprated(tableName);
    }
    public static void InsertInto(string tableName, Dictionary<string,string> inspection_dictionary){

        string RT,DC,DSC,D,RS;
        string insID,Location, SN ,SA, ST, SCA, SUA,comment, img1, img2, img3, img4, img5, img6, json;
        string lang;



        insID     =  inspection_dictionary [ "ID"]    ;             
        Location  =  inspection_dictionary [ "Location"];
        lang = inspection_dictionary["lang"];
        SN = inspection_dictionary["SN"];

        if (lang == "0")
        {
            RT = inspection_dictionary["RT"].Replace("\"", "in");
            DC = inspection_dictionary["DC"].Replace("\"", "in");
            DSC = inspection_dictionary["DSC"].Replace("\"", "in");
            D = inspection_dictionary["D"].Replace("\"", "in");
            SA = inspection_dictionary["SA"].Replace("\"", "in");
            ST = inspection_dictionary["ST"].Replace("\"", "in");
            SCA = inspection_dictionary["SCA"].Replace("\"", "in");
            SUA = inspection_dictionary["SUA"].Replace("\"", "in");
            RS = inspection_dictionary["RS"].Replace("\"", "in");
            comment = inspection_dictionary["comment"].Replace("\"", "in"); 
        }
        else
        {
            RT = inspection_dictionary["RTF"].Replace("'", " ");
            DC = inspection_dictionary["DCF"].Replace("'", " ");
            DSC = inspection_dictionary["DSCF"].Replace("'", " ");
            D = inspection_dictionary["DF"].Replace("'", " ");

            SA = inspection_dictionary["SAF"].Replace("'", " ");
            ST = inspection_dictionary["STF"].Replace("'", " ");
            SCA = inspection_dictionary["SCAF"].Replace("'", " ");
            SUA = inspection_dictionary["SUAF"].Replace("'", " ");
            RS = inspection_dictionary["RSF"].Replace("'", " ");
            comment = inspection_dictionary["commentF"].Replace("'", "\'"); 
        }

        img1      =  inspection_dictionary [ "img1"]    ;              
        img2      =  inspection_dictionary [ "img2"]    ;              
        img3      =  inspection_dictionary [ "img3"]    ;              
        img4      =  inspection_dictionary [ "img4"]    ;              
        img5      =  inspection_dictionary [ "img5"]    ;              
        img6      =  inspection_dictionary [ "img6"]    ;
        json      =  inspection_dictionary [ "json"]  ;
        
        Debug.Log("!! inserting " + insID + " - " + Location + " - " + " into table" + tableName);
        
        string SqlQuery =
            "Insert OR Replace Into "  +
            tableName  +
            " (  insID,  Location , lang   ,  RT,  DC  ,  DSC  ,  D  ,  RS  , comment  ,  SN  ,  SA  ,  ST  ,  SCA  ,  SUA  ,  img1  ,  img2  ,  img3  ,  img4  ,  img5  ,  img6, json ) Values('" +
            insID     + "','" +
            Location    + "','" +
            lang + "','" +
            RT    + "','" +
            DC    + "','" + 
            DSC   + "','" + 
            D   + "','" +
            RS + "','" +
            comment  + "','" +
            SN + "','" +
            SA    + "','" + 
            ST    + "','" + 
            SCA    + "','" + 
            SUA    + "','" + 
            img1    + "','" + 
            img2    + "','" + 
            img3    + "','" + 
            img4    + "','" + 
            img5    + "','" + 
            img6    + "','" + 
            json   + "');" ;

        Debug.Log("-------sqlquery----------");

        Debug.Log(SqlQuery);
        Debug.Log("--------------end sql queryy--------------");


        sqliteExecuter(SqlQuery);

    }
    

     public static Dictionary<string,string> find_by_ID(string tableName , string insID ) {

        Dictionary<string,string> ins_list = 
        new Dictionary<string,string>{};
        string _sqlQuery = "Select insID,Location,RT,DC,DSC,D,lang,RS,SN,SA,ST,SCA,SUA,comment,img1,img2,img3,img4,img5,img6,json from " + tableName + " where insID = '" + insID + "';" ;
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;
        string conn = SetDataBaseClass.SetDataBase(dbname+".db");
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = _sqlQuery;
        reader = dbcmd.ExecuteReader();
        while(reader.Read()){
        ins_list = new Dictionary<string,string> {
           {     "ID", reader.GetString(  0 ) },
             {   "Location", reader.GetString(1   )},
            {    "RT", reader.GetString(  2 )     },
            {    "DC", reader.GetString(  3 )     },
            {    "DSC", reader.GetString(  4 )     },
            {    "D", reader.GetString(  5 )     },
            {    "lang", reader.GetString(  6 )     },
            {    "RS", reader.GetString(  7 )    } ,
            {    "SN", reader.GetString(  8 )    } ,
            {    "SA", reader.GetString(  9 )    } ,
            {    "ST", reader.GetString(  10 )    } ,
            {    "SCA", reader.GetString(  11 )   }  ,
            {    "SUA", reader.GetString(  12 )   }  ,
            {    "comment", reader.GetString(  13 ) },
           {     "img1", reader.GetString(  14 ) },
           {     "img2", reader.GetString(  15 ) },
           {     "img3", reader.GetString(  16 ) },
           {     "img4", reader.GetString(  17 ) },
           {     "img5", reader.GetString(  18 ) },
          {      "img6", reader.GetString(  19 )},
          {      "json", reader.GetString(  20 )}
         };
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
        return ins_list;
     }



    static void sqliteExecuter(string _sqlQuery){
        
        try{

        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;
        string conn = SetDataBaseClass.SetDataBase(dbname+".db");
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = _sqlQuery;
        reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
        }catch(System.Exception e){

            Debug.Log("sql executing problem - "+e);
            Screen_Manager.sqlerror();
        }
    }



public static string send_str_builder() {
        string _sqlQuery = "Select insID,json from " + tableName + " ;" ;
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;
        string conn = SetDataBaseClass.SetDataBase(dbname+".db");
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = _sqlQuery;
        reader = dbcmd.ExecuteReader();
         string all_in_one="{ ";
        while(reader.Read()){
        all_in_one = all_in_one + '"' + reader.GetString(0) + '"' + ":"  + reader.GetString(1)  + ","; 
        }
        all_in_one = all_in_one.Remove(all_in_one.Length - 1, 1);
        all_in_one += "}";
        Debug.Log(all_in_one);
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
        return all_in_one;
     }


public static Dictionary<string,Dictionary<string,string>> sql_imgs_dictionaries() {
        Dictionary<string,Dictionary<string,string>> id_img_list = new Dictionary<string,Dictionary<string,string>> {};
        Dictionary<string,string> ins_list ;
        string _sqlQuery = "Select insID,Location,img1,img2,img3,img4,img5,img6 from " + tableName + ";" ;
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;
        string conn = SetDataBaseClass.SetDataBase(dbname+".db");
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = _sqlQuery;
        reader = dbcmd.ExecuteReader();
        while(reader.Read()){
        //Debug.Log(reader.GetString(  2 ));
        ins_list = new Dictionary<string,string> {
           //{     "ID", reader.GetString(  0 ) },
            // {   "Location", reader.GetString(1   )},
            {    "img1", reader.GetString(  2 )     },
            {    "img2", reader.GetString(  3 )     },
            {    "img3", reader.GetString(  4 )     },
            {    "img4", reader.GetString(  5 )     },
            {    "img5", reader.GetString(  6 )     },
            {    "img6", reader.GetString(  7 )     },
         };
        
         id_img_list.Add(reader.GetString(  0 ), ins_list);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
        //foreach(var img in id_img_list){ Debug.Log(img);}
        return id_img_list;
     }


     
}