using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFusion : MonoBehaviour
{
    [SerializeField] private GameObject _adnGauche;
    [SerializeField] private GameObject[] _adnGaucheColor;

    [SerializeField] private GameObject _adnDroite;
    [SerializeField] private GameObject[] _adnDroiteColor;

    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private List<string> _playerInRange;


    private void OnEnable()
    {
        PlayerController.OnSudBouton += PlaceADN;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= PlaceADN;
    }

    #region Collider Enter and Exit

    private void OnTriggerEnter(Collider other)
    {
        
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, true, "Placer l'échantillon d'<color=#76C7FF> ADN </color>.");     

        _playerInRange.Add(other.tag);
        

    }

    private void OnTriggerExit(Collider other)
    {
        
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, false, "");
        _playerInRange.Remove(other.tag);
      
    }

    #endregion

    // Fonction appelé quand le joueur appuie sur bouton sud
    public void PlaceADN(string tag)
    {
        // Si le joueur est dans la range
        if(_playerInRange.Contains(tag))
        {
            // Si il reste un emplacement d'ADN dans la machine
            if(!_adnGauche.activeInHierarchy || !_adnDroite.activeInHierarchy)
            {

                // On place à gauche ou à droite
                int indexCouleur = _inventoryManager.GetIndexADN(tag);
                // Placer ADN
                if(!_adnGauche.activeInHierarchy)
                {
                    _adnGauche.SetActive(true);
                    for(int i = 0; i < 3; i++)
                    {
                        if(i == indexCouleur)
                        {
                            _adnGaucheColor[i].SetActive(true);
                        }
                        else _adnGaucheColor[i].SetActive(false);
                    }
                }
                else
                {
                    _adnDroite.SetActive(true);
                    for (int i = 0; i < 3; i++)
                    {
                        if (i == indexCouleur)
                        {
                            _adnDroiteColor[i].SetActive(true);
                        }
                        else _adnDroiteColor[i].SetActive(false);
                    }
                }

                // Enlever pessage "Placer ADN"
                EventsManager.PlayerInActionSudRange(tag, UI_Manager.UI_type.ACTION_UI, false, "");

                // Vider inventory
                _inventoryManager.RemoveCollectible(tag);
            }
            // Il n'y a plus de place dans le séquenceur
            else
            {
                EventsManager.PlayerInActionSudRange(tag, UI_Manager.UI_type.INFO_UI, true, "Il n'y a plus de place dans le '<color=#76C7FF> séquenceur d'ADN </color>.");
            }
        }
    } // end place ADN

} // End script
