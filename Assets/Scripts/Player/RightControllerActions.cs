using UnityEngine;
using UnityEngine.InputSystem;


namespace Scripts.Player
{
    public class RightControllerActions : MonoBehaviour, XRIDefaultInputActions.IXRIRightHandActions
    {
        [SerializeField]
        private Player player;
        private XRIDefaultInputActions controls;

        private void OnEnable()
        {
            if (controls == null)
            {
                controls = new XRIDefaultInputActions();
                controls.XRIRightHand.SetCallbacks(this);
            }
            controls.XRIRightHand.Enable();
        }

        public void OnHome(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Home clicked on Right Hand");
            }
        }

        public void OnJoystickButton(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Joystick clicked on Right Hand");
            }
        }

        public void OnPrimary(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("A clicked on Right Hand");
            }
        }

        public void OnSecondary(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("B clicked on Right Hand");
            }
        }

        public void OnGripButton(InputAction.CallbackContext context)
        {
            Debug.Log(message: $"on grip {context.performed} right hand");
            if (context.performed)
            {
                var hits = Physics.OverlapSphere(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Items"));
                foreach (var hit in hits)
                {
                    var item = hit.GetComponent<Item>();
                    player.inventory.Add(item);
                }
            }
        }

        public void OnTriggerButton(InputAction.CallbackContext context)
        {

        }

        public void OnTrackingState(InputAction.CallbackContext context)
        {
        }

        public void OnPosition(InputAction.CallbackContext context)
        {
        }

        public void OnHapticDevice(InputAction.CallbackContext context)
        {
        }

        public void OnRotation(InputAction.CallbackContext context)
        {
        }

      
    }
}
