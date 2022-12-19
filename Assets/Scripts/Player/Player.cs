using Scripts.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private GameObject leftHandRay;
        [SerializeField]
        private GameObject leftHandDirect;
        [SerializeField]
        private GameObject rightHandRay;
        [SerializeField]
        private GameObject righttHandDirect;
        [SerializeField]
        private ActionBasedContinuousMoveProvider actionMoveProvider;
        [SerializeField]
        private ActionBasedSnapTurnProvider actionTurnProvider;
        [SerializeField]
        private GameObject rightHand;
        [SerializeField]
        private GameObject leftHand;

        public Equipment Equipment { get; private set; }
        public Inventory Inventory { get; private set; }

        private void Awake()
        {
            Equipment = GetComponent<Equipment>();
            Inventory = GetComponent<Inventory>();
        }

        private void OnEnable()
        {
            EventManager.Instance.OnShowUI += EnableUIMode;
            EventManager.Instance.OnHideUI += DisableUIMode;
        }

        private void EnableUIMode()
        {
            actionMoveProvider.enabled = false;
            actionTurnProvider.enabled = false;
            leftHandDirect.SetActive(false);
            righttHandDirect.SetActive(false);
            leftHandRay.SetActive(true);
            rightHandRay.SetActive(true);
        }

        private void DisableUIMode()
        {
            actionMoveProvider.enabled = true;
            actionTurnProvider.enabled = true;
            leftHandDirect.SetActive(true);
            righttHandDirect.SetActive(true);
            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);
        }

    }
}
