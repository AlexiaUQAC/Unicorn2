using System;

public class EventsManager
{
    public static event Action<bool> OnActionRange;

    public static void DisplayActionUI(bool actionRange)
    {
        OnActionRange?.Invoke(actionRange);
    }
}
