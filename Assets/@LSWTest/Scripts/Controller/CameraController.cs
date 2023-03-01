using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class CameraController : Shared.Controller<CameraController>
    {
        public void FollowTarget(CameraView View)
        {
            if (View.Model.followTarget.position + View.Model.distanceToTarget != View.transform.position)
            {
                View.Model.smoothPosition = Vector3.Lerp(View.transform.position, View.Model.followTarget.position + View.Model.distanceToTarget, View.Model.smoothSpeed);
                View.transform.position = View.Model.smoothPosition;
            }
        }
    }
}