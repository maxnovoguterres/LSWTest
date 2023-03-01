using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class MovementController : Shared.Controller<MovementController>
    {
        public void Move (MovementView View)
        {
            float horizontal = InputController.Instance.GetHorizontalMovement();
            float vertical = InputController.Instance.GetVerticalMovement();

            View.Model.moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

            if (View.Model.moveDirection != Vector3.zero)
            {
                View.transform.Translate(-View.Model.moveDirection * View.Model.moveSpeed * Time.deltaTime);
                Rotate(View);
                View.Model.isMoving = true;
            }
            else
            {
                View.Model.isMoving = false;
            }

            Animator animator = View.GetAnimator();
            animator.SetBool("isMoving", View.Model.isMoving);
        }

        public void Rotate (MovementView View)
        {
            View.Model.targetToRotate.rotation = Quaternion.LookRotation(View.Model.moveDirection);
            View.Model.targetToRotate.eulerAngles += Vector3.up * View.Model.rotationToCorrect;
        }
    }
}