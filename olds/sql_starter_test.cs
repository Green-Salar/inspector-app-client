using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sql_starter_test : MonoBehaviour
{
        // Start is called before the first frame update
        void Start()
        {
            sql_handler.create_or_connect_all_seprated("TEST2");
        }

        // Update is called once per frame
        void Update()
        {
            
        }
}
