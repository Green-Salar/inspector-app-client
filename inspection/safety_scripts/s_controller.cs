using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class s_controller : MonoBehaviour
{
    [SerializeField]
    private RawImage safety_img;
    static Dropdown m_Dropdown;
    static string caption;
    int m_DropdownValue;
    // Start is called before the first frame update
    void Start()
    {
        m_Dropdown = GetComponent<Dropdown>();
        init();
    }
    void init()
    {
        if (playerPrefsMANAGER.ins_list["SN"] != "-") {
            caption = playerPrefsMANAGER.ins_list["SN"];
            m_Dropdown.captionText.text = caption;
            Color[] _colors = safty_vars.safty_colors;
            safety_img.color = _colors[Int32.Parse(playerPrefsMANAGER.ins_list["SN"])];
        }
    }

    void changeScript(List<string> m_DropOptions)
    {
        m_Dropdown.ClearOptions();
        m_Dropdown.captionText.text = caption;

    }
    void caption_all()
    {
        S_time.re_init();
        S_using.re_init();
        S_unload.re_init();
    }
    public void on_value_changed()
    {
        //Keep the current index of the Dropdown in a variable
        m_DropdownValue = m_Dropdown.value;
        int safety_number = m_Dropdown.value;
        playerPrefsMANAGER.ins_list["SN"] = safety_number.ToString();
        Color[] _colors = safty_vars.safty_colors;
        safety_img.color = _colors[safety_number];
        safty_pre_values_handeling(safety_number);
        caption_all();
    }
    void safty_pre_values_handeling(int _safty_value)
    {
        Debug.Log(_safty_value);
        playerPrefsMANAGER.ins_list["SA"] = safty_vars.safty_unloading_action[_safty_value];
        playerPrefsMANAGER.ins_list["ST"] = safty_vars.safty_timeline[8 - _safty_value];
        playerPrefsMANAGER.ins_list["SCA"] = safty_vars.safty_corrective_action[_safty_value];
        playerPrefsMANAGER.ins_list["SUA"] = safty_vars.safty_using_action[_safty_value];

        playerPrefsMANAGER.ins_list["SAF"] = safty_vars.safty_unloading_actionFR[_safty_value];
        playerPrefsMANAGER.ins_list["STF"] = safty_vars.safty_timelineFR[8 - _safty_value];
        playerPrefsMANAGER.ins_list["SCAF"] = safty_vars.safty_corrective_actionFR[_safty_value];
        playerPrefsMANAGER.ins_list["SUAF"] = safty_vars.safty_using_actionFR[_safty_value];

    }

}
