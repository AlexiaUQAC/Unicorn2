using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject J1_activerGO;
    [SerializeField] private TextMeshProUGUI J1_activerText;
    [SerializeField] private GameObject J2_activerGO;
    [SerializeField] private TextMeshProUGUI J2_activerText;

    private void OnEnable()
    {
        EventsManager.OnActionRange_J1 += J1SetActiveActionUI;
        EventsManager.OnActionRange_J2 += J2SetActiveActionUI;
    }

    private void OnDisable()
    {
        EventsManager.OnActionRange_J1 -= J1SetActiveActionUI;
        EventsManager.OnActionRange_J2 -= J2SetActiveActionUI;
    }

    private void J1SetActiveActionUI(bool b, string s)
    {
        J1_activerGO.SetActive(b);
        J1_activerText.text = s;
    }

    private void J2SetActiveActionUI(bool b, string s)
    {
        J2_activerGO.SetActive(b);
        J2_activerText.text = s;
    }

} // end script
