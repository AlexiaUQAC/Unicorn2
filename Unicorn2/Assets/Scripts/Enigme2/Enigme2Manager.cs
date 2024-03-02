using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigme2Manager : MonoBehaviour
{
    [SerializeField] private bool _isPorteLocked;

    private void Start()
    {
        _isPorteLocked = true;
    }

    public bool GetIsPorteLocked()
    {
        return _isPorteLocked;
    }
}
