using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scanner_scrn_Manager : MonoBehaviour
{
    public void unload(){
        //SceneManager.LoadScene("connectiuin");
        SceneManager.UnloadSceneAsync("LocationScanner");

    }

}
