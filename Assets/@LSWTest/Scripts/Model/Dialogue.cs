using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Dialogue
    {
        public string name;
        [TextArea(3, 10)]
        public string[] sentences;
        public bool endDialogueInLastSentence;
        public UnityEvent okButtonEvent;
        public UnityEvent noButtonEvent;
    }
}
