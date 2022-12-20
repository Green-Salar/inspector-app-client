using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class loading_unloader : MonoBehaviour
{
    // Start is called before the first frame update
    public void unload_loading_scence(){
        //SceneManager.LoadScene("connectiuin");
        try { SceneManager.UnloadSceneAsync("loading_scene"); } catch { }
        try { SceneManager.UnloadSceneAsync("SQLerror_scene"); } catch { }

    }
}
