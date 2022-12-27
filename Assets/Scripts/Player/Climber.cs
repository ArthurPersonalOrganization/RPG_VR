using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

namespace Scripts.Player
{
    public class Climber : MonoBehaviour
    {
        private CharacterController character;
        public static ActionBasedController climbingHand;
        private ContinuousMoveProviderBase continuousMovement;

        void Start()
        {
            character = GetComponent<CharacterController>();
            continuousMovement = GetComponent<ContinuousMoveProviderBase>();
        }

        void FixedUpdate()
        {
            if (climbingHand)
            {
                continuousMovement.enabled = false;
                Climb();
            }
            else
            {
                continuousMovement.enabled = true;
            }
        }

        void Climb()
        {
            Debug.Log("climb!");
            //InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
            

            // bcharacter.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
        }
    }

}
