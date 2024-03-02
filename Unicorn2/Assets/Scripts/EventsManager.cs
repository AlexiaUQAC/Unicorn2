using System;
using UnityEngine;

public class EventsManager
{
    public static event Action<UI_Manager.UI_type, bool, string> OnActionRange_J1;
    public static event Action<UI_Manager.UI_type, bool, string> OnActionRange_J2;

    public static bool player1InRange;
    public static bool player2InRange;


    // Bouton sud
    public static void DisplayActionUI_J1(UI_Manager.UI_type uiType, bool isActionRange, string message)
    {
        OnActionRange_J1?.Invoke(uiType,isActionRange, message);
    }

    public static void DisplayActionUI_J2(UI_Manager.UI_type uiType, bool isActionRange, string message)
    {
        OnActionRange_J2?.Invoke(uiType,isActionRange, message);
    }

    public static void PlayerInActionSudRange(String tag, UI_Manager.UI_type uiType, bool b, string s)
    {
        if (tag.Equals("Player1"))
        {
            player1InRange = b;
            DisplayActionUI_J1(uiType,b,s);
        }
        else if (tag.Equals("Player2"))
        {
            player2InRange = b;
            DisplayActionUI_J2(uiType,b,s);
        }
    }


} // end script
