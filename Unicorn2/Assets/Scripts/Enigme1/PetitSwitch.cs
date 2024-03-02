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

    private Vector3 _screenOpen = new Vector3(1, 1, 1);
    private Vector3 _screenClose = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        _switch = false;
        _screen.transform.DOScale(_screenClose, 1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            _switch = true;
            _screen.transform.DOScale(_screenOpen, 1);
            Debug.Log(name + " activé");
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.P))
        {
            _switch = false;
            _screen.transform.DOScale(_screenClose, 1);
            Debug.Log(name + " désactivé");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            EventsManager.DisplayActionUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventsManager.DisplayActionUI(false);
        }
    }

    public bool GetSwitchStatus()
    {
        return _switch;
    }

} // end script
