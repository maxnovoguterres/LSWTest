using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;
using Assets.Scripts.Controller;

namespace Assets.Scripts.View
{
    public class MovementView : Shared.View
    {
        public Movement Model;

        #region getters
        public Animator GetAnimator() => GetAndStoreComponent<Animator>();
        #endregion

        private void Update ()
        {
            MovementController.Instance.Move(this);
        }
    }
}