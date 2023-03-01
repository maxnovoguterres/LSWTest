using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Movement
    {
        [HideInInspector] public Vector3 moveDirection;
        [HideInInspector] public bool isMoving;
        
        public float moveSpeed = 4f;
        public float rotationToCorrect;
        public Transform targetToRotate;
    }
}