using UnityEngine;

namespace GameGuruDevChallange.Uis
{
    public class CanvasGroupContoller : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvasGroup;

        void Awake()
        {
            GetReference();
        }

        public void CloseCanvas()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }

        public void OpenCavnas()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }

        void GetReference()
        {
            if (_canvasGroup == null)
                _canvasGroup = GetComponent<CanvasGroup>();
        }

        void OnValidate()
        {
            GetReference();
        }
    }
}