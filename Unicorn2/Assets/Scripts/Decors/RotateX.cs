using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateX : MonoBehaviour
{
    [SerializeField] private float speed = 30f; // La vitesse de rotation, en degres par seconde

    void Update()
    {
        float rotationAmount = speed * Time.deltaTime; // Calcule l'angle de rotation pour cet Update
        transform.Rotate(rotationAmount, 0f, 0f); // Fait tourner l'objet autour de l'axe X
    }
}
