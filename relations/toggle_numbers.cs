using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toggle_numbers : MonoBehaviour
{

    Toggle m_Toggle;
    public Text m_Text;

    void Start()
    {

        m_Toggle = GetComponent<Toggle>();
        m_Toggle.onValueChanged.AddListener(delegate {
        
        ToggleValueChanged(m_Toggle);
        });

        //Initialise the Text to say the first state of the Toggle
        //m_Text.text = "First Value : " + m_Toggle.isOn;
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        if (m_Toggle.isOn)
        {
            m_Toggle.GetComponentInChildren<Text>().text = "hiihaaaaw" + m_Toggle.isOn;
            Toggle_scence_handler.pop_it_up(m_Toggle);
        }
    }
}
