using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColider : MonoBehaviour
{
    public Action OnBossSaved;
    public static BossColider instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ProjectileViolet")
        {
            OnBossSaved?.Invoke();
        }
    }

}
