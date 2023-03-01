using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class InputController : Shared.Controller<InputController>
    {
        private float horizontalMovement;
        private float verticalMovement;

        void Update()
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");
            if (DialogueController.Instance.hasDialogueStarted)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    DialogueController.Instance.DisplayNextSentence();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.I))
                {
                    UIController.Instance.ShowInventorySection();
                }
            }
            if (InteractionController.Instance.GetInteraction())
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    InteractionController.Instance.Interact();
                }
            }
        }

        public float GetHorizontalMovement() => horizontalMovement;
        public float GetVerticalMovement() => verticalMovement;
    }
}