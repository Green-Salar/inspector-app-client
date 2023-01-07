using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerPrefsMANAGER_OLD : MonoBehaviour
{
    //public string[] ins_list;
    [SerializeField]
    public static Dictionary<string, string>  ins_list;
    [SerializeField]
    private Button btn_loc;
    [SerializeField]
    private Button btn_insID;
    [SerializeField]
    private Button btn_img1;
    [SerializeField]
    private Button btn_img2;
    [SerializeField]
    private Button btn_img3;
    // Start is called before the first frame update
    void Start()
    {
        empty_inslist();
    }

    public static void empty_inslist(){           
        ins_list = new Dictionary<string, string> {
            {"ID", "-" },
            {"Location", "-"},
            {"SN","-" },
            {"RT","-"},
            {"DC","-" },
            {"DSC","-"},
            {"DU","-" },
            {"DP","-"},
            {"FD","-"},
            {"CD","-" },
            {"AD","-" },
            {"DD","-"},
            {"BD","-"},
            {"RS","-"},
            {"SA","-"},
            {"ST","-"},
            {"SCA","-"},
            {"SUA","-"},
            {"comment","-"},
            {"img1", "-" },
            {"img2", "-"},
            {"img3", "-" },
            {"img4", "-"},
            {"img5", "-"},
            {"img6", "-"},
            {"img_base64_1", "-" },
            {"img_base64_2", "-"},
            {"img_base64_3", "-" },
            {"img_base64_4", "-"},
            {"img_base64_5", "-"},
            {"img_base64_6", "-"},
            {"json", "-"}
        };

    }

    // Update is called once per frame
    void Update()
    {
        btn_text_handler();
    }
    
    public void SetString(string KeyName, string Value)
    {
        PlayerPrefs.SetString(KeyName, Value);
        PlayerPrefs.Save();
    }

    public string GetString(string KeyName)
    {
        return PlayerPrefs.GetString(KeyName);
    }
    void btn_text_handler(){
        btn_loc.GetComponentInChildren<Text>().text  = "Location:" + ins_list["Location"];
        
        btn_insID.GetComponentInChildren<Text>().text  = "Inspection ID:" + ins_list["ID"] ;
        
        btn_img1.GetComponentInChildren<Text>().text = "img1:" + ins_list["img1"];

        btn_img2.GetComponentInChildren<Text>().text = "img2:" + ins_list["img2"];

        btn_img3.GetComponentInChildren<Text>().text = "img3:" + ins_list["img3"];
        
 
    }

}
