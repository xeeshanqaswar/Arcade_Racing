using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    
    public GameObject impactEffect;

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(impactEffect, other.GetContact(0).point, Quaternion.identity);
    }

}
