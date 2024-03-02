using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class PetitSwitch : MonoBehaviour
{
    //[SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private bool _switch;
    [SerializeField] private GameObject _screen;
    [SerializeField] private List<string> _playerInRange;
    

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

    

    private void OnTriggerEnter(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other, true, "<ACTIVER>");
        _playerInRange.Add(other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other, false, "");
        _playerInRange.Remove(other.tag);
    }

    public bool GetSwitchStatus()
    {
        return _switch;
    }

    private void ActiverSwitch(string s)
    {
        if(_playerInRange.Contains(s))
        {
            _switch = !_switch;
            if (_switch)
            {
                _screen.transform.DOScale(_screenOpen, 1);
            }
            else
            {
                _screen.transform.DOScale(_screenClose, 1);

            }
        }
    }


} // end script
