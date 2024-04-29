using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button yesButton;
    public Button noButton;
    public Button nextButton;
    public Button closeButton;
    public GameObject npcImage;

    private int dialogueIndex; // To track dialogue
    private List<string> dialogues = new List<string>(); // To store dialogue

    void Awake()
    {
        dialoguePanel.SetActive(false);
        npcImage.SetActive(false);
        yesButton.onClick.AddListener(YesClicked);
        noButton.onClick.AddListener(NoClicked);
        nextButton.onClick.AddListener(NextClicked);
    }

    public void StartDialogue(List<string> parts)
    {
        dialogues = parts;
        dialogueIndex = 0;
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        npcImage.SetActive(true);
        ShowNextDialoguePart();
    }

    private void ShowNextDialoguePart()
    {
        if (dialogueIndex < dialogues.Count)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
            dialoguePanel.SetActive(true);

            if (dialogueIndex == dialogues.Count)
            {
                nextButton.gameObject.SetActive(false);
                closeButton.gameObject.SetActive(false);
                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);
            }
        }
        else
        {
            EndDialogue();
        }
    }

    public void ShowSingleDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
        dialoguePanel.SetActive(true);
        closeButton.gameObject.SetActive(true);
    }

    private void YesClicked()
    {
        if (dialogueIndex == dialogues.Count)
        {
            dialogueText.text = "Great! Now get moving! Time is of the essence!";
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            FindObjectOfType<NPCInteraction>().SetPlayerChoice(true);
            closeButton.gameObject.SetActive(true);
        }
        else
        {
            dialogueText.text = "What? You're still here?! Get moving. Now.";
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(true);
        }
    }

    private void NoClicked()
    {
        if (dialogueIndex == dialogues.Count)
        {
            dialogueText.text = "I don't have time for your indecisiveness. Return to me when you're ready.";
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            FindObjectOfType<NPCInteraction>().SetPlayerChoice(false);
            closeButton.gameObject.SetActive(true);
        }
        else
        {
            dialogueText.text = "I don't have time for your indecisiveness.";
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(true);
        }
    }

    public void NextClicked()
    {
        ShowNextDialoguePart();
    }

    public void EndDialogue()
    {
        npcImage.SetActive(false); 
        dialoguePanel.SetActive(false);
    }
}

