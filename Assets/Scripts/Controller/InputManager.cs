using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    public Rigidbody sphereRb;
    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    public float airDrag;
    public float groundDrag;

    [Header("STATE")]
    public bool isGrounded;

    private LayerMask collisionLayer;

    private float m_MoveInput;
    private float m_TurnInput;

    private void Start()
    {
        collisionLayer = ~(1>>collisionLayer);
        sphereRb.transform.parent = null;
    }

    private void Update()
    {
        m_MoveInput = Input.GetAxisRaw("Vertical");
        m_TurnInput = Input.GetAxisRaw("Horizontal");
        m_MoveInput = m_MoveInput > 0? m_MoveInput * fwdSpeed:m_MoveInput * revSpeed; 

        transform.position = sphereRb.position;

        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        Debug.DrawRay(ray.origin, ray.direction * 1f, Color.green);
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, collisionLayer);

        float newRot = m_TurnInput * Input.GetAxisRaw("Vertical") * turnSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0f,newRot,0f), Space.World);
        
        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        UpdateDrag();
    }


    private void UpdateDrag()
    {
        if (isGrounded)
        {
            sphereRb.drag = groundDrag;
        }
        else
        {
            sphereRb.drag = airDrag;
            sphereRb.AddForce(transform.up * -9.8f, ForceMode.Acceleration);
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            sphereRb.AddForce(transform.forward * m_MoveInput, ForceMode.Acceleration);
        }
    }


}
