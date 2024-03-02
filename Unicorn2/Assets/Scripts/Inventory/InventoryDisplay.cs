
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Inventory _inventory;
    
    private void OnEnable()
    {
        _inventory.OnInventoryChanged += UpdateUI;
    }

    private void OnDisable()
    {
        _inventory.OnInventoryChanged -= UpdateUI;
    }

    public void UpdateUI(Collectible_So collectible)
    {
        if (collectible != null)
        {
            _itemImage.enabled = true;
            _itemImage.sprite = collectible.sprite;
        }
        else
        {
            _itemImage.enabled = false;
            _itemImage.sprite = null;
        }
    }   
}
