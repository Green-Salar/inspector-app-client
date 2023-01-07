                                                                                                                                                                                                                                                                                                                                                                                using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ZXing;
using TMPro;
using System;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine.SceneManagement;

public class conn_img_uploader : MonoBehaviour
{
    // Start is called before the first frame update

    static int err_check = 0;
    public void takePic(){
        
        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width-100, height-100), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();


         string path = Application.persistentDataPath + $"/ow2.png" ;
         File.WriteAllBytes(path, bytes);
         Debug.Log(path);
    }


    
    public void savePic(){

    }

        public async void OnStartButtonClick()
        {
        Screen_Manager.load_loading();
            Dictionary<string,Dictionary<string,string>  > imgs_dict = sql_handler.sql_imgs_dictionaries();
            foreach(var kvp in imgs_dict){
                await Upload(kvp.Key , kvp.Value );
                Debug.Log("errr ==>> check ==>> " + err_check.ToString());
            
                }
        if (err_check == 0) { Screen_Manager.unload_loading(); Debug.Log("shod?"); }
            
        }
        async Task Upload(string ID, Dictionary<string,string> img_names)
        {

            foreach (var kvp in img_names)
            {
                if (kvp.Value != "-") 
                { 
                        int contentLength = await UploadTask(ID, kvp.Key, kvp.Value); 
                        Debug.Log(" from upload task"+kvp.Key+"_ID:"+ID+"_result:"+contentLength.ToString());
                        err_check = err_check + contentLength;
                }
            }

        }

        async Task<int>  UploadTask(  string id, string img_num,string _img_name) 
        {

            string path = Application.persistentDataPath + $"/{_img_name}" ;
            Debug.Log(path);
            byte[]  text;

            try{
                text = File.ReadAllBytes(path);
            }catch{
                Debug.Log("img read error/maybe not entered");
                return 1;
            }

            string strImg = Convert.ToBase64String(text);
            WWWForm form = new WWWForm();
            
            form.AddField("id", id);
            form.AddField("name", _img_name);
            form.AddField("base64img", strImg);
        
            using (UnityWebRequest www = UnityWebRequest.Post("http://91.245.254.86:80/img", form)) //"http://91.245.254.86:80/test"
            {
                AsyncOperation asyncOperation = www.SendWebRequest();
                while(!asyncOperation.isDone){
                        //Debug.Log("waiting");
                }
                Debug.Log(www.result);
                if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.Log(www.error);
                
                return 1;
                    }
                else
                    {
                        Debug.Log("Form upload complete!"+www.result);
                
                       // try{File.Delete(path);  } catch{Debug.Log("couldnt delet pic");}
                
                return 0;
                    }
        }

        }


}
