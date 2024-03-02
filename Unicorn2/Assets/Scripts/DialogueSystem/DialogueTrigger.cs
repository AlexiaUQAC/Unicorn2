using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, true, "<PARLER>");
    }

    private void OnTriggerExit(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI, false, "");
    }
}
