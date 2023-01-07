using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Toggle_scence_handler : MonoBehaviour
{
    static GameObject popup;
     InputField input_field;
    static Toggle m_toggle;
    // Start is called before the first frame update
    void Start()
    {
        popup = GameObject.Find("popup");
        popup.SetActive(false);
    }

    static public void pop_it_up(Toggle _toggle)
    {
        m_toggle = _toggle;
        //SceneManager.LoadScene("defect_number_scene", LoadSceneMode.Additive);
        popup.SetActive(true);
        string placeholder = m_toggle.GetComponentInChildren<Text>().text;
        if (placeholder.Contains("]")){ placeholder = placeholder.Split("[")[1].Split("]")[0]; } else { placeholder = ""; }
        popup.GetComponentInChildren<InputField>().text = placeholder;
    }
    public void get_number()
    {
        string togletxt = m_toggle.GetComponentInChildren<Text>().text;
        if(togletxt.Contains("]"))  togletxt = "#"+ togletxt.Split("]")[1];
        input_field = popup.GetComponentInChildren<InputField>();
        string numbers = input_field.text;
        numbers = "[" + numbers + "]";
        popup.SetActive(false);
        m_toggle.GetComponentInChildren<Text>().text = togletxt.Insert( 1, numbers) ;
    }

}
