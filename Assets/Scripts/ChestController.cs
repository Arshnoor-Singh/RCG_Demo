using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject chestOpen;
    public GameObject chestClose;
    private bool isOpen;


    private void Start()
    {
        isOpen = false;
        chestClose.SetActive(true);
        chestOpen.SetActive(false);
    }

    public void ToggleChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            chestOpen.SetActive(true);
            chestClose.SetActive(false);
        }

        else
        {
            isOpen = false;
            chestClose.SetActive(true);
            chestOpen.SetActive(false);
        }
    }
    
}
