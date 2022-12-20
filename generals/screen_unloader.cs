using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screen_unloader : MonoBehaviour
{
    public void unload(){
        //SceneManager.LoadScene("connectiuin");
        SceneManager.UnloadSceneAsync("Ins_ID_Scanner");

    }
    public void unload_review(){
        //SceneManager.LoadScene("connectiuin");
        SceneManager.UnloadSceneAsync("Ins_ID_Scanner");

    }

}
