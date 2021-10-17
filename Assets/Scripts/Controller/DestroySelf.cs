using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    
    private void Start()
    {
        Invoke("DestroyItslef" , 2f);
    }

    private void DestroyItslef(){
        Destroy(gameObject);
    }
}
