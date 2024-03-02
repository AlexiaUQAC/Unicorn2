using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Inventory _inventoryP1;
    [SerializeField] private Inventory _inventoryP2;

    public bool AddCollectible(Collectible_So collectible, string s)
    {
        if (s == "Player1")
        {
            return _inventoryP1.AddCollectible(collectible);
        }
        if (s == "Player2")
        {
            return _inventoryP2.AddCollectible(collectible);
        }
        
        return false;
    }
}
