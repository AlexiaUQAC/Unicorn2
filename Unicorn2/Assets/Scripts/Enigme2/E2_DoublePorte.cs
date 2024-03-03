using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class E2_DoublePorte : MonoBehaviour
{
    [SerializeField] private Enigme2Manager _enigme2Manager;

    [SerializeField] private GameObject _porteGauche;
    [SerializeField] private GameObject _porteDroite;
    [SerializeField] private GameObject _carteGauche;
    [SerializeField] private GameObject _carteDroite;

    [SerializeField] private List<string> _playerInRange;
    [SerializeField] private bool _isPorteLocked;
    private InventoryManager _inventoryManager;
    [SerializeField]private Collectible_So _keyType;

    // Cette porte a besoin de deux clés 
    //magnétiques de<color=#76C7FF>niveau 1 </color>pour s'ouvrir.

    private void OnEnable()
    {
        PlayerController.OnSudBouton += UnlockPorte;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= UnlockPorte;
    }

    private void Start()
    {
        _isPorteLocked = true;
        FermerPorte_E2();
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    #region Collider Enter and Exit

    private void OnTriggerEnter(Collider other)
    {
        // Si la porte est unlocked, alors elle s'ouvre automatiquement
        if(!_isPorteLocked)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                OuvrirPorte_E2();
            }
        }
        // Sinon, il faut afficher l'UI pour la déverouiller
        else
        {
            // Si le joueur a carte de niveau 1 dans son inventaire
            if (_inventoryManager.IsItemInInventory(tag, _keyType))
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

    #endregion


    #region Deverouillage de la porte

    public void UnlockPorte(string tag)
    {
        if(_isPorteLocked)
        {
            if (_playerInRange.Contains(tag))
            {
                // Si le joueur n'a pas de carte de niveau 1 dans son inventaire
                if (!_inventoryManager.IsItemInInventory(tag, _keyType))
                {
                    // Si pas carte alors message
                    EventsManager.PlayerInActionSudRange(tag, UI_Manager.UI_type.INFO_UI, true, "Cette porte a besoin de deux clés \nmagnétiques de<color=#76C7FF> niveau 1 </color>pour s'ouvrir.");
                }
                // Si il a une carte, on l'utilise
                else
                {
                    // mettre carte porte
                    if (!_carteGauche.activeInHierarchy)
                    {
                        _carteGauche.SetActive(true);
                        // Supprimer carte de l'inventaire
                        _inventoryManager.RemoveCollectible(tag);
                        EventsManager.PlayerInActionSudRange(tag, UI_Manager.UI_type.ACTION_UI, false, "");
                    }
                    else if (!_carteDroite.activeInHierarchy)
                    {
                        _carteDroite.SetActive(true);
                        // Supprimer carte de l'inventaire
                        _inventoryManager.RemoveCollectible(tag);
                        _isPorteLocked = false;
                        OuvrirPorte_E2();
                        EventsManager.PlayerInActionSudRange(tag, UI_Manager.UI_type.ACTION_UI, false, "");

                    }

                }

            }
        }
        
    }

    #endregion

    public void OuvrirPorte_E2()
    {
        _porteGauche.transform.DOLocalMove(new Vector3(-0.73f, 0, 0), 1);
        _porteDroite.transform.DOLocalMove(new Vector3(-4.24f, 0, 0), 1);
    }

    public void FermerPorte_E2()
    {
        _porteGauche.transform.DOLocalMove(new Vector3(-1.78f, 0, 0), 1);
        _porteDroite.transform.DOLocalMove(new Vector3(-3.22f, 0, 0), 1);
    }


}
