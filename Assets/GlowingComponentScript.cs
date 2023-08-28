using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlowingComponentScript : MonoBehaviour
{
    private bool isAlreadyActive;
    public Light2D lightComponent;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent.intensity = 0f;
        isAlreadyActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isAlreadyActive)
        {
            lightComponent.intensity = 1;
            isAlreadyActive = true;
        }
    }
}
