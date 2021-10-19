using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public float followSpeed;
    public float followRot;
    public Transform followTarget;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, followTarget.position , followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation , followTarget.rotation, Time.deltaTime * followRot);
    }

}
