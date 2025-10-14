using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class DustTrail : MonoBehaviour
{   
    CinemachineVirtualCamera vcam;
    [SerializeField] ParticleSystem snowEffect;
    float t;

    void Start()
    {
        vcam = FindAnyObjectByType<CinemachineVirtualCamera>();
        t = 0;
    }
    
    void Update()
    {
        t += Time.deltaTime;

        if (t >= 2)
        {
            vcam.m_Lens.OrthographicSize = 15f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        t = 0;
        vcam.m_Lens.OrthographicSize = 10f; 
        if (other.gameObject.tag == "Terrain")
        {
            snowEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        snowEffect.Stop();
    }
}
