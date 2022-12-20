using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ver2 : MonoBehaviour
{
    public Transform[] Transforms;
    public  Dropdown RT;
    public  Dropdown DC;
    public  Dropdown DSC;
    public  Dropdown DU;
    public  Dropdown DP;
    public  Dropdown FD;
    public  Dropdown CD;
    public  Dropdown AD;
    public  Dropdown DD;
    public  Dropdown BD;
    public  Dropdown RS;
  public void print () {
        Dictionary<string, string> InspectionDict = new Dictionary<string, string>();
        //RT = GetComponent<Dropdown>();
        foreach (var trns in Transforms)
        {

            if (trns.name == "Comment"){ 
                InspectionDict.Add(trns.name,trns.GetComponent<InputField>().text);

            }else{
                InspectionDict.Add(trns.name,trns.GetComponent<Dropdown>().options[RT.value].text);
            
            }
        }


        //RT = Transforms[0].GetComponent<Dropdown>();
        //Debug.Log(RT.options[RT.value].text);
		
foreach(var kvp in InspectionDict)
    Debug.Log("Key: {0}, Value: {1}"+ kvp.Key+ kvp.Value);

}
}