using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceItem : MonoBehaviour
{
    [SerializeField] float duration = 1f; // Durée du mouvement vers le haut ou vers le bas
    [SerializeField] float distance = 0.5f; // Distance du mouvement vers le haut ou vers le bas

    void Start()
    {
        // Lancez l'animation de flottement
        Float();
    }

    void Float()
    {
        // Déplacez le GameObject vers le haut
        transform.DOBlendableMoveBy(Vector3.up * distance, duration).SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                // Puis, déplacez-le vers le bas, créant ainsi un effet de flottement
                transform.DOBlendableMoveBy(Vector3.down * distance, duration).SetEase(Ease.InOutSine)
                    .OnComplete(Float); // Répétez l'animation en boucle
            });
    }
} // end script
