using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class E2_DoublePorte : MonoBehaviour
{
    [SerializeField] private Enigme2Manager _enigme2Manager;

    [SerializeField] private GameObject _porteGauche;
    [SerializeField] private GameObject _porteDroite;
    [SerializeField] private List<string> _playerInRange;

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
        FermerPorte_E2();
    }

    #region Collider Enter and Exit

    private void OnTriggerEnter(Collider other)
    {
        // Si la porte est unlocked, alors elle s'ouvre automatiquement
        if(!_enigme2Manager.GetIsPorteLocked())
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                OuvrirPorte_E2();
            }
        }
        // Sinon, il faut afficher l'UI pour la déverouiller
        else
        {
            EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, true, "< OUVRIR >");
            _playerInRange.Add(other.tag);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        // Si la porte est unlocked, alors elle se ferme automatiquement
        if (!_enigme2Manager.GetIsPorteLocked())
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
        if (_playerInRange.Contains(tag))
        {
            // Si le joueur n'a pas de carte de niveau 1 dans son inventaire
            //TO DO : Check inventaire si carte

            // Si pas carte alors message
            EventsManager.PlayerInActionSudRange(tag, UI_Manager.UI_type.INFO_UI, true, "Cette porte a besoin de deux clés \nmagnétiques de<color=#76C7FF> niveau 1 </color>pour s'ouvrir.");

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
