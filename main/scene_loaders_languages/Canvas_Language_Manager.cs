using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Language_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject EngCanvas;
    [SerializeField] private GameObject FRCanvas;
    void Start()
    {
        Change_lang();
    }

    // Update is called once per frame
    private void Change_lang()
    {
        if (Language_Manager.lang == 0)
        {
            EngCanvas.SetActive(true);

            FRCanvas.SetActive(false);
        }
        if (Language_Manager.lang == 1)
        {
            EngCanvas.SetActive(false);

            FRCanvas.SetActive(true);
        }
    }
    public void en2frCanvas()
    {
        Language_Manager.lang = 1;
        Change_lang();
    }

    public void fr2enCanvass()
    {
        Language_Manager.lang = 0;
        Change_lang();

    }
}
