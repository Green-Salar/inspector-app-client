using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class popup_unloader : MonoBehaviour
{

    public void unload_poup(){
        //SceneManager.LoadScene("connectiuin");
        SceneManager.UnloadSceneAsync("popup_scene");

    }

}