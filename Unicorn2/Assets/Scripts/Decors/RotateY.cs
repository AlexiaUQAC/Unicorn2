using UnityEngine;

public class RotateY : MonoBehaviour
{
    [SerializeField] private float speed = 30f; // La vitesse de rotation, en degres par seconde

    void Update()
    {
        float rotationAmount = speed * Time.deltaTime; // Calcule l'angle de rotation pour cet Update
        transform.Rotate(0f, rotationAmount, 0f); // Fait tourner l'objet autour de l'axe Y
    }
}
