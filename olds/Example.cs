using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    //Create a List of new Dropdown options
    List<string> m_DropOptions = new List<string> {
"Remain in service",
"Remain in service",
"Remain in service",
"In service during action timeline",
"In service during action timeline",
"In service during action timeline",
"Put out of service",
"Put out of service",
"Put out  of service",}
;
    Dropdown m_Dropdown;
    void Start()
    {
        //Fetch the Dropdown GameObject the script is attached to
        m_Dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        m_Dropdown.ClearOptions();
        //Add the options created in the List above
        m_Dropdown.AddOptions(m_DropOptions);
    }
}