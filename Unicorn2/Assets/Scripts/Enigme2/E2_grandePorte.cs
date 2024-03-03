using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class E2_grandePorte : MonoBehaviour
{
    [SerializeField] private e2_manager _e2Manager;
    [SerializeField] private GameObject _porte;

    private void OnTriggerEnter(Collider other)
    {
        // Si la porte est unlocked, alors elle s'ouvre automatiquement
        if (!_e2Manager.IsPorteLocked())
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                OuvrirPorte_E2();
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        // Si la porte est unlocked, alors elle se ferme automatiquement
        if (!_e2Manager.IsPorteLocked())
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                FermerPorte_E2();
            }
        }
        
    }

    public void OuvrirPorte_E2()
    {
        _porte.transform.DOLocalMove(new Vector3(0, 4.668f, 0), 2);
        AudioManager.instance.PlayDoor();
    }

    public void FermerPorte_E2()
    {
        
        _porte.transform.DOLocalMove(new Vector3(0, 1.79f, 0), 2);
        AudioManager.instance.PlayDoor();
    }
} // end script
