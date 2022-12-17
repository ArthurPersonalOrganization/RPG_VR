using Scripts.Managers;
using UnityEngine;


namespace Scripts.UI
{
    public class BaseUI : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        public void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            EventManager.Instance.ShowUI();
        }

        public void Hide()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            EventManager.Instance.HideUI();
        }
    }
}

