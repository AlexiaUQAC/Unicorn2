using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADNSpawnManager : MonoBehaviour
{
    public GameObject[] ADN;
    
    public List<ADNSpawnPoint> spawnPoints;
    public List<GameObject> ADNList;
    
    public int adnToSpawn = 5;
    
    private float _spawnRate = 5f;
    
    public static ADNSpawnManager instance;
    
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        InvokeRepeating("SpawnADN", 0, _spawnRate);
    }
    
    private void SpawnADN()
    {
        if (ADNList.Count < adnToSpawn)
        {
            // Get a random ADN from the list
            var rand = ADN[Random.Range(0, ADN.Length)];
            
            var adnSpawn = GetEmptySpawnPoint().SpawnADN(rand);
            ADNList.Add(adnSpawn);
        }
    }

    private ADNSpawnPoint GetEmptySpawnPoint()
    {
        // Shuffle the list of spawn points
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            ADNSpawnPoint temp = spawnPoints[i];
            int randomIndex = Random.Range(i, spawnPoints.Count);
            spawnPoints[i] = spawnPoints[randomIndex];
            spawnPoints[randomIndex] = temp;
        }
        
        // Return the first empty spawn point
        foreach (var spawnPoint in spawnPoints)
        {
            if (!spawnPoint.isOccupied)
            {
                return spawnPoint;
            }
        }

        return null;
    }
}
