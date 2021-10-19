using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSFX : MonoBehaviour
{
    
    public AudioSource engineSound, slipSound;
    
    
    private float m_MoveInput;
    [SerializeField] private float m_TurnInput;

    private void Update()
    {
        m_MoveInput = Input.GetAxis("Vertical");
        m_TurnInput = Input.GetAxis("Horizontal");
        
        HandleTyreScreech();
    }

    private void HandleTyreScreech()
    {
        if (Mathf.Abs(m_TurnInput) > 0.8f)
        {
            slipSound.volume = Mathf.MoveTowards(slipSound.volume, Mathf.Abs(m_TurnInput), Time.deltaTime * 2f);
        }
        else
        {
            slipSound.volume = Mathf.MoveTowards(slipSound.volume, 0f, Time.deltaTime * 2f);
        }
    }
}
