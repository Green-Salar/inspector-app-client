using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class loadPNG : MonoBehaviour
{
    public RawImage rawimage;
          Texture2D thisTexture;
      byte[] bytes;
      string fileName;
     public GameObject[] ImageHolder = new GameObject[1];
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void load(){
        Debug.Log("#loading");
        string path = Application.persistentDataPath + "testimg.png";
        //rawimage.texture = LoadPNG(path);
        Texture2D imgLoaded = LoadPNG(path);
        var rawTex = imgLoaded.GetPixels32();
        
        var destTex = new Texture2D(imgLoaded.width,imgLoaded.height);
        destTex.SetPixels32(rawTex);
        destTex.Apply();
        rawimage.material.color = Color.red;
        rawimage.material.mainTexture = destTex;
        //rawimage.material.mainTexture = LoadPNG(path);
        //rawimage.texture.SetPixels(LoadPNG(path).GetPixels());
         //rawimage.texture.Apply();
    }
    private static Texture2D LoadPNG(string filePath)
{

            Texture2D tex = null;
            byte[] fileBytes;

            if (File.Exists(filePath))
            {
                Debug.Log("#exist");
                fileBytes = File.ReadAllBytes(filePath);
                tex = new Texture2D(900, 900);
                tex.LoadImage(fileBytes); //..this will auto-resize the texture dimensions.
            }
            return tex;
}


      void _____sampleLoadStart()
      {
          
          string[] ImageNames = { "Image1", "Image2", "Image3", "Image4", "Image5" };
          for (int i = 0; i < ImageNames.Length; i++)
          {
              thisTexture = new Texture2D(100, 100); //NOW INSIDE THE FOR LOOP
              fileName = ImageNames[i];
              bytes = File.ReadAllBytes(Path.Combine(Application.persistentDataPath, fileName + ".png"));
              thisTexture.LoadImage(bytes);
              thisTexture.name = fileName;
              ImageHolder[i].GetComponent<RawImage>().texture = thisTexture;
  
          }
  
      }


}
