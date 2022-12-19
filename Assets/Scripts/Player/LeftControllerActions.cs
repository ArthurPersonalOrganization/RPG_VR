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


        private void Awake()
        {
            
        }

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
           
            if (context.performed && !UIManager.Instance.InventoryUI.canvasOn)
            {
            //    Debug.Log(message: $"on primary {context.performed} Inventory on" );
                UIManager.Instance.InventoryUI.Show();
            }
            else if (context.performed && UIManager.Instance.InventoryUI.canvasOn)
            {
             //   Debug.Log(message: $"on primary {context.performed} Inventory off");
                UIManager.Instance.InventoryUI.Hide();
            }
        }

        public void OnSecondaryButton(InputAction.CallbackContext context)
        {
            if (context.performed && UIManager.Instance.EquipmentUI.canvasOn == false)
            {
               // Debug.Log(message: $"on sec {context.performed} equipment on");
                UIManager.Instance.EquipmentUI.Show();
            }
            
            else if (context.performed && UIManager.Instance.EquipmentUI.canvasOn == true)
            {
             //   Debug.Log(message: $"on sec {context.performed} equipment off");
                UIManager.Instance.EquipmentUI.Hide();
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
           
            if (context.performed)
            {
                var hits = Physics.OverlapSphere(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Items"));
          //      Debug.Log(message: $"on grip {context.performed} left hand");
                foreach (var hit in hits)
                {
                    var item = hit.GetComponent<Item>();
                    player.Inventory.Add(item);
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