using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using System;

public class PetitSwitch : MonoBehaviour
{
    //[SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private bool _switch;
    [SerializeField] private GameObject _screen;
    [SerializeField] private List<string> _playerInRange;

    [SerializeField] private int _index; // ordre d'activation
    public event Action<int, bool> OnSwitchSwitch;



    private Vector3 _screenOpen = new Vector3(1, 1, 1);
    private Vector3 _screenClose = new Vector3(0, 0, 0);

    private void OnEnable()
    {
        PlayerController.OnSudBouton += ActiverSwitch;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= ActiverSwitch;
    }

    // Start is called before the first frame update
    void Start()
    {
        _switch = false;
        _screen.transform.DOScale(_screenClose, 1);
        _playerInRange = new List<string>();
    }

    #region Collider Enter and Exit

    private void OnTriggerEnter(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, true, "< ACTIVER >");
        _playerInRange.Add(other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, false, "");
        _playerInRange.Remove(other.tag);
    }

    #endregion

    #region Activation du switch

    private void ActiverSwitch(string s)
    {
        if(_playerInRange.Contains(s))
        {
            if (!_switch)
            {
                SwitchON();
            }
            else
            {
                SwitchOFF();
            }
        }
    }

    public void SwitchON()
    {
        _switch = true;
        _screen.transform.DOScale(_screenOpen, 1);
        // Event pour pr?venir le manager que je suis activ?
        SwitchSwitch(_index, _switch);
    }

    public void SwitchOFF()
    {
        _switch = false;
        _screen.transform.DOScale(_screenClose, 1);
        // Event pour pr?venir le manager que je suis d?sactiv?
        SwitchSwitch(_index, _switch);
    }

    public void SwitchSwitch(int index, bool b)
    {
        OnSwitchSwitch?.Invoke(index, b);
    }

    #endregion


} // end script
