using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetitSwitch : MonoBehaviour
{
    //[SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private bool _switch;
    
    // Start is called before the first frame update
    void Start()
    {
        _switch = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            _switch = true;
            Debug.Log(name + " activé");
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
