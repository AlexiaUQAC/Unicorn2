using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Collectible_So collectible;
    private List<string> _playerInRange;
    private InventoryManager _inventoryManager;

    private void OnEnable()
    {
        PlayerController.OnSudBouton += Collect;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= Collect;
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
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, true, "<RAMASSER>");
        _playerInRange.Add(other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, false, "");
        _playerInRange.Remove(other.tag);
    }

    #endregion
    public void Collect(string s)
    {
        if (_playerInRange.Contains(s))
        {
            bool succed = _inventoryManager.AddCollectible(collectible, s);
            
            if (succed)
            {
                EventsManager.PlayerInActionSudRange(s, UI_Manager.UI_type.ACTION_UI, false, "");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventaire plein");
                EventsManager.PlayerInActionSudRange(s, UI_Manager.UI_type.INFO_UI, true, "Inventaire plein!");
            }
        }
    }
}
