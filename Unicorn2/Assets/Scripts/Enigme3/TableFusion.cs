using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFusion : MonoBehaviour
{/*
    [SerializeField] private GameObject _adnGauche;
    [SerializeField] private GameObject[] _adnGaucheColor;

    [SerializeField] private GameObject _adnDroite;
    [SerializeField] private GameObject[] _adnDroiteColor;

    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private Collectible_So _keyType;

    #region Collider Enter and Exit
    /*
    private void OnTriggerEnter(Collider other)
    {
        
        // Si le joueur un ADN dans son inventaire
        if (_inventoryManager.IsItemInInventory(other.tag, _keyType))
        {
            // Si carte alors message
            EventsManager.PlayerInActionSudRange(tag, UI_Manager.UI_type.INFO_UI, true, "Placer la carte magnétiques de<color=#76C7FF> niveau 1 </color>.");
        }
        else
        {
            EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, true, "< OUVRIR >");
        }

        _playerInRange.Add(other.tag);
        

    }

    private void OnTriggerExit(Collider other)
    {
        // Si la porte est unlocked, alors elle se ferme automatiquement
        if (!_isPorteLocked)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                FermerPorte_E2();
            }
        }
        // Sinon, enleve l'UI lié au déverouillage de la porte
        else
        {
            EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, false, "");
            _playerInRange.Remove(other.tag);
        }
    }

    #endregion*/
}
