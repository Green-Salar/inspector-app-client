using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class safty_image_handler : MonoBehaviour
{
    [SerializeField]
    private RawImage safety_img;
    [SerializeField]
    private Dropdown _safty_dropdown;
    
    void Start(){
        _safty_dropdown.captionText.text = "Select Safety Number";
    } 
    
    public void safty_image_drpdownPrevalues_handeling(){
        int safety_number =  _safty_dropdown.value;
        playerPrefsMANAGER.ins_list["SN"] = safety_number.ToString();
        Color[] _colors = safty_vars.safty_colors;
        safety_img.color = _colors[ safety_number];
        safty_pre_values_handeling(safety_number);
        
        caption_all();
        }
    void caption_all(){
            S_time.re_init();
            S_using.re_init();
            S_unload.re_init();
        }

    public void safty_pre_values_handeling(int _safty_value)   {
        Debug.Log(_safty_value);
            playerPrefsMANAGER.ins_list["SA"] = safty_vars.safty_unloading_action[_safty_value];
            playerPrefsMANAGER.ins_list["ST"] = safty_vars.safty_timeline[8 -_safty_value];
            playerPrefsMANAGER.ins_list["SCA"] = safty_vars.safty_corrective_action[_safty_value];
            playerPrefsMANAGER.ins_list["SUA"] = safty_vars.safty_using_action[_safty_value];

            playerPrefsMANAGER.ins_list["SAF"] = safty_vars.safty_unloading_actionFR[_safty_value];
            playerPrefsMANAGER.ins_list["STF"] = safty_vars.safty_timelineFR[8 -_safty_value];
            playerPrefsMANAGER.ins_list["SCAF"] = safty_vars.safty_corrective_actionFR[_safty_value];
            playerPrefsMANAGER.ins_list["SUAF"] = safty_vars.safty_using_actionFR[_safty_value];

    } 
}
