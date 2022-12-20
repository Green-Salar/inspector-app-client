using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class AppManager_lastPage : MonoBehaviour
{

    // Start is called before the first frame update

    [SerializeField]
    private InputField comment;
    [SerializeField]
    private Dropdown RS;
    //public Text m_Text;
    [SerializeField]
    private Dropdown s_action,s_timeline,s_corrective_action,s_using_action;
    //Ouput the new value of the Dropdown into Text
    void Start()
    {
   
        _initializer();
       
    }
    
    public void saveAllToDB(){
      playerPrefsMANAGER.ins_list["json"] =  MyToString2(playerPrefsMANAGER.ins_list);
            sql_handler.InsertInto(sql_handler.tableName, playerPrefsMANAGER.ins_list);
    } 
    
    private string MyToString2(Dictionary<string, string> dictionary)
    {
        
        try{string s=""; 
                foreach(var kvp in dictionary){
                  if(kvp.Key != "json")  s=s+'"'+ kvp.Key+'"'+":" +'"'+ kvp.Value +'"'+",";
                }
                s=s.Remove(s.Length - 1, 1);

            return "{" + s + "}";
        }catch{return "EROR!";}
    }


    void Save(){
      _add_to_Report(playerPrefsMANAGER.ins_list["ID"],playerPrefsMANAGER.ins_list);
    }
    void _add_to_Report(string insID, Dictionary<string,string> inspection){
              if (Report_Manager.report_list.ContainsKey(insID)){
           Report_Manager.report_list[insID] = inspection;
        }else{
        Report_Manager.report_list.Add(insID,inspection);
        }
    }
    void _initializer(){

            if ( playerPrefsMANAGER.ins_list["comment"] !="-"){
        comment.text = "Comment: "+playerPrefsMANAGER.ins_list["comment"] ;
      };

      if ( playerPrefsMANAGER.ins_list["RS"] !="-"){
        RS.options[RS.value].text = "Recomended solution: "+playerPrefsMANAGER.ins_list["RS"] ;
      };

      if ( playerPrefsMANAGER.ins_list["SA"] !="-"){
         s_action.options[0].text = "S_action: " + playerPrefsMANAGER.ins_list["SA"]  ;
      };
      if ( playerPrefsMANAGER.ins_list["ST"] !="-"){
         s_timeline.options[0].text = "S_timeline: "+playerPrefsMANAGER.ins_list["ST"]  ;
      };
      if ( playerPrefsMANAGER.ins_list["SCA"] !="-"){
        s_corrective_action.options[0].text = "S_corrective: "+ playerPrefsMANAGER.ins_list["SCA"]  ;
      };
      if ( playerPrefsMANAGER.ins_list["SUA"] !="-"){
         s_using_action.options[0].text = "S_using: "+playerPrefsMANAGER.ins_list["SUA"] ;
      };

      
    }
    public void dropdown_Changer(Dropdown drp,string str){ 
        string choosen =  drp.options[drp.value].text;
        playerPrefsMANAGER.ins_list[str] = choosen;
    }

    public void RS_changed()
    {   playerPrefsMANAGER.ins_list["RS"] = RS.options[RS.value].text; } 
    public void Comment_changed()
    {   playerPrefsMANAGER.ins_list["comment"] = comment.text; } 

    public void s_action_changed()
    {   playerPrefsMANAGER.ins_list["SA"] = s_action.options[s_action.value].text; }
    public void s_timeline_changed()
    {   playerPrefsMANAGER.ins_list["ST"] = s_timeline.options[s_timeline.value].text; }
    public void s_corrective_action_changed()
    {    playerPrefsMANAGER.ins_list["SC"] = s_corrective_action.options[s_corrective_action.value].text; }
    public void s_using_action_changed()
    {    playerPrefsMANAGER.ins_list["SUA"] = s_using_action.options[s_using_action.value].text;}


}

