                                                                                                                                                                                                                                                                                                                                                                                using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


using UnityEngine.SceneManagement;

public class conn_send_in_one_json : MonoBehaviour
{

    void Start()
    {
        
    }
    
    public void send_all_in_one(){
        StartCoroutine(Upload());
        //sql_handler.drop();
    }

    IEnumerator Upload()
    {
        
         SceneManager.LoadScene("loading_scene", LoadSceneMode.Additive);
        string b = sql_handler.send_str_builder();
        
        WWWForm form = new WWWForm();

        //form.AddField("InspectionID", inspectionID);
        form.AddField("all_in_one",b);
        Debug.Log(b);
        using (UnityWebRequest www = UnityWebRequest.Post("http://91.245.254.86:80/test", form)) //"http://91.245.254.86:80/test"  http://localhost:80/test
        {
            yield return www.SendWebRequest();
            Debug.Log(www.result);
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!"+www.result);
                //sql_handler.drop();
                SceneManager.UnloadSceneAsync("loading_scene");
            }
        }
    }

    private string dict_str( Dictionary<string, dynamic> dict1){
                string s="";
                foreach(var kvp in dict1){
                    Debug.Log(kvp.Key);
                    s=s+ kvp.Key + ":" + MyToString2( kvp.Value) +",";
                }
                return "{" + s + "}";
    }
    private string MyToString2(Dictionary<string, string> dictionary)
    {
        
        try{string s=""; 
                foreach(var kvp in dictionary){
                    Debug.Log(kvp.Key);
                    s=s+ kvp.Key+":" + kvp.Value +",";
                }
                

        return "{" + s + "}";

        }catch{return "EROR!";}
    }

}