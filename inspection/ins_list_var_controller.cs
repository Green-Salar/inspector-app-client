using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ins_list_var_controller : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Dropdown RT,DC,DSC;

    //Ouput the new value of the Dropdown into Text
    void Start()
    {
      if(Language_Manager.lang == 0)  _initializer_EN();
      if(Language_Manager.lang == 1 ) _initializer_FR();
       
    }
    

    void _initializer_EN(){
      if ( playerPrefsMANAGER.ins_list["RT"] !="-"){
        RT.captionText.text = "Racking Type: "+playerPrefsMANAGER.ins_list["RT"] ;
      };
      if ( playerPrefsMANAGER.ins_list["DC"] !="-"){
        DC.captionText.text = "defect Category: "+ playerPrefsMANAGER.ins_list["DC"] ;
      };
       if (playerPrefsMANAGER.ins_list["DSC"] !="-"){
        DSC.captionText.text = "Defect Sub Category: "+playerPrefsMANAGER.ins_list["DSC"];
       };
      if ( playerPrefsMANAGER.ins_list["D"] !="-"){
        //D.options[D.value].text = "Defect Protect: "+playerPrefsMANAGER.ins_list["DP"] ;
      };
    }
        void _initializer_FR(){
      if ( playerPrefsMANAGER.ins_list["RTF"] !="-"){
        RT.captionText.text = "Racking Type: "+playerPrefsMANAGER.ins_list["RTF"];
        };
      if ( playerPrefsMANAGER.ins_list["DCF"] !="-"){
        DC.captionText.text = "defect Category: "+ playerPrefsMANAGER.ins_list["DCF"] ;
      };
       if (playerPrefsMANAGER.ins_list["DSCF"] !="-"){
        DSC.captionText.text = "Defect Sub Category: "+playerPrefsMANAGER.ins_list["DSCF"];
       };
      if ( playerPrefsMANAGER.ins_list["DF"] !="-"){
        //DF.options[DF.value].text = "Defect Protect: "+playerPrefsMANAGER.ins_list["DF"] ;
      };
    }

    public void RT_changed()
    {

        if (Language_Manager.lang == 1) playerPrefsMANAGER.ins_list["RTF"] = RT.options[RT.value].text;
        if (Language_Manager.lang == 0) playerPrefsMANAGER.ins_list["RT"] = RT.options[RT.value].text; }
    
    public void DC_changed()
    {
        if (Language_Manager.lang == 1) playerPrefsMANAGER.ins_list["DCF"] = DC.options[DC.value].text;
        if (Language_Manager.lang == 0) playerPrefsMANAGER.ins_list["DC"] = DC.options[DC.value].text; }

    public void DSC_changed()
    {   if (Language_Manager.lang == 1) playerPrefsMANAGER.ins_list["DSCF"] = DSC.options[DSC.value].text;
        if (Language_Manager.lang == 0)playerPrefsMANAGER.ins_list["DSC"] = DSC.options[DSC.value].text;
    }
    
}
