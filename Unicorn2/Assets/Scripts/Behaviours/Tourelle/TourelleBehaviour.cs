using UnityEngine;

public class TourelleBehaviour : MonoBehaviour
{
    public Transform firePoint;
    public Transform canon;
    public Transform target;
    
    public void Shoot(GameObject projectile)
    {
        // rotate the canon to the target
        Vector3 targetDir = target.position - canon.position;
        float angle = Vector3.Angle(targetDir, canon.forward);
        canon.rotation = Quaternion.LookRotation(targetDir);
        
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        bullet.GetComponent<HS_ProjectileMover>().LateStart();
    }
}
