using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDisplay: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private GameObject _dialogueBox;
    
    private Queue<string> sentences;
    private bool _isDialogueActive;
    private Animator currentAnimator; 
    
    private void OnEnable()
    {
        PlayerController.OnSudBouton += DisplayNextSentence;
    }

    private void OnDisable()
    {
        PlayerController.OnSudBouton -= DisplayNextSentence;
    }
    
    public void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Animator animator, Dialogue_So dialogue)
    {
        if (!_isDialogueActive)
        {
            _dialogueBox.SetActive(true);
            
            currentAnimator = animator;
            
           // Debug.Log("Starting conversation with " + dialogue.NPCName);
            _nameText.text = dialogue.NPCName;
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
            
            _isDialogueActive = true;
        }
    }
    
    private void DisplayNextSentence(string s = "")
    {
        if (_isDialogueActive)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
    
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            //Debug.Log(sentence);
            SetRandomAnimation();
        }
        
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        _dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter;
            yield return null;
        }
    }
    
    private void EndDialogue()
    {
        _dialogueBox.SetActive(false);
        //Debug.Log("End of conversation");
        StopAnimation();
        
        Invoke("DelayedEndDialogue", 1);
    }

    private void SetRandomAnimation()
    {
        StopAnimation();
        
        int random = Random.Range(1, 5);
        currentAnimator.SetBool("Talking" + random, true);
    }
    
    private void StopAnimation()
    {
        currentAnimator.SetBool("Talking1", false);
        currentAnimator.SetBool("Talking2", false);
        currentAnimator.SetBool("Talking3", false);
        currentAnimator.SetBool("Talking4", false);
    }
    
    private void DelayedEndDialogue()
    {
        _isDialogueActive = false;
    }
}
