using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject chestOpen;
    public GameObject chestClose;
    private bool isOpen;

    public GameObject reward;
    public Transform spawnLocaiton;
    private bool rewardGiven;
    
    private void Start()
    {
        isOpen = false;
        chestClose.SetActive(true);
        chestOpen.SetActive(false);
        rewardGiven = false;
    }

    public void ToggleChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            chestOpen.SetActive(true);
            chestClose.SetActive(false);
            if (!rewardGiven)
            {
                Instantiate(reward, spawnLocaiton);
            }
            rewardGiven = true;
        }

        else
        {
            isOpen = false;
            chestClose.SetActive(true);
            chestOpen.SetActive(false);
        }
    }
    
}
