using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class json2dictClass : MonoBehaviour
{
    
    public string RT,DC,DSC,DU,DP,FD,CD,AD,DD,BD,RS;
    public string ID,Location, SN ,SA, ST, SCA, SUA,comment, img1, img2, img3, img4, img5, img6;

   public void Load(string savedData)
    {
        JsonUtility.FromJsonOverwrite(savedData, this);
        Debug.Log(RT);
    }
}
