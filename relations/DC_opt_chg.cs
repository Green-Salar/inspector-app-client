using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DC_opt_chg : MonoBehaviour
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
        caption = "Select Defect Category";
        if (Language_Manager.lang==1 )caption =  "Sélectionnez la catégorie de défaut";
        m_Dropdown.captionText.text = caption;
    }

    public static void changeScript(List<string> m_DropOptions)
    {
        m_Dropdown.interactable = true;
        //Clear the old options of the Dropdown menu
        m_Dropdown.ClearOptions();
        m_DropOptions.Insert(0, caption);
        //Add the options created in the List above
        m_Dropdown.AddOptions(m_DropOptions);
        m_Dropdown.captionText.text = caption;
        DSC_opt_chg.m_Dropdown.interactable = false;
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

        if (selected_txt!=caption)relats.DSCgetter(  RT_val,  selected_txt);

    }

}
