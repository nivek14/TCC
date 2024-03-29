﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject interactionText;
    DialogueManager dialogueManager;
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        if (gameObject.GetComponentInParent<QuestGiver>())
        {
            dialogueManager.questGiver = gameObject.GetComponentInParent<QuestGiver>();
        }
        else dialogueManager.questGiver = null;


        dialogueManager.StartDialogue(dialogue);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
            interactionText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactionText.SetActive(false);
        }
    }
}
