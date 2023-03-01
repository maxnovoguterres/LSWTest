using System;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Interaction
    {
        public InteractionType interactionType;
        public GameObject interactionCanvas;
    }
}
