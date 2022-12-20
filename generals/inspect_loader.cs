using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class inspect_loader : MonoBehaviour
{   

    [SerializeField]
    private GameObject canv;
    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private GameObject panelToAttachButtonsTo;

    Rect canvRect, btnRect;
    RectTransform canvRTrans, btnRTrans;
    private void Start()
    {
        canvRTrans = panelToAttachButtonsTo.GetComponent<RectTransform>();
        btnRTrans = buttonPrefab.GetComponent<RectTransform>();

        canvRect = panelToAttachButtonsTo.GetComponent<RectTransform>().rect;
        btnRect = buttonPrefab.GetComponent<RectTransform>().rect;
        sql_executer__buttonCaretor();
    }
    public void canva_ins_deleter(){
        Button[] allChildren = canv.GetComponentsInChildren<Button>();
        foreach (Button child in allChildren)
          {
              child.gameObject.SetActive(false);
          }
    }


    public void sql_executer__buttonCaretor(){
        canva_ins_deleter();
        List<string[]> insID_Loc_from_Database;
        insID_Loc_from_Database = new List<string[]>();
        
        Report_Manager.empty_report_list();

        string _sqlQuery= "Select insID,Location from " + sql_handler.tableName ;
  
        IDbConnection dbcon;
            IDbCommand dbcmd;
            IDataReader reader;
            string conn = SetDataBaseClass.SetDataBase(sql_handler.dbname+".db");
            dbcon = new SqliteConnection(conn);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = _sqlQuery;
            Debug.Log("reading" + _sqlQuery+ "----" + sql_handler.dbname+".db" );
            reader = dbcmd.ExecuteReader();

            while(reader.Read())
            {
                string[] readed = { reader.GetString(0), reader.GetString(1) };
                insID_Loc_from_Database.Add(readed );
                //Debug.Log(readed[0]+readed[1]);
                //Debug.Log(readed[0]+readed[1]);
                create(readed);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;

            foreach(string[] idLoc in insID_Loc_from_Database)
            {
                //create(idLoc);
            }
   

    }

    void create(string[] idLoc)//Creates a button and sets it up
    {
        //Debug.Log(idLoc);
        string id = idLoc[0];
        string Loc = idLoc[1];

        Debug.Log(canvRect.height);
        panelToAttachButtonsTo = canv;
        canvRect.height = canvRect.height + btnRect.height;
        canvRTrans.sizeDelta = new Vector2( canvRect.width, canvRect.height + btnRect.height);
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.transform.SetParent(panelToAttachButtonsTo.transform);
        button.GetComponent<Button>().onClick.AddListener(() => {OnClick(id);});
        button.transform.GetChild(0).GetComponent<Text>().text = "ID: " + id;
        button.transform.GetChild(1).GetComponent<Text>().text = "Location: " + Loc;


    }
    
    void OnClick(string id)
    {
        Report_Manager.review_ID = id;
        SceneManager.LoadScene("review_scene", LoadSceneMode.Additive);        
    }

}
