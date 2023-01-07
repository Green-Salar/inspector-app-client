using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using System.IO;

using System.Text.RegularExpressions;
using System.Globalization;
using UnityEngine.UI;

using UnityEngine.Networking;
public class relationsDownloader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            if (!File.Exists("relations.db"))
            {
                Debug.Log("starting to dl  ");
                StartCoroutine(DownloadFile());
            }
        }
        catch { }
        
    }


    IEnumerator DownloadFile()
    {
        var uwr = new UnityWebRequest("https://drive.google.com/uc?export=download&id=18lWrMHPRYDcnjR-4mhP-jSYF5OzaMDhU", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, "relations.db");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            Debug.LogError(uwr.error);
        else
            Debug.Log("File successfully downloaded and saved to " + path);
    }
}


