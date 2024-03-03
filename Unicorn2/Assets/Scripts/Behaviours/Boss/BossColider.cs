using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColider : MonoBehaviour
{
    public static Action OnBossSaved;

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ProjectileViolet")
        {
            OnBossSaved?.Invoke();
        }
    }

}
