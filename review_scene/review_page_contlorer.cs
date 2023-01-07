
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;
public class review_page_contlorer : MonoBehaviour
{
        // Start is called before the first frame update
    Dictionary<string, string> dict4rev;
    [SerializeField]
    private Text textfield;

    [SerializeField]
    private InputField comment;
    [SerializeField]
    private Dropdown RT,DC,DSC,DU,DP,FD,CD,AD,DD,BD,RS;
    //public Text m_Text;
    [SerializeField]
    private Dropdown s_action,s_timeline,s_corrective_action,s_using_action;
    Texture2D tex = null;
    byte[] fileBytes;
    [SerializeField]
    private Image[] img;
    private string insID;
    void Start()
    {   insID = Report_Manager.review_ID;

        dict4rev = new Dictionary<string, string>(Report_Manager.get_review_on_insList());        
        textfield.text = dict4rev["ID"];
        for(int i = 0 ; i < 6 ; i ++){
            string _img_name_str =dict4rev[$"img{i+1}"];
            Load_Image_review(_img_name_str,i);
        }
        _initializer();
    }
        
        
        
        
        
        
        
        
        
        
        
        public void Load_Image_review(string _img_name_str,int imgNum)
    {

        try{
        string path = Application.persistentDataPath +$"/{_img_name_str}";
        Texture2D texture = new Texture2D(500, 500, TextureFormat.RGB24, false);
        Debug.Log(path);
        texture.filterMode = FilterMode.Point;
        //string path = Application.persistentDataPath + $"{stage}/{fileName}";
        //  $"{stage}/{fileName}"
        byte[]  text = File.ReadAllBytes(path);
        texture.LoadImage(text);
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f, 1, SpriteMeshType.FullRect);
        img[imgNum].sprite = newSprite;
          }catch(Exception e) { 
              Debug.Log("no image number."+imgNum+"-"+e.ToString());
          }    
    } 
    




    public void Save(){
      _add_to_Report( dict4rev["ID"], dict4rev);
      SceneManager.UnloadSceneAsync("review_scene");
    }

    void _add_to_Report(string insID, Dictionary<string,string> inspection){
              if (Report_Manager.report_list.ContainsKey(insID)){
           Report_Manager.report_list[insID] = inspection;
        }else{
        Report_Manager.report_list.Add(insID,inspection);
        // add_btn_insIDS(insID);
        }
    }
    void _initializer(){
      if (  dict4rev["RT"] !="-"){
        RT.options[RT.value].text = "Racking Type: "+ dict4rev["RT"] ;
      };
      if (  dict4rev["DC"] !="-"){
        DC.options[DC.value].text = "defect Category: "+  dict4rev["DC"] ;
      };
       if ( dict4rev["DSC"] !="-"){
        DSC.options[DSC.value].text = "Defect Sub Category: "+ dict4rev["DSC"];
       };
      if (  dict4rev["DU"] !="-"){
        DU.options[DU.value].text = "Defect Use: "+ dict4rev["DU"] ;
      };
      if (  dict4rev["DP"] !="-"){
        DP.options[DP.value].text = "Defect Protect: "+ dict4rev["DP"] ;
      };
      if (  dict4rev["FD"] !="-"){
        FD.options[FD.value].text = "Frame Damage: "+  dict4rev["FD"] ;
      };
      if (  dict4rev["CD"] !="-"){
        CD.options[CD.value].text = " Conception Defect: " + dict4rev["CD"] ;
      };
      if (  dict4rev["AD"] !="-"){
        AD.options[AD.value].text = "Assembly Defect: " +  dict4rev["AD"] ;
      };
      if (  dict4rev["DD"] !="-"){
        DD.options[DD.value].text = "Document Defect: "+ dict4rev["DD"] ;
      };
      if (  dict4rev["BD"] !="-"){
        BD.options[BD.value].text = "Beam Defect: "+  dict4rev["BD"] ;
      };
      if (  dict4rev["RS"] !="-"){
        RS.options[RS.value].text = "Recomended solution: "+ dict4rev["RS"] ;
      };
            if (  dict4rev["comment"] !="-"){
        comment.text = "Comment: "+ dict4rev["comment"] ;
      };
      if (  dict4rev["AD"] !="-"){
        AD.options[AD.value].text = "Assembly Defect: " +  dict4rev["AD"] ;
      };
      if (  dict4rev["DD"] !="-"){
        DD.options[DD.value].text = "Document Defect: "+ dict4rev["DD"] ;
      };
      if (  dict4rev["BD"] !="-"){
        BD.options[BD.value].text = "Beam Defect: "+  dict4rev["BD"] ;
      };
      if (  dict4rev["RS"] !="-"){
        RS.options[RS.value].text = "Recomended solution: "+ dict4rev["RS"] ;
      };

      if (  dict4rev["SA"] !="-"){
         s_action.options[0].text = "S_action: " +  dict4rev["SA"]  ;
      };
      if (  dict4rev["ST"] !="-"){
         s_timeline.options[0].text = "S_timeline: "+ dict4rev["ST"]  ;
      };
      if (  dict4rev["SCA"] !="-"){
        s_corrective_action.options[0].text = "S_corrective: "+  dict4rev["SCA"]  ;
      };
      if (  dict4rev["SUA"] !="-"){
         s_using_action.options[0].text = "S_using: "+ dict4rev["SUA"] ;
      };

      
    }
    public void dropdown_Changer(Dropdown drp,string str){ 
        string choosen =  drp.options[drp.value].text;
         dict4rev[str] = choosen;
    }
    public void RT_changed()
    {    dict4rev["RT"] = RT.options[RT.value].text; }
    
    public void DC_changed()
    {    dict4rev["DC"] = DC.options[DC.value].text; }

    public void DSC_changed()
    {    dict4rev["DSC"] = DSC.options[DSC.value].text; }

    public void DU_changed()
    {    dict4rev["DU"] = DU.options[DU.value].text; }

    public void DP_changed()
    {    dict4rev["DP"] = DP.options[DP.value].text; }

    public void FD_changed()
    {    dict4rev["FD"] = FD.options[FD.value].text; }

    public void CD_changed()
    {    dict4rev["CD"] = CD.options[CD.value].text; }

    public void AD_changed()
    {    dict4rev["AD"] = AD.options[AD.value].text; }

    public void DD_changed()
    {    dict4rev["DD"] = DD.options[DD.value].text; }

    public void BD_changed()
    {    dict4rev["BD"] = BD.options[BD.value].text; }

    public void RS_changed()
    {    dict4rev["RS"] = RS.options[RS.value].text; } 
    public void Comment_changed()
    {    dict4rev["comment"] = comment.text; } 

    public void s_action_changed()
    {    dict4rev["SA"] = s_action.options[s_action.value].text; }
    public void s_timeline_changed()
    {    dict4rev["ST"] = s_timeline.options[s_timeline.value].text; }
    public void s_corrective_action_changed()
    {     dict4rev["SC"] = s_corrective_action.options[s_corrective_action.value].text; }
    public void s_using_action_changed()
    {     dict4rev["SUA"] = s_using_action.options[s_using_action.value].text;}
}
