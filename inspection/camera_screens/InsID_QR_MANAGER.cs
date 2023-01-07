using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;


public class InsID_QR_MANAGER : MonoBehaviour
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
    private TextMeshProUGUI _lbl_saved_inspection;
    [SerializeField]
    private RectTransform _scanZone;

    private string temp_insID;
    [SerializeField]
    private InputField _inputfield;

    private bool _isCamAvailable;
    private WebCamTexture _cameratexture;

    // Start is called before the first frame update
    void Start()
    {
        _scanning = true;
        SetUpCamera(); 
        temp_insID = playerPrefsMANAGER.ins_list["ID"];
    }
    
    void Update()
    {
        UpdateCameraRender();
        if (_scanning){
                Scan();
        }
        _textOut.text = "inspection ID: " + temp_insID;
         _lbl_saved_inspection.text = "last saved:" + playerPrefsMANAGER.ins_list["ID"];
    }


    public void save_inspection(){
        if( playerPrefsMANAGER.ins_list["ID"] != temp_insID ){
            for( int i = 1 ; i < 7 ; i++ ) playerPrefsMANAGER.ins_list[ "img" + i ] = "-" ;
        }
        playerPrefsMANAGER.ins_list["ID"] = temp_insID;

    }
    // Update is called once per frame
    public void on_value_changed_inutfield(){
        _scanning = false;
        temp_insID = _inputfield.text;
    }
    private void Scan()
    {
        try{
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(_cameratexture.GetPixels32(),_cameratexture.width,_cameratexture.height);
            if(result !=null){
                update_Inputfield(result.Text);
                temp_insID = result.Text;
            }else{
                temp_insID = "scanning";
            }
        }
        catch{
            temp_insID = "failed";
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
