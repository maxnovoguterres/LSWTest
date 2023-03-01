using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Controller;

namespace Assets.Scripts.View
{
    public class CameraView : Shared.View
    {
        public Model.Camera Model;

        void LateUpdate ()
        {
            CameraController.Instance.FollowTarget(this);
        }
    }
}