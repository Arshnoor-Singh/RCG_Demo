using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune_Script : MonoBehaviour
{
    private bool introDone;
    // Start is called before the first frame update
    void Start()
    {
        introDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!introDone)
        {
            other.GetComponent<PlayerMovement>().DisplayOnDialogueBox("No on in the village knows what these weird glowing rocks are. Maybe I'll find out some day", 5f);
            introDone = true;
        }
        
    }
}
