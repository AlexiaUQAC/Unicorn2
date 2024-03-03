using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue_So[] _dialogues;
    private string _npcName;
    private int _currentDialogueIndex;
    private List<string> _playerInRange;
    private DialogueDisplay _dialogueDisplay;
    private Animator _animator;

    private void OnEnable()
    {
        PlayerController.OnSudBouton += ActiverDialog;
        Enigme1Manager.FirstEnigmeSucceded += SetDialogueAfterEnigme1;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= ActiverDialog;
        Enigme1Manager.FirstEnigmeSucceded -= SetDialogueAfterEnigme1;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerInRange = new List<string>();
        _dialogueDisplay = FindObjectOfType<DialogueDisplay>();
        _animator = GetComponent<Animator>();
        _npcName = _dialogues[0].name;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI,true, "<PARLER>");
        _playerInRange.Add(other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        EventsManager.PlayerInActionSudRange(other.tag, UI_Manager.UI_type.ACTION_UI ,false, "");
        _playerInRange.Remove(other.tag);
    }
    
    private void ActiverDialog(string s)
    {
        if(_playerInRange.Contains(s))
        {
            _dialogueDisplay.StartDialogue(_animator, _dialogues[_currentDialogueIndex]);

            if (_currentDialogueIndex == 0)
            {
                _currentDialogueIndex = 1;
            }
        }
    }

    private void SetDialogueAfterEnigme1()
    {
        if (_npcName == "Scientifique")
        {
            _currentDialogueIndex = 2;
        }
    }
    
    // TODO : Set dialogue end
}
