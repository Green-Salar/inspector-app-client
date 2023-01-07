using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ins_list_controller_lastPage : MonoBehaviour
{
    [SerializeField]
     InputField comment;
    // Start is called before the first frame update
    public void saveAllToDB()
    {
        RS_handler.RS_save_to_prefs();
        comments();
        playerPrefsMANAGER.ins_list["json"] = MyToString2(playerPrefsMANAGER.ins_list);


        sql_handler.InsertInto(sql_handler.tableName, playerPrefsMANAGER.ins_list);
    }


    private string MyToString2(Dictionary<string, string> dictionary)
    {

        try
        {
            string s = "";
            foreach (var kvp in dictionary)
            {
                //string value = kvp.Value.Replace("'", " ");
                if (kvp.Key != "json") s = s + '"' + kvp.Key + '"' + ":" + '"' + kvp.Value.Replace("\"", "inch").Replace("'", "`") + '"' + ",";
            }
            s = s.Remove(s.Length - 1, 1);
            s =s.Replace("'", "`");
            return "{" + s + "}";
        }
        catch { return "EROR!"; }
    }

    // Update is called once per frame
   void comments()
    {
        string comment_str = comment.GetComponent<InputField>().text;
        if (Language_Manager.lang == 0) playerPrefsMANAGER.ins_list["comment"] = comment_str; 
        else playerPrefsMANAGER.ins_list["commentF"] = comment_str ;
    }
}
