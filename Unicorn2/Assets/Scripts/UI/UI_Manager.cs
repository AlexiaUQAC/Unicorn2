using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public enum UI_type
    {
        ACTION_UI,
        INFO_UI
    }


    //ACT ION UI(sud)
    [SerializeField] private GameObject J1_activerGO;
    [SerializeField] private TextMeshProUGUI J1_activerText;
    [SerializeField] private GameObject J2_activerGO;
    [SerializeField] private TextMeshProUGUI J2_activerText;

    // Information UI
    [SerializeField] private GameObject J1_InfoGO;
    [SerializeField] private TextMeshProUGUI J1_InfoText;
    [SerializeField] private GameObject J2_InfoGO;
    [SerializeField] private TextMeshProUGUI J2_InfoText;

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

   
    private void J1SetActiveActionUI(UI_type uiType, bool b, string s)
    {
        if(uiType == UI_type.ACTION_UI)
        {
            J1_activerGO.SetActive(b);
            J1_activerText.text = s;
        }
        else if (uiType == UI_type.INFO_UI)
        {
            J1_InfoGO.SetActive(b);
            J1_InfoText.text = s;
            StartCoroutine(DiscardInfoUI_coroutine("Player1"));
        }
        
    }

    private void J2SetActiveActionUI(UI_type uiType, bool b, string s)
    {
        if (uiType == UI_type.ACTION_UI)
        {
            J2_activerGO.SetActive(b);
            J2_activerText.text = s;
        }
        else if (uiType == UI_type.INFO_UI)
        {
            J2_InfoGO.SetActive(b);
            J2_InfoText.text = s;
            StartCoroutine(DiscardInfoUI_coroutine("Player2"));
        }
    }

    IEnumerator DiscardInfoUI_coroutine(string tag)
    {
        yield return new WaitForSeconds(3);

        if (tag.Equals("Player1"))
        {
            J1_InfoGO.SetActive(false);
            J1_InfoText.text = "";
        }
        else if (tag.Equals("Player2"))
        {
            J2_InfoGO.SetActive(false);
            J2_InfoText.text = "";
        }
    }



} // end script
