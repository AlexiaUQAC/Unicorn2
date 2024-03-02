using System;
using UnityEngine;

public class EventsManager
{
    public static event Action<bool, string> OnActionRange_J1;
    public static event Action<bool, string> OnActionRange_J2;

    public static bool player1InRange;
    public static bool player2InRange;



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
            player1InRange = b;
            DisplayActionUI_J1(b,s);
        }
        else if (other.CompareTag("Player2"))
        {
            player2InRange = b;
            DisplayActionUI_J2(b,s);
        }
    }


} // end script
