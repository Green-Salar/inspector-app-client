using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Report_Manager : MonoBehaviour
{
    public static string review_ID;
    // Start is called before the first frame update
     public static Dictionary<string,dynamic> report_list = new Dictionary<string,dynamic>();


    public GameObject canvas;
    public Button button;

    public void add_to_Report(string insID, Dictionary<string,string> inspection){
        if (report_list.ContainsKey(insID)){
            report_list[insID] = inspection;
        }else{try{
            report_list.Add(insID,inspection);
        }catch{
            Debug.Log("no its not possible");
        }
        } 
        }
    public static void empty_report_list(){
        report_list.Clear();
    }

    public static Dictionary<string,string> get_review_on_insList(){
    return report_list[review_ID];
    }


}

