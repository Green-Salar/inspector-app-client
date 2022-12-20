using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Language_Manager : MonoBehaviour
{

    public static int lang;
    void Start(){
        lang = 0;
    }
    public void Starter()
    {
        SceneManager.LoadScene("Chooser_scene", LoadSceneMode.Additive);
    }
    public void eng()
    {
        Debug.Log("language changed to ENG.");
        lang = 0;
        Starter();
    }
    public void fr()
    {
        Debug.Log("language changed to FR.");
        lang = 1;
        
        Starter();
    }
}
