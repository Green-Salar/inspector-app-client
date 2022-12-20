using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ID_scene_screnmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public void unload(){
        //SceneManager.LoadScene("connectiuin");
        SceneManager.UnloadSceneAsync("Ins_ID_Scanner");

    }
}


