using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controller
{
    public class UIController : Shared.Controller<UIController>
    {
        public InstructionsSection instructionsSection;
        public InventorySection inventorySection;
        public ShopSection shopSection;

        [HideInInspector] public CanvasGroup lastSection;
        [HideInInspector] public List<CanvasGroup> currentSections;

        public bool HasSectionOpen()
        {
            return currentSections.Count > 0;
        }

        public void ShowInstructionsSection()
        {
            instructionsSection.ShowSection();
        }

        public void ShowInventorySection ()
        {
            inventorySection.ShowSection();
        }

        public void ShowShopSection ()
        {
            shopSection.ShowSection();
        }
    }
}