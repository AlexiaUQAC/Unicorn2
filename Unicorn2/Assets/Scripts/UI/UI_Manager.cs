using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _ACTIVER;

    private void OnEnable()
    {
        EventsManager.OnActionRange += SetActiveActionUI;
    }

    private void OnDisable()
    {
        EventsManager.OnActionRange -= SetActiveActionUI;
    }

    private void SetActiveActionUI(bool b)
    {
        _ACTIVER.SetActive(b);
    }
    
} // end script
