using UnityEngine;

public class TempPlayerController: MonoBehaviour
{
    public float speed = 5.0f; // Vitesse de déplacement du personnage
    public float rotationSpeed = 100.0f; // Vitesse de rotation

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // On récupère le composant Rigidbody du GameObject
    }

    void FixedUpdate()
    {
        // Déplacement avant et arrière
        float moveVertical = Input.GetAxis("Vertical") * speed; // W et S
        rb.velocity = transform.forward * moveVertical;

        // Rotation gauche et droite
        float rotateHorizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // A et D
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotateHorizontal, 0f));
    }
}
