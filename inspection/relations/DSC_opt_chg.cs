using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DSC_opt_chg : MonoBehaviour
{
    //Create a List of new Dropdown options
    List<string> m_DropOptions = new List<string> { };

    public static Dropdown m_Dropdown;
    public static string selected_txt;
    static string caption;
    int m_DropdownValue;
    void Awake()
    {
        m_Dropdown = GetComponent<Dropdown>();
        m_Dropdown.interactable = false;
        caption = "Sélectionnez la sous-catégorie de défaut";
        if (Language_Manager.lang==0 )caption = "Select Defect Sub Category";
        m_Dropdown.captionText.text = caption;
    }

    public static void changeScript(List<string> m_DropOptions)
    {
        m_Dropdown.ClearOptions();
        m_Dropdown.interactable = true;
        m_DropOptions.Insert(0, caption);
        m_Dropdown.AddOptions(m_DropOptions);
        //Add the options created in the List above
        clear_children.Clear_toggleParent();
    }
    public void on_value_changed()
    {
        //Keep the current index of the Dropdown in a variable
        m_DropdownValue = m_Dropdown.value;
        //Change the message to say the name of the current Dropdown selection using the value
        selected_txt = m_Dropdown.options[m_DropdownValue].text;
        //Change the onscreen Text to reflect the current Dropdown selection
        string RT_val =  RT_opt_chg.selected_txt;
        string DC_val = DC_opt_chg.selected_txt;
        //Change the message to say the name of the current Dropdown selection using the value
        if (selected_txt!=caption)Defectgetter(  RT_val,  DC_val,selected_txt );
        //Change the onscreen Text to reflect the current Dropdown selection
        
    }
    static string sqlQuery;
    void Defectgetter(string RT, string DC,string DSC){
    sqlQuery = "Select D from " + relats.tableName + " where  RT = '" + RT + "'AND DC = '" + DC + "'AND DSC = '" + DSC + "';";
    if (Language_Manager.lang==1) sqlQuery = "Select DF from " + relats.tableName + " where  RTF = '" + RT + "'AND DCF = '" + DC + "'AND DSCF = '" + DSC + "';";

    List<string> defect_list =  relats.sqliteExecuter(sqlQuery);

    clear_children.Clear_toggleParent();

    foreach(string i in defect_list){
        Instantiator(i);
    }
    }

    public  GameObject canvas;
    public GameObject toggle;
    
    void Clear_toggleParent(){
        foreach(Transform child in canvas.transform) {
        Destroy(child.gameObject);
        }
    }
    void Instantiator (string i ) {

        GameObject newtoggle = Instantiate(toggle) as GameObject;
        try{newtoggle.GetComponentInChildren<Text>().text = i;}catch{Debug.Log("failed to name toggle");}
        newtoggle.transform.SetParent(canvas.transform, false);
        if (i[0] == '#') {
            Toggle _Toggle = newtoggle.GetComponent<Toggle>();
            _Toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(_Toggle);
            });
        }
    }
    void ToggleValueChanged(Toggle _Toggle)
    {
        if (_Toggle.isOn)
        {
            //_Toggle.GetComponentInChildren<Text>().text = "hiihaaaaw" + _Toggle.isOn;
            Toggle_scence_handler.pop_it_up(_Toggle);
        }
    }


}
