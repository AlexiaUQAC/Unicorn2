using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleBehaviour : MonoBehaviour
{
    public GameObject[] projectile;
    public Transform firePoint;
    public Transform canon;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        Debug.Log("Shoot");
        // rotate the canon to the target
        Vector3 targetDir = target.position - canon.position;
        float angle = Vector3.Angle(targetDir, canon.forward);
        canon.rotation = Quaternion.LookRotation(targetDir);
        
        // Get a random projectile
        int randomIndex = Random.Range(0, projectile.Length);
        
        GameObject bullet = Instantiate(projectile[randomIndex], firePoint.position, firePoint.rotation);
        bullet.GetComponent<HS_ProjectileMover>().LateStart();
    }
}
