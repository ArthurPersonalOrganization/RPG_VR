using Scripts.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Player
{
    public class LeftControllerActions : MonoBehaviour, XRIDefaultInputActions.IXRILeftHandActions
    {
        [SerializeField]
        private Player player;

        private XRIDefaultInputActions controls;

        private void OnEnable()
        {
            if (controls == null)
            {
                controls = new XRIDefaultInputActions();
                controls.XRILeftHand.SetCallbacks(this);
            }
            controls.XRILeftHand.Enable();
        }

        public void OnPrimaryButton(InputAction.CallbackContext context)
        {
            Debug.Log(message: $"on primary {context.performed}");
            if (context.performed)
            {
                UIManager.Instance.InventoryUI.Show();
            }
        }

        public void OnSecondaryButton(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Y hit on left");
                UIManager.Instance.EquipmentUI.Show();
            }
        }

        public void OnMenuButton(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Menu hit on left");
            }
        }

        public void OnJoystickButton(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Joystick hit on left");
            }
        }

        public void OnGripButton(InputAction.CallbackContext context)
        {
            Debug.Log(message: $"on grip {context.performed}");
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
            Debug.Log(message: $"on trigger {context.performed}");
        }

        public void OnPosition(InputAction.CallbackContext context)
        {
        }

        public void OnRotation(InputAction.CallbackContext context)
        {
        }

        public void OnTrackingState(InputAction.CallbackContext context)
        {
        }

        public void OnHapticDevice(InputAction.CallbackContext context)
        {
        }
    }
}