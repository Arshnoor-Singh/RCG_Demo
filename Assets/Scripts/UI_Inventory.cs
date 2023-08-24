using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    public TextMeshProUGUI goldCount;
    public TextMeshProUGUI keyCount;
    public TextMeshProUGUI waterCount;

    public void UpdateGoldCount(int newGoldCount)
    {
        goldCount.text = newGoldCount.ToString();
    }

    public void UpdateKeyCount(int newKeyCount)
    {
        keyCount.text = newKeyCount.ToString();
    }

    public void UpdateWaterCount(int newWaterCount)
    {
        waterCount.text = newWaterCount.ToString();
    }
}
