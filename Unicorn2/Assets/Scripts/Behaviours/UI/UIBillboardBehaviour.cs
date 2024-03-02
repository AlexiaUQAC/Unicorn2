using UnityEngine;
using System.Collections;
 
[ExecuteAlways]
public class UIBillboardBehaviour : MonoBehaviour
{
    public Transform gameplayCameraTransform;

 
    void LateUpdate()
    {

        if(gameplayCameraTransform)
        {
            transform.LookAt(transform.position + gameplayCameraTransform.rotation * Vector3.forward, gameplayCameraTransform.rotation * Vector3.up);
        }


    }
}