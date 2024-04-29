using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCInteraction : Interactable
{
    public DialogueManager dialogueManager;

    private bool hasInteracted = false;
    private bool hasPlayerAgreed = false; 

    private List<string> initialDialogueParts = new List<string> {
        "Who goes there?",
        "",
        "Oh, it's you...",
        "",
        "What time do you call this? I've been waiting here for what seems like forever!",
        "",
        "Don't tell me you dont fully appreciate the honour you've been given?",
        "",
        "Becoming one of the twenty-six Enforcers is a privilege. We are the King's most capable assassins, enforcing his will from the shadows.",
        "",
        "Well, he's not the King just yet but he will be once our conquest of this pitiful realm is complete.",
        "",
        "Anyways, we don't let just about anyone in you know, so if you're truly to become one of us you must demonstrate commitment.",
        "",
        "No matter, just don't let it happen again.",
        "",
        "You will refer to me by my designated title.",
        "",
        "Enforcer T.",
        "",
        "Incompetence will not be tolerated. You have big shoes to fill if you are truly going to replace Enforcer F.",
        "",
        "What happened to him was... unfortunate... to say the least.",
        "",
        "Enforcer A that damn traitor! Once we get our hands on him I swear I'll -",
        "",
        "Let's not get into all that. Not just yet anyways.",
        "",
        "You have a total of four missions to complete before you are ready to become one of us.",
        "",
        "So, what do you say? Are you ready to prove yourself?",
    };

    private List<string> finalDialogueParts = new List<string> {
        "So, what do you say? Are you ready to prove yourself?"
    };

    private string agreedDialogue = "What? You're still here?! Get moving. Now.";
    private string disagreedDialogue = "Have you changed your mind?";

    public override void OnInteract()
    {
        if (!hasInteracted)
        {
            dialogueManager.StartDialogue(initialDialogueParts);
        }
        else
        {
            if (hasPlayerAgreed)
            {
                dialogueManager.ShowSingleDialogue(agreedDialogue);
            }
            else
            {
                dialogueManager.StartDialogue(new List<string> { disagreedDialogue });
            }
        }
    }

    public void SetPlayerChoice(bool agreed)
    {
        hasPlayerAgreed = agreed;
        hasInteracted = true;
    }

    public void PlayerAgreed()
    {
        hasPlayerAgreed = true;
    }
}

