using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public float rotationSpeed = 1000f;
    public float turnSpeed = 20f;
    public Transform[] wheels;
    public Transform[] turnWheels;
    public TrailRenderer[] trails;
    public ParticleSystem[] smokeParticles;


    private float m_MoveInput;
    private float m_TurnInput;

    void Update()
    {
        m_MoveInput = Input.GetAxisRaw("Vertical");
        m_TurnInput = Input.GetAxisRaw("Horizontal");

        foreach (var wheel in wheels)
        {
            if (m_MoveInput != 0)
            {
                wheel.Rotate(new Vector3(1f,0f, 0f) * rotationSpeed * Time.deltaTime, Space.Self);
            }
        } 

        foreach (var wheel in turnWheels)
        {
            Quaternion targetRot;
            if (m_TurnInput != 0)
            {
                targetRot = Quaternion.Euler(0f, 30f * m_TurnInput, 0f);
            }
            else
            {
                targetRot = Quaternion.Euler(Vector3.zero);
            }

            wheel.localRotation = Quaternion.Slerp(wheel.localRotation, targetRot , turnSpeed * Time.deltaTime); 
        }  

        foreach (var trail in trails)
        {
            trail.emitting = (m_MoveInput > 0) && (m_TurnInput != 0);
        }   

        if (m_TurnInput != 0 && m_MoveInput > 0)
        {
            foreach (var smoke in smokeParticles)
            {
                if (!smoke.isEmitting )
                {
                    smoke.Play();
                }
            } 
        }
        else
        {
            foreach (var smoke in smokeParticles)
            {
                if (smoke.isEmitting )
                {
                    smoke.Stop();
                }
            } 
        }

    }

}
