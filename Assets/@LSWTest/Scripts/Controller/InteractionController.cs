using Assets.Scripts.Model;
using Assets.Scripts.View;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controller
{
    public class InteractionController : Shared.Controller<InteractionController>
    {
        [HideInInspector] public InteractionView minDistanceinteractionView;
        [HideInInspector] public List<InteractionView> interactionViews;
        [HideInInspector] public InteractionType interactionType;
        [HideInInspector] public bool canInteract;
        
        public void Interact()
        {
            if (interactionType == InteractionType.Dialogue)
            {
                DialogueController.Instance.StartDialogue(DialogueController.Instance.dialogueView.Model);
            }
        }

        public bool GetInteraction()
        {
            if (interactionViews.Count == 0 || 
                !canInteract ||
                DialogueController.Instance.hasDialogueStarted ||
                UIController.Instance.HasSectionOpen())
            {
                return false;
            }

            return true;
        }
    }
}