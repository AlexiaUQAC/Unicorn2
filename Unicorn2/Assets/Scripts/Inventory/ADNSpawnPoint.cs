using UnityEngine;

public class ADNSpawnPoint : MonoBehaviour
{
    public bool isOccupied = false;
    
    public GameObject SpawnADN(GameObject ADN)
    {
        isOccupied = true;
        var go = Instantiate(ADN, transform.position, Quaternion.identity);
        go.GetComponent<Collectible>().OnCollectiblePickedUp += OnADNPickedUp;

        return go;
    }
    
    private void OnADNPickedUp(GameObject adn)
    {
        ADNSpawnManager.instance.ADNList.Remove(adn);
        isOccupied = false;
    }
}
