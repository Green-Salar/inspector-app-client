using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class popUp_error : MonoBehaviour
{
    // Start is called before the first frame update
    static GameObject popup;
    void Start()
    {
        popup = GameObject.Find("popup_error");
        popup.SetActive(false);        
    }

    // Update is called once per frame
    void btn_ok()
    {
        popup.SetActive(false);
    }

    public static void error( string err)
    {
        popup.SetActive(true);
        popup.GetComponentInChildren<Text>().text = err;
        
    }
}
