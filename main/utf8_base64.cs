using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text;
//Then you encode with (replace byte[] and string with var to make it js compatible):

//And decode with (change byte[] and string to var again for js):


public class utf8_base64 : MonoBehaviour
{

    // Start is called before the first frame update
    public static string encode_utf8_base64(string str)
    {

        byte[] bytesToEncode = Encoding.UTF8.GetBytes(str);
        string encodedText = Convert.ToBase64String(bytesToEncode);
        return encodedText;
    }

    // Update is called once per frame
    public static string decode_utf8_base64(string str)
    {
        byte[] decodedBytes = Convert.FromBase64String(str);
        string decodedText = Encoding.UTF8.GetString(decodedBytes);
        return decodedText;
    }
}
