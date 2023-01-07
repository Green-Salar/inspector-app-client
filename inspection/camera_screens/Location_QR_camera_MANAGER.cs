using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;
public class Location_QR_camera_MANAGER : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackground;

    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;

    [SerializeField]
    private bool _scanning;
    [SerializeField]
    private TextMeshProUGUI _textOut;
    [SerializeField]
    private TextMeshProUGUI _lbl_saved_location;
    [SerializeField]
    private RectTransform _scanZone;

    private string loc_str;
    [SerializeField]
    private InputField _inputfield;

    private bool _isCamAvailable;
    private WebCamTexture _cameratexture;
    private bool _isValidaiting,_validator;
    private string temp_loc,temp_loc_validator;

    private float timer = 0.0f;
    private float timer_forTemp_validation = 0.0f, timer_checker;
    // Start is called before the first frame update
    void Start()
    {
        _scanning = true;
        SetUpCamera(); 
        loc_str = playerPrefsMANAGER.ins_list["Location"];
    }
    
    void Update()
    {
        if(_isValidaiting) {
            timer += Time.deltaTime;
             timer_forTemp_validation +=Time.deltaTime;
            //scan_checker();
            }
        UpdateCameraRender();
        if (_scanning){
                Scan();
        }
        _textOut.text =  loc_str;
         _lbl_saved_location.text = "last saved:" + playerPrefsMANAGER.ins_list["Location"];
    }


    public void save_location(){
        if( playerPrefsMANAGER.ins_list["Location"] != loc_str ){
            for( int i = 1 ; i < 7 ; i++ ) playerPrefsMANAGER.ins_list[ "img" + i ] = "-" ;
        }
        playerPrefsMANAGER.ins_list["Location"] = loc_str;
    }
    // Update is called once per frame
    public void on_value_changed_inutfield(){
        loc_str = _inputfield.text;
        _scanning = false;
    }
    void start_validation(){


    }
    private void scan_checker(){

   
    }
    private void Scan()
    {
        try{
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(_cameratexture.GetPixels32(),_cameratexture.width,_cameratexture.height);
            if(result !=null){
                update_Inputfield(result.Text);
                temp_loc = result.Text;
                //start_validation();
            }else{
                loc_str = "scanning";
            }
        }
        catch{
            loc_str = "failed";
        }
        
    }
    public void stop_scaning(){
        _scanning = false;
    }
    public void start_scaning(){
        _scanning = true;
    }

    void update_Inputfield(string txt){
        _inputfield.text = txt;
    }
//felan in cansele
    public void OnClickScan(){
        start_scaning();
    }

    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0){
            _isCamAvailable = false;
            return;
        }
        for(int i = 0 ; i<devices.Length;i++)
        {
            if(devices[i].isFrontFacing == false){
                _cameratexture = new WebCamTexture(devices[i].name,(int)_scanZone.rect.width, (int)_scanZone.rect.height);
            }
        }
        _cameratexture.Play();
        _rawImageBackground.texture = _cameratexture;
        _isCamAvailable = true;
    }


    private void UpdateCameraRender()
    {
        if(_isCamAvailable == false){
            return;
        }
        float ratio = (float)_cameratexture.width / (float)_cameratexture.height;
        _aspectRatioFitter.aspectRatio = ratio;
        int orientation = -_cameratexture.videoRotationAngle;
        _rawImageBackground.rectTransform.localEulerAngles = new Vector3(0,0,orientation);
        
    }

}
