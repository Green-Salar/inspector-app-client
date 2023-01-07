using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class S_time : MonoBehaviour
{
    List<string> m_DropOptions = new List<string> { };

    static Dropdown m_Dropdown;
    static string caption;
    int m_DropdownValue;
    // Start is called before the first frame update
    void Start()
    {
        m_Dropdown = GetComponent<Dropdown>();
        init();
    }

    // Update is called once per frame
    void init()
    {
        if (Language_Manager.lang == 0)
        {
            caption = "action timeline: ";
            caption += playerPrefsMANAGER.ins_list["ST"];
            changeScript(safty_vars.safty_timeline);
        }
        if (Language_Manager.lang == 1)
        {
            caption = "Temps d'intervation: ";
            caption += playerPrefsMANAGER.ins_list["STF"];
            changeScript(safty_vars.safty_timelineFR);
        }
    }
    static void changeScript(List<string> m_DropOptions)
    {
        //Clear the old options of the Dropdown menu
        m_Dropdown.ClearOptions();

        //Add the options created in the List above
        m_Dropdown.AddOptions(m_DropOptions);
        //clear_children.Clear_toggleParent();

        m_Dropdown.captionText.text = caption;
    }
    // Update is called once per frame
    public void on_value_changed()
    {
        //Keep the current index of the Dropdown in a variable
        m_DropdownValue = m_Dropdown.value;

        if (Language_Manager.lang == 0) {
            playerPrefsMANAGER.ins_list["ST"] = m_Dropdown.options[m_Dropdown.value].text;
            playerPrefsMANAGER.ins_list["STF"] = safty_vars.safty_timelineFR[m_Dropdown.value];
        }

        if (Language_Manager.lang == 1) { 
            playerPrefsMANAGER.ins_list["STF"] = m_Dropdown.options[m_Dropdown.value].text;
            playerPrefsMANAGER.ins_list["ST"] = safty_vars.safty_timeline[m_Dropdown.value];
        }
    }
    public static void re_init()
    {
        if (Language_Manager.lang == 0)
        {
            
            caption = playerPrefsMANAGER.ins_list["ST"];
            m_Dropdown.captionText.text = caption;
        }
        if (Language_Manager.lang == 1)
        {
            caption = playerPrefsMANAGER.ins_list["STF"];
            m_Dropdown.captionText.text = caption;
        }
    }
}
