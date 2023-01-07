using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear_children : MonoBehaviour
{
    
public  GameObject parent;
static Transform parentTransform;
void Awake(){
    parentTransform = parent.transform;

}
    // Start is called before the first frame update
    public static void Clear_toggleParent(){
        foreach(Transform child in parentTransform) {
        Destroy(child.gameObject);
        }
        foreach(Transform child in parentTransform) {
        Destroy(child.gameObject);
        }
    }
}
