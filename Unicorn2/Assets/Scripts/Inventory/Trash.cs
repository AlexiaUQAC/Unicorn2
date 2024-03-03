using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private List<string> _playerInRange;
    private InventoryManager _inventoryManager;

    private void OnEnable()
    {
        PlayerController.OnSudBouton += Throw;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= Throw;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerInRange = new List<string>();
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    #region Collider Enter and Exit

    private void OnTriggerEnter(Collider other)
    {
        if (!_inventoryManager.IsEmpty(other.tag))
        {
            EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, true, "<JETER>");
        }
        _playerInRange.Add(other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_inventoryManager.IsEmpty(other.tag))
        {
            EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, false, "");
        }
        _playerInRange.Remove(other.tag);
    }

    #endregion

    private void Throw(string s)
    {
        if (_playerInRange.Contains(s))
        {
            if (!_inventoryManager.IsEmpty(s))
            {
                EventsManager.PlayerInActionSudRange(s, UI_Manager.UI_type.ACTION_UI, false, "");
                _inventoryManager.RemoveCollectible(null, s);
            }
        }
    }
}
