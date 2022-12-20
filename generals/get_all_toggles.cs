using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI; 

public class get_all_toggles : MonoBehaviour
{

public  GameObject parent;
static Transform parentTransform;
public static List<string> toggles_list=new List<string>{}; 
Toggle m_Toggle;
static string toggles_str;


void Awake(){
    parentTransform = parent.transform;
    }

private string togglePrinter(){
    toggles_list=new List<string>{};

    foreach(Transform child in parentTransform) {
            m_Toggle = child.GetComponent<Toggle>();
            
            toggles_str = m_Toggle.GetComponentInChildren<Text>().text;
            //Debug.Log(toggles_str);
            if (m_Toggle.isOn) {
                toggles_list.Add(toggles_str);
            } 
            if (!m_Toggle.isOn) {
                toggles_list.Remove(toggles_str);
            }
    }

    toggles_str="";

    foreach(string i in toggles_list){
            toggles_str += i +", ";
    }

    return toggles_str;

}
    public void save_to_prefs(){
        string defects_str = togglePrinter();
        //Debug.Log(defects_str);
        if(Language_Manager.lang == 0)   
            playerPrefsMANAGER.ins_list["D"] = toggles_str;

        if(Language_Manager.lang == 1 )  
            playerPrefsMANAGER.ins_list["DF"]= toggles_str; 
    }
}
