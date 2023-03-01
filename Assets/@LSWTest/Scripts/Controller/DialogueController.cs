using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using System.Collections;
using Assets.Scripts.View;
using UnityEngine.UI;

namespace Assets.Scripts.Controller
{
    public class DialogueController : Shared.Controller<DialogueController>
    {
        [HideInInspector] public DialogueView dialogueView;
        [HideInInspector] public bool hasDialogueStarted;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI dialogueText;
        public Button okButton;
        public Button noButton;
        public Animator animator;
        public float secondsToTypeLetter;

        private Queue<string> sentences;
        private bool endDialogueInLastSentence;

        private void Start()
        {
            sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            animator.SetBool("isOpen", true);

            hasDialogueStarted = true;
            endDialogueInLastSentence = dialogue.endDialogueInLastSentence;

            if (!endDialogueInLastSentence)
            {
                okButton.onClick.AddListener(dialogue.okButtonEvent.Invoke);
                noButton.onClick.AddListener(dialogue.noButtonEvent.Invoke);
            }
            okButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);

            nameText.text = dialogue.name;

            sentences.Clear();

            foreach (var sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }

        public void StartDialogue(GameObject gameObject)
        {
            StartDialogue(gameObject.GetComponent<DialogueView>().Model);
        }

        public void EndDialogue()
        {
            if (okButton.gameObject.activeSelf)
            {
                okButton.onClick.RemoveAllListeners();
                okButton.gameObject.SetActive(false);
            }
            if (noButton.gameObject.activeSelf)
            {
                noButton.onClick.RemoveAllListeners();
                noButton.gameObject.SetActive(false);
            }

            animator.SetBool("isOpen", false);

            hasDialogueStarted = false;
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                if (endDialogueInLastSentence)
                {
                    EndDialogue();
                }
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = string.Empty;
            foreach (char letter in sentence)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(secondsToTypeLetter);
            }

            if (!endDialogueInLastSentence &&
                sentences.Count == 0)
            {
                okButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);
            }
        }
    }
}
