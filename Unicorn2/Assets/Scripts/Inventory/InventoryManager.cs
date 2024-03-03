using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Inventory _inventoryP1;
    [SerializeField] private Inventory _inventoryP2;

    public bool IsEmpty(string s)
    {
        if (s == "Player1")
        {
            return _inventoryP1.IsEmpty();
        }
        if (s == "Player2")
        {
            return _inventoryP2.IsEmpty();
        }

        return true;
    }

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

    public int GetIndexADN(string s)
    {
        if (s == "Player1")
        {
            return int.Parse(_inventoryP1._collectibles[0].name);
        }
        else if (s == "Player2")
        {
            return int.Parse(_inventoryP2._collectibles[0].name);
        }
        return -1; // exprès mauvaise couleur pour montrer que c'est une erreur;
    }

    public bool RemoveCollectible( string s)
    {
        if (s == "Player1")
        {
             _inventoryP1.RemoveCollectible();
        }
        if (s == "Player2")
        {

            _inventoryP2.RemoveCollectible();
        }

        return false;
    }

    public bool IsItemInInventory(string tag, Collectible_So collectible)
    {
        if(tag.Equals("Player1"))
        {
            if(_inventoryP1._collectibles.Count > 0)
            {
                return collectible.name == _inventoryP1._collectibles[0].name;
            }
           
        }
        else if(tag.Equals("Player2"))
        {
            if (_inventoryP2._collectibles.Count > 0)
            {
                return collectible.name == _inventoryP2._collectibles[0].name;
            }
        }
        return false;
    }
}
