using Assets.Scripts.Controller;
using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class InteractionView : Shared.View
    {
        public Interaction Model;

        private void Start()
        {
            InteractionController.Instance.interactionViews.Add(this);
        }

        private void OnTriggerEnter (Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Model.interactionCanvas.SetActive(true);
                InteractionController.Instance.canInteract = true;
            }
        }

        private void OnTriggerExit (Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Model.interactionCanvas.SetActive(false);
                InteractionController.Instance.canInteract = false;
            }
        }
    }
}
