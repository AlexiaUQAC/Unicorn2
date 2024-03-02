using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigme1Manager : MonoBehaviour
{
    // Pour ouvrir la porte, tous les switch doivent être ON
    // Pour activer le switch A, il faut baisser en même temps A1 et A2
    // Pour activer le switch B, il faut baisser en même temps B1 et B2

    [SerializeField] private bool _switchA;
    [SerializeField] private bool _switchB;

    [SerializeField] private PetitSwitch _switchA1;
    [SerializeField] private PetitSwitch _switchA2;
    [SerializeField] private PetitSwitch _switchB1;
    [SerializeField] private PetitSwitch _switchB2;


    private void Update()
    {
        ActiverGrandSwitch();
    }

    public void OuvrirPorte()
    {
        if(_switchA && _switchB)
        {
            Debug.Log("Porte ouverte");
        }
    }

    public void ActiverGrandSwitch()
    {
        if(!_switchA && _switchA1.GetSwitchStatus() && _switchA2.GetSwitchStatus())
        {
            _switchA = true;
            OuvrirPorte();
        }

        if (!_switchB && _switchB1.GetSwitchStatus() && _switchB2.GetSwitchStatus())
        {
            _switchB = true;
            OuvrirPorte();
        }

    }



 } // end script

