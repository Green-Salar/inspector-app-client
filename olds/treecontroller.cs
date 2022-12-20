using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class treecontroller : MonoBehaviour
{

    //Create a List of new Dropdown options


    public Dropdown D;
    
    public Dropdown subD;
    
    public Dropdown RT;
    
    void Start()
    {
            List<string> RT_options = new List<string> {
                 "selectif",
                "Drive-in"};
        //Fetch the Dropdown GameObject the script is attached to
        //RT = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        RT.ClearOptions();
        //Add the options created in the List above
        RT.AddOptions(RT_options);
       // D= GetComponent<Dropdown>();
    
        //subD= GetComponent<Dropdown>();
    
    }

    public void DC_dropdown_controller(){

        if(RT.value==0){
            RT_Selectif();    }
    }
    
    public void RT_Selectif(){

    List<string> Selectif = new List<string> {
        "usage",
        "document"};

        D = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        D.ClearOptions();
        //Add the options created in the List above
        D.AddOptions(Selectif);
    }
    public void DSC_dropdown_controller(){
        if(D.value==0){
            Selectif_usage() ; 
        }
        if(D.value==1){
            Selectif_usage()  ;
        }
    }

    public void Selectif_usage(){

        List<string> Selectif_SubD = new List<string> {"pallet","Storage","Racking","Workspace"};
        
               D = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
                D.ClearOptions();
        //Add the options created in the List above
                D.AddOptions(Selectif_SubD);
        
        
        }
    public void Selectif_document(){

        List<string> Selectif_SubD = new List<string> {"Capacity","Racking Layout"};
        
               D = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
                D.ClearOptions();
        //Add the options created in the List above
                D.AddOptions(Selectif_SubD);

        }


    public void toggles_controller(){
        if(subD.value==0){

                    List<string> Selectif_SubD = new List<string> {"AAAA","BBBBB","CCCCCCCC"};
        
        }
    }        
}


