using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossColider : MonoBehaviour
{
    public static Action OnBossSaved;

    public GameObject bossSkin;
    public GameObject bossSavedSkin;
    public NavMeshAgent agent;
    

    public void BossSaved()
    {
        bossSkin.SetActive(false);
        bossSavedSkin.SetActive(true);
        
        OnBossSaved?.Invoke();
    }
    
}
