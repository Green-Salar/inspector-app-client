using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System;
 using System.Runtime.Serialization.Formatters.Binary;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackground;

    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;

    [SerializeField]
    private int _img_num;

    [SerializeField]
    private string _insID, _location, _img_name_str;

    [SerializeField]
    private TextMeshProUGUI _textOut;
    public RawImage imageHolder;
    public int _CaptureCounter = 0;
    Texture2D tex = null;
    byte[] fileBytes;
    private bool _isCamAvailable;
    private WebCamTexture _cameratexture = null;
    private bool _isCamStarted = false;
    [SerializeField]
    GameObject take_btn, retake_btn, save_btn;
    // Start is called before the first frame update
    void Start()
    {
        _img_num = __img_number_handler.img_num;
        SetUpCamera(); 
        _insID = playerPrefsMANAGER.ins_list["ID"];
        _location = playerPrefsMANAGER.ins_list["Location"];
        _img_name_str =_insID + "-" + _location + "-Img" + _img_num;// + ".png";
        
           Debug.Log("camera started and will save as "+_img_name_str );
        retake_btn.SetActive(false);
        save_btn.SetActive(false);

    }
    void Update(){
        _img_num = __img_number_handler.img_num;
        if (!_isCamStarted) SetUpCamera(); 
    }

    // Update is called once per frame
    private void SetUpCamera()
    {
        
        Debug.Log("image number"+ _img_num);
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0){
            
        Debug.Log("Nocameraa");
            _isCamAvailable = false;
            return;
        }
        for(int i = 0 ; i<devices.Length;i++)
        {
            if(devices[i].isFrontFacing == false){
                _cameratexture = new WebCamTexture(devices[i].name);
            }
        }
        if( _cameratexture.width < 100 )
        {
            Debug.Log("toooo small and ZOOMED");
       //     return;
        }
        _isCamStarted = true;
        _cameratexture.Play();
        _rawImageBackground.texture = _cameratexture;
        _isCamAvailable = true;
        _rawImageBackground.material.mainTexture = _cameratexture;
        

        float ratio = (float)_cameratexture.width / (float)_cameratexture.height;
        int orientation = -_cameratexture.videoRotationAngle;
        _rawImageBackground.rectTransform.localEulerAngles = new Vector3(0,0,orientation);
        _aspectRatioFitter.aspectRatio = ratio;
        


    }


    public void OnClickTakePic(){
        take_btn.SetActive(false);
        retake_btn.SetActive(true);
        save_btn.SetActive(true);
        SaveImage();
        _cameratexture.Pause();
    }
    public void OnClickAgain(){
        _cameratexture.Play();
    }

 
     void SaveImage()
     {
        
         //Create a Texture2D with the size of the rendered image on the screen.
         Texture2D texture = new Texture2D(_cameratexture.width, _cameratexture.height);
         // ............... (_cameratexture.width, _cameratexture.height, TextureFormat.ARGB32, false)
         //Save the image to the Texture2D
         texture.SetPixels(_cameratexture.GetPixels());
         texture.Apply();

         ;         //Encode it as a PNG.
         byte[] Image_in_bytes =rotateTexture ( texture,true ).EncodeToPNG();

         //System.IO.File.WriteAllBytes(Application.dataPath + _CaptureCounter.ToString() + ".png", Image_in_bytes);
         ++_CaptureCounter;
         //Save it in a file.
         string path = Application.persistentDataPath + $"/{_img_name_str}" ;
         File.WriteAllBytes(path, Image_in_bytes);
         Debug.Log(path);
         playerPrefsMANAGER.ins_list["img"+_img_num] = _img_name_str;
         //playerPrefsMANAGER.ins_list["img_base64_"+_img_num] = Convert.ToBase64String(Image_in_bytes);
     }
 Texture2D rotateTexture(Texture2D originalTexture, bool clockwise)
     {
         Color32[] original = originalTexture.GetPixels32();
         Color32[] rotated = new Color32[original.Length];
         int w = originalTexture.width;
         int h = originalTexture.height;
 
         int iRotated, iOriginal;
 
         for (int j = 0; j < h; ++j)
         {
             for (int i = 0; i < w; ++i)
             {
                 iRotated = (i + 1) * h - j - 1;
                 iOriginal = clockwise ? original.Length - 1 - (j * w + i) : j * w + i;
                 rotated[iRotated] = original[iOriginal];
             }
         }
 
         Texture2D rotatedTexture = new Texture2D(h, w);
         rotatedTexture.SetPixels32(rotated);
         rotatedTexture.Apply();
         return rotatedTexture;
     }
    public void Load_Image()
    {
        Texture2D tex = new Texture2D(_cameratexture.width, _cameratexture.height);
        Debug.Log("#loading");
        string path = Application.persistentDataPath + "$/{_img_name_str}";
        fileBytes = File.ReadAllBytes(path);
        
        if (fileBytes!=null)Debug.Log("existsbytes");
        if (fileBytes==null)Debug.Log("NOTexistsbytes");
        tex.LoadImage(fileBytes);
        
        if (tex!=null)Debug.Log("existsTex");else Debug.Log("no tex");
        imageHolder.material.mainTexture= tex;
       // imageHolder.GetComponent<Renderer>().material.mainTexture = tex;
       //if (imageHolder.GetComponent<Renderer>()!=null)Debug.Log("exists renderer");

    }
}