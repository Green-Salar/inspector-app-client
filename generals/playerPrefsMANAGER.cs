using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerPrefsMANAGER : MonoBehaviour
{
    //public string[] ins_list;
    [SerializeField]
    public static Dictionary<string, string>  ins_list;
    [SerializeField]
    private Button btn_loc,btn_insID,btn_img1,btn_img2,btn_img3,btn_img4,btn_img5,btn_img6;
    [SerializeField]
    private Button btn_locFR,btn_insIDFR,btn_img1FR,btn_img2FR,btn_img3FR,btn_img4FR,btn_img5FR,btn_img6FR;
[SerializeField]
public static List<string> Defects_list=new List<string>{}; 
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
            {"DSC","Frame"},
            {"D","-" },
            {"RS","-"},
            {"SA","-"},
            {"ST","-"},
            {"SCA","-"},
            {"SUA","-"},
            {"comment","-"},

            {"RTF","-"},
            {"DCF","-" },
            {"DSCF","-"},
            {"DF","-" },
            {"RSF","-"},
            {"SAF","-"},
            {"STF","-"},
            {"SCAF","-"},
            {"SUAF","-"},
            {"commentF","-"},

            {"img1", "-" },
            {"img2", "-"},
            {"img3", "-" },
            {"img4", "-"},
            {"img5", "-"},
            {"img6", "-"},
            {"json", "-"},
            {"lang",Language_Manager.lang.ToString()}
        };
    }

    // Update is called once per frame
    void Update()
    {
        btn_text_handler();
        btn_text_handlerFR();
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
        try{ 
        btn_loc.GetComponentInChildren<Text>().text  = "Location:" + ins_list["Location"];
        
        btn_insID.GetComponentInChildren<Text>().text  = "Inspection ID:" + ins_list["ID"] ;
         
        btn_img1.GetComponentInChildren<Text>().text = "img1:" + ins_list["img1"];

        btn_img2.GetComponentInChildren<Text>().text = "img2:" + ins_list["img2"];

        btn_img3.GetComponentInChildren<Text>().text = "img3:" + ins_list["img3"];
        
        
        btn_img4.GetComponentInChildren<Text>().text = "img4:" + ins_list["img4"];

        btn_img5.GetComponentInChildren<Text>().text = "img5:" + ins_list["img5"];

        btn_img6.GetComponentInChildren<Text>().text = "img6:" + ins_list["img6"];
        }catch{}

 
    }
    void btn_text_handlerFR(){
        try{ 
        btn_locFR.GetComponentInChildren<Text>().text  = "lieu:" + ins_list["Location"];
        
        btn_insIDFR.GetComponentInChildren<Text>().text  = "id de inspection:" + ins_list["ID"] ;
        
        btn_img1FR.GetComponentInChildren<Text>().text = "img1:" + ins_list["img1"];

        btn_img2FR.GetComponentInChildren<Text>().text = "img2:" + ins_list["img2"];

        btn_img3FR.GetComponentInChildren<Text>().text = "img3:" + ins_list["img3"];
        
        
        btn_img4FR.GetComponentInChildren<Text>().text = "img4:" + ins_list["img4"];

        btn_img5FR.GetComponentInChildren<Text>().text = "img5:" + ins_list["img5"];

        btn_img6FR.GetComponentInChildren<Text>().text = "img6:" + ins_list["img6"];
        }catch{}
 
    }

}
