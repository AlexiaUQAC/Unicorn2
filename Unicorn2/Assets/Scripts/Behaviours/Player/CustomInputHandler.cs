using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputHandler : MonoBehaviour, AxisState.IInputAxisProvider
{
   [HideInInspector] public InputAction horizontalInputAction;
   [HideInInspector] public InputAction verticalInputAction;
   
   public float GetAxisValue(int axis)
   {
      return axis switch
      {
         0 => horizontalInputAction.ReadValue<Vector2>().x,
         1 => horizontalInputAction.ReadValue<Vector2>().y,
         2 => verticalInputAction.ReadValue<float>(),
         _ => 0
      };
   }
}
