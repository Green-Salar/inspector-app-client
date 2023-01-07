using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooser_scence_lang_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Change_lang();
    }

    // Update is called once per frame
    public static void Change_lang()
    {
       if (Language_Manager.lang == 0) {
        GameObject.Find("English").SetActive(true);
        
        GameObject.Find("French").SetActive(false);
       }
        if (Language_Manager.lang == 1) {
        GameObject.Find("English").SetActive(false);
        
        GameObject.Find("French").SetActive(true);
       }
    }
    public void en2fr(){
        Language_Manager.lang = 1;
        Change_lang();
    }
    
    public void fr2en(){
        Language_Manager.lang = 0;
        Change_lang();
        
    }
}
