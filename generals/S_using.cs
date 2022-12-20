using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_using : MonoBehaviour
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
    void init()
    {
        if (Language_Manager.lang == 0)
        {
            caption = "Using action: ";
           caption += playerPrefsMANAGER.ins_list["SUA"];
            changeScript(safty_vars.safty_using_action);
        }
        if (Language_Manager.lang == 1)
        {
            caption = "Action d'utilisation: ";
            caption += playerPrefsMANAGER.ins_list["SUAF"];
            changeScript(safty_vars.safty_using_actionFR);
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
            playerPrefsMANAGER.ins_list["SUA"] = m_Dropdown.options[m_Dropdown.value].text;

            playerPrefsMANAGER.ins_list["SUAF"] = safty_vars.safty_using_actionFR[m_Dropdown.value];
        }
        //
        if (Language_Manager.lang == 1) { 
            playerPrefsMANAGER.ins_list["SUA"] = safty_vars.safty_using_action[m_Dropdown.value];
            playerPrefsMANAGER.ins_list["SUAF"] = m_Dropdown.options[m_Dropdown.value].text;

        }
    }
    public static void re_init()
    {
        if (Language_Manager.lang == 0)
        {
            caption = playerPrefsMANAGER.ins_list["SUA"];
            m_Dropdown.captionText.text = caption;
        }
        if (Language_Manager.lang == 1)
        {
            caption = playerPrefsMANAGER.ins_list["SUAF"];
            m_Dropdown.captionText.text = caption;
        }
    }
}
