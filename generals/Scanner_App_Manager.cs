using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Scanner_App_Manager : MonoBehaviour
{
        [SerializeField]
    private TextMeshProUGUI _textOut;
    
    [SerializeField]
    private InputField input_field; 

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LocationDefiner(){
        //public Dictionary<string, string>  ins_list = 
        playerPrefsMANAGER.ins_list["Location"] = input_field.text;
        _textOut.text = playerPrefsMANAGER.ins_list["Location"];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
