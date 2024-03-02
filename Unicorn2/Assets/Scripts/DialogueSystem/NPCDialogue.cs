using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue_So[] _dialogues;
    private int _currentDialogueIndex;
    private List<string> _playerInRange;
    private DialogueDisplay _dialogueDisplay;
    private Animator _animator;

    private void OnEnable()
    {
        PlayerController.OnSudBouton += ActiverDialog;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= ActiverDialog;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerInRange = new List<string>();
        _dialogueDisplay = FindObjectOfType<DialogueDisplay>();
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other, true, "<PARLER>");
        _playerInRange.Add(other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other, false, "");
        _playerInRange.Remove(other.tag);
    }
    
    private void ActiverDialog(string s)
    {
        if(_playerInRange.Contains(s))
        {
            _dialogueDisplay.StartDialogue(_animator, _dialogues[_currentDialogueIndex]);
        }
    }
}
