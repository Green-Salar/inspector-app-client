using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


public class conn : MonoBehaviour
{

    public  Dropdown RT;
    public  string inspectionID; 
    public Transform[] Transforms;
    void Start()
    {
        inspectionID = "InsID11111";
    }
    public void send(){
        StartCoroutine(Upload());
    }
    IEnumerator Upload()
    {
        Dictionary<string, string> a = getDict();
        string b = MyToString(a);
        WWWForm form = new WWWForm();

        foreach(var kvp in a){
            
        form.AddField(kvp.Key, kvp.Value);
        form.AddField("InspectionID", inspectionID);
        }
        //form.AddField("myField", b);
        Debug.Log(b);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/test", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!"+www.result);
            }
        }
    }


    private string MyToString(Dictionary<string, string> dictionary)
    {
        
        try{string s=""; 
                foreach(var kvp in dictionary){
                    Debug.Log(kvp.Key);
                    s=s+ kvp.Key+":" + kvp.Value +",";
                }
                

                return "{" + s + "}";

        }catch{return "didi goozidi?";}
    }


    private Dictionary<string, string> getDict () {
        Dictionary<string, string> InspectionDict = new Dictionary<string, string>();
        //RT = GetComponent<Dropdown>();
        foreach (var trns in Transforms)
        {

            if (trns.name == "Comment"){ 
                InspectionDict.Add(trns.name,trns.GetComponent<InputField>().text);

            }else{
                InspectionDict.Add(trns.name,trns.GetComponent<Dropdown>().options[trns.GetComponent<Dropdown>().value].text);
            
            }
        }

        return InspectionDict;
        //RT = Transforms[0].GetComponent<Dropdown>();
        //Debug.Log(RT.options[RT.value].text);
		
   //     foreach(var kvp in InspectionDict)
   //      Debug.Log("Key: {0}, Value: {1}"+ kvp.Key+ kvp.Value);

    }
}