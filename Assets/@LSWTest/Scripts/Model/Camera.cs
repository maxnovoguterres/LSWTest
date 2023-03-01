using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Camera
    {
        [HideInInspector] public Vector3 smoothPosition;

        public Transform followTarget;
        public Vector3 distanceToTarget;
        public float smoothSpeed = 0.5f;
    }
}