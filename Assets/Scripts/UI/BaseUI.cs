using Scripts.Managers;
using UnityEngine;


namespace Scripts.UI
{
    public class BaseUI : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        public bool canvasOn = false;

        public void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
        //    Debug.Log("show this canvas group");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            canvasOn = true;
            EventManager.Instance.ShowUI();
           
        }

        public void Hide()
        {
        //    Debug.Log("hide this canvas group");
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvasOn = false;
            EventManager.Instance.HideUI();
            
        }
    }
}

