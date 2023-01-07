using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen_Manager : MonoBehaviour
{
    
    public static int img_num_working_on;
    //public string insID;
    void awake(){
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //insID = PlayerPrefs.GetString("insID");
        //Debug.Log("insID from start void:"+insID);
    }
    public void load_location_scanner(){
        Debug.Log("loading location scanner");
        SceneManager.LoadScene("LocationScanner", LoadSceneMode.Additive);
    }
    public void load_ID_scanner(){
        
        Debug.Log("loading id scanner");
        SceneManager.LoadScene("Ins_ID_Scanner", LoadSceneMode.Additive);
    }
public void load_ins(){
    SceneManager.LoadScene("ins_page1", LoadSceneMode.Additive);
}
    public void camera_screen(){
        SceneManager.LoadScene("Camera_test", LoadSceneMode.Additive);
    }
    public void Unload_camera(){
        //SceneManager.LoadScene("connectiuin");
        SceneManager.UnloadSceneAsync("Camera_test");

    }
    public void save_and_continue(){    
        SceneManager.LoadScene("ins_page2", LoadSceneMode.Additive);
    }
    public void save_and_continue_2_to_3(){    
        Debug.Log("save_and_continue");
        SceneManager.LoadScene("ins_page3", LoadSceneMode.Additive);
    }
    public void unload_ins_page2(){
        SceneManager.UnloadSceneAsync("ins_page2");

    }public void unload_ins_page1(){
        SceneManager.UnloadSceneAsync("ins_page1");

    }public void unload_ins_page3(){
        SceneManager.UnloadSceneAsync("ins_page3");
        Debug.Log("ok");
    }
    public void Save_and_load_reportPage(){
        Report_Manager.report_list.Add(playerPrefsMANAGER.ins_list["ID"],playerPrefsMANAGER.ins_list);
    unload_ins_page1();unload_ins_page2();unload_ins_page3();}
    

            public void popup(){    
        Debug.Log("save_and_continue");
        SceneManager.LoadScene("popup_scene", LoadSceneMode.Additive);
    }
    public void loading(){   
        SceneManager.LoadScene("loading_scene", LoadSceneMode.Additive);
    }
    public static void sqlerror()
    {
        SceneManager.LoadScene("SQLerror_scene", LoadSceneMode.Additive);
    }
    public void review()
    {
        SceneManager.LoadScene("review", LoadSceneMode.Additive);
    }
    public void unload_review()
    {
        SceneManager.UnloadSceneAsync("review");
    }
    public static void load_loading()
    {

        SceneManager.LoadScene("loading_scene", LoadSceneMode.Additive);

    }
    public static void unload_loading()
    {

        SceneManager.UnloadSceneAsync("loading_scene");

    }
    public void unload_loading_scene_appmanager(){    
        SceneManager.UnloadSceneAsync("loading_scene");
    }
    public void unload_popup(){
        Debug.Log("back ");
        //SceneManager.LoadScene("connectiuin");
        SceneManager.UnloadSceneAsync("popup_scene");

    }
}
