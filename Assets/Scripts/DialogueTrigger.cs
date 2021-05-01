using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }    
}
