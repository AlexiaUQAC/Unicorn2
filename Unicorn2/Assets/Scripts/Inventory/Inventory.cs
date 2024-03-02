using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action<Collectible_So> OnInventoryChanged;
    
    private List<Collectible_So> _collectibles;
    private int _maxCollectibles = 1;
    
    private void Start()
    {
        _collectibles = new List<Collectible_So>();
    }
    
    public bool AddCollectible(Collectible_So collectible)
    {
        if (_collectibles.Count < _maxCollectibles)
        {
            _collectibles.Add(collectible);
            OnInventoryChanged?.Invoke(collectible);
            return true;
        }
        return false;
    }
    
    public void RemoveCollectible(Collectible_So collectible)
    {
        _collectibles.Remove(collectible);
        OnInventoryChanged?.Invoke(collectible);
    }
    
}
