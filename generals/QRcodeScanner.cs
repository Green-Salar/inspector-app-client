using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;
public class QRcodeScanner : MonoBehaviour
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
    private RectTransform _scanZone;

    
    [SerializeField]
    private InputField _inputfield;

    private bool _isCamAvailable;
    private WebCamTexture _cameratexture;

    // Start is called before the first frame update
    void Start()
    {
        _scanning = true;
           SetUpCamera(); 
    }
    void Update()
    {
        
        UpdateCameraRender();
        if (_scanning){
                Scan();
        }
        
    }

    // Update is called once per frame
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

    private void Scan()
    {
        try{
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(_cameratexture.GetPixels32(),_cameratexture.width,_cameratexture.height);
            if(result !=null){
                _textOut.text = result.Text;
                update_Inputfield(result.Text);
            }else{
                _textOut.text = " FAILED TOTREAD QR QODE";
            }
        }
        catch{
            _textOut.text = " Failed in tryy!";
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
