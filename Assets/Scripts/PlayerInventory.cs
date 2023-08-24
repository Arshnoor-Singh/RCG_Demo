using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int keysCarried = 0;
    private int goldCarried = 0;

    public void CollectedKey()
    {
        keysCarried++;
    }

    public void UsedKey()
    {
        keysCarried--;
    }

    public void CollectedGold()
    {
        goldCarried++;
    }

    public void UsedGold()
    {
        goldCarried--;
    }
}
