using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enigme1Manager : MonoBehaviour
{
    // Pour ouvrir la porte, il faut activer les switch dans le bon ordre
    [SerializeField] private PetitSwitch[] _switches;

    [SerializeField] private GameObject _porte;

    private bool _isPorteOuverte;

    private int[] _secretCode = new int[] {1, 2, 3, 4};

    [SerializeField] private List<int> _codeTry;
    
    public static Action FirstEnigmeSucceded;

    private void OnEnable()
    {
        _switches[0].OnSwitchSwitch += AddOrRemoveIndexToCombinaison;
        _switches[1].OnSwitchSwitch += AddOrRemoveIndexToCombinaison;
        _switches[2].OnSwitchSwitch += AddOrRemoveIndexToCombinaison;
        _switches[3].OnSwitchSwitch += AddOrRemoveIndexToCombinaison;
    }

    private void OnDisable()
    {
        _switches[0].OnSwitchSwitch -= AddOrRemoveIndexToCombinaison;
        _switches[1].OnSwitchSwitch -= AddOrRemoveIndexToCombinaison;
        _switches[2].OnSwitchSwitch -= AddOrRemoveIndexToCombinaison;
        _switches[3].OnSwitchSwitch -= AddOrRemoveIndexToCombinaison;
    }

    private void Start()
    {
        _codeTry = new List<int>();
        _isPorteOuverte = false;
    }

    private void AddOrRemoveIndexToCombinaison(int index, bool b)
    {
        if(!_isPorteOuverte)
        {
            // Si un levier est activé
            if(b)
            {
                
                if(!_codeTry.Contains(index))
                {
                    // On ajoute son index à la combinaison
                    _codeTry.Add(index);

                    // On teste si pour le moment la combinaison est correcte
                    int nbSwithON = _codeTry.Count;
                    for (int i = 0; i <= nbSwithON-1; i++)
                    {
                        if (_codeTry[i] != _secretCode[i])
                        {
                            //ResetSwitch();
                            return;
                        }
                    }
                    if(nbSwithON == 4) OuvrirPorte();
                    
                }
            }
            // Si il est désactivé
            else
            {
                if (_codeTry.Contains(index))
                {
                    // On retire son numéro de la combinaison
                    _codeTry.Remove(index);
                }
            }
        }
    }

    public void DesableSwitch()
    {
        foreach(PetitSwitch ps in _switches)
        {
            ps.enabled = false;
        }
    }

    public void OuvrirPorte()
    {
        Debug.Log("Porte ouverte");
        _isPorteOuverte = true;

        AudioManager.instance.PlayDoor();

        DesableSwitch();
        _porte.transform.DOLocalRotate(new Vector3(0, -90, 0), 10).OnComplete(() => Debug.Log("Animation terminée"));
        
        FirstEnigmeSucceded?.Invoke();


    }





} // end script

