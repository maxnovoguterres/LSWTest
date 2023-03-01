using Assets.Scripts.Controller;
using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class DialogueView : Shared.View
    {
        public Dialogue Model;

        private void OnTriggerEnter (Collider other)
        {
            if (other.CompareTag("Player"))
            {
                DialogueController.Instance.dialogueView = this;
            }
        }

        private void OnTriggerExit (Collider other)
        {
            if (other.CompareTag("Player"))
            {
                DialogueController.Instance.dialogueView = null;
            }
        }
    }
}
