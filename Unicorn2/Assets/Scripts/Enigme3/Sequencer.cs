using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : MonoBehaviour
{
    [SerializeField] private List<string> _playerInRange;
    [SerializeField] private TableFusion _tableFusion;

    [SerializeField] private GameObject _adnFusion;
    [SerializeField] private GameObject[] _adnFusionColor;

    [SerializeField] private int indexFusion;

    private void OnEnable()
    {
        PlayerController.OnSudBouton += SequencerADN;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= SequencerADN;
    }


    private void OnTriggerEnter(Collider other)
    {

        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, true, "Démarrer le séquençage d'<color=#76C7FF> ADN </color>.");

        _playerInRange.Add(other.tag);


    }

    private void OnTriggerExit(Collider other)
    {

        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, false, "");
        _playerInRange.Remove(other.tag);

    }

    // Fonction appelé quand le joueur appuie sur bouton sud
    public void SequencerADN(string tag)
    {
        // Si le joueur est dans la range
        if (_playerInRange.Contains(tag))
        {
            // Si le sequenceur est pret
            if (_tableFusion.IsReady())
            {
                // On récupère l'index des deux adn
                int indexGauche = _tableFusion.GetADNGauche();
                int indexDroite = _tableFusion.GetADNDroite();

                // On calcule la couleur de la fusion
                
                // Rouge
                if (indexGauche == 0 && indexDroite == 0) indexFusion = 0;
                // Bleu
                else if (indexGauche == 1 && indexDroite == 1) indexFusion = 1;
                // Jaune
                else if (indexGauche == 2 && indexDroite == 2) indexFusion = 2;
                // Violet
                else if (indexGauche == 0 && indexDroite == 1) indexFusion = 3;
                else if (indexGauche == 1 && indexDroite == 0) indexFusion = 3;
                // Vert
                else if (indexGauche == 1 && indexDroite == 2) indexFusion = 4;
                else if (indexGauche == 2 && indexDroite == 1) indexFusion = 4;
                // Orange
                else if (indexGauche == 0 && indexDroite == 2) indexFusion = 5;
                else if (indexGauche == 2 && indexDroite == 0) indexFusion = 5;
                else indexFusion = -1;
                Debug.Log(indexFusion);


                // On désactive les ADN Gauche et droite du sequencer
                _tableFusion.DesableADN();

                // On affiche la bonne couleur
                for (int i = 0; i < 6; i++)
                {
                    _adnFusion.SetActive(true);
                    if (i == indexFusion)
                    {
                        _adnFusionColor[i].SetActive(true);
                    }
                    else _adnFusionColor[i].SetActive(false);
                }

                
            }
            // Le sequenceur N,est pas encore plein
            else
            {
                EventsManager.PlayerInActionSudRange(tag, UI_Manager.UI_type.INFO_UI, true, "Le séquenceur d'ADN n'a pas suffisament \n d'<color=#76C7FF>échantillon d'ADN </color> pour fonctionner.");
            }
        }
    } // end place ADN


} // end script
