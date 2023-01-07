using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ins_list_var_controller_lastPage : MonoBehaviour
{

    // Start is called before the first frame update

    [SerializeField]
     InputField comment;
    [SerializeField]
     Dropdown RS;
 
    [SerializeField]
     Dropdown s_action,s_timeline,s_corrective_action,s_using_action,SN;

    //Ouput the new value of the Dropdown into Text
    void Start()
    {
   
      if(Language_Manager.lang == 0)  _initializer_EN();
      if(Language_Manager.lang == 1 ) _initializer_FR();
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


     void safty_option_changer(){
      if(Language_Manager.lang == 0)  _initializer_EN();
      if(Language_Manager.lang == 1 ) _initializer_FR();

    }
     void _initializer_EN(){

      if ( playerPrefsMANAGER.ins_list["RS"] !="-"){
        RS.options[RS.value].text = "Recomended solution: "+playerPrefsMANAGER.ins_list["RS"] ;
        };
            if ( playerPrefsMANAGER.ins_list["comment"] !="-"){
        comment.text = "Comment: "+playerPrefsMANAGER.ins_list["comment"] ;
      };

      if ( playerPrefsMANAGER.ins_list["SA"] !="-"){
         s_action.options[0].text = "Safety_action: " + playerPrefsMANAGER.ins_list["SA"]  ;
      };
      if ( playerPrefsMANAGER.ins_list["ST"] !="-"){
         s_timeline.options[0].text = "Safety_timeline: "+playerPrefsMANAGER.ins_list["ST"]  ;
      };
      if ( playerPrefsMANAGER.ins_list["SCA"] !="-"){
        s_corrective_action.options[0].text = "Safety_corrective: "+ playerPrefsMANAGER.ins_list["SCA"]  ;
      };
      if ( playerPrefsMANAGER.ins_list["SUA"] !="-"){
         s_using_action.options[0].text = "Safety_using: "+playerPrefsMANAGER.ins_list["SUA"] ;
      };
    }
    void _initializer_FR(){

      if ( playerPrefsMANAGER.ins_list["RSF"] !="-"){
        RS.options[RS.value].text = "Solution recommandée: "+playerPrefsMANAGER.ins_list["RSF"] ;
      };
            if ( playerPrefsMANAGER.ins_list["commentF"] !="-"){
        comment.text = "Commentaire: "+playerPrefsMANAGER.ins_list["commentF"] ;
      };

      if ( playerPrefsMANAGER.ins_list["SAF"] !="-"){
         s_action.options[0].text = "Mesures de sécurité: " + playerPrefsMANAGER.ins_list["SAF"]  ;
      };
      if ( playerPrefsMANAGER.ins_list["STF"] !="-"){
         s_timeline.options[0].text = "Calendrier de sécurité: "+playerPrefsMANAGER.ins_list["STF"]  ;
      };
      if ( playerPrefsMANAGER.ins_list["SCAF"] !="-"){
        s_corrective_action.options[0].text = "Correctif de sécurité: "+ playerPrefsMANAGER.ins_list["SCAF"]  ;
      };
      if ( playerPrefsMANAGER.ins_list["SUAF"] !="-"){
         s_using_action.options[0].text = "Sécurité à l'aide de: "+playerPrefsMANAGER.ins_list["SUAF"] ;
      };
    }

    public void SN_changed()
    { playerPrefsMANAGER.ins_list["SN"] = SN.options[SN.value].text; }

  
    public void Comment_changed()
    {   playerPrefsMANAGER.ins_list["comment"] = comment.text; } 

    public void s_action_changed()
    {
        if (Language_Manager.lang == 0) playerPrefsMANAGER.ins_list["SA"] = s_action.options[s_action.value].text;

        if (Language_Manager.lang == 1) playerPrefsMANAGER.ins_list["SAF"] = s_action.options[s_action.value].text; 
    }
    public void s_timeline_changed()
    {
        if (Language_Manager.lang == 0) playerPrefsMANAGER.ins_list["ST"] = s_timeline.options[s_timeline.value].text;

        if (Language_Manager.lang == 1) playerPrefsMANAGER.ins_list["STF"] = s_timeline.options[s_timeline.value].text;
    
    }
    public void s_corrective_action_changed()
    {
        if (Language_Manager.lang == 0) playerPrefsMANAGER.ins_list["SCA"] = s_corrective_action.options[s_corrective_action.value].text;

        if (Language_Manager.lang == 1)  playerPrefsMANAGER.ins_list["SCAF"] = s_corrective_action.options[s_corrective_action.value].text; 
    
    }
    public void s_using_action_changed()
    {
        if (Language_Manager.lang == 0) playerPrefsMANAGER.ins_list["SUA"] = s_using_action.options[s_using_action.value].text;

        if (Language_Manager.lang == 1) playerPrefsMANAGER.ins_list["SUAF"] = s_using_action.options[s_using_action.value].text;
    }
    



}
