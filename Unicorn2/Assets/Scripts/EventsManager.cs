using System;
using UnityEngine;

public class EventsManager
{
    public static event Action<bool, string> OnActionRange_J1;
    public static event Action<bool, string> OnActionRange_J2;


    // Bouton sud
    public static void DisplayActionUI_J1(bool isActionRange, string message)
    {
        OnActionRange_J1?.Invoke(isActionRange, message);
    }

    public static void DisplayActionUI_J2(bool isActionRange, string message)
    {
        OnActionRange_J2?.Invoke(isActionRange, message);
    }

    public static void PlayerInActionSudRange(Collider other, bool b, string s)
    {
        if (other.CompareTag("Player1"))
        {
            DisplayActionUI_J1(b,s);
        }

        if (other.CompareTag("Player2"))
        {
            DisplayActionUI_J2(b,s);
        }
    }


} // end script
