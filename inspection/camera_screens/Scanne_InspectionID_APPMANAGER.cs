using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scanne_InspectionID_APPMANAGER : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI _textOut;
    
    [SerializeField]
    private InputField input_field; 


    void LateUpdate(){
        input_field.text = playerPrefsMANAGER.ins_list["InsID"]; 
    }

    void unload(){
        SceneManager.UnloadSceneAsync("InsIDScanner");
    }

    public void LocationDefiner(){
        //public Dictionary<string, string>  ins_list = 
        playerPrefsMANAGER.ins_list["InsID"] = input_field.text;
        _textOut.text = playerPrefsMANAGER.ins_list["InsID"];
    }

}
