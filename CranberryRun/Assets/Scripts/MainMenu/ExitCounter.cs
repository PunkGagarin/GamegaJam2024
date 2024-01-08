using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{

    public class ExitCounter : MonoBehaviour
    {
        private int _exitPressCount = 0;
        private WwiseEventHandler _eventHandler;

        [SerializeField]
        private Button _exitButton;

        public void Awake()
        {
            _exitButton.onClick.AddListener(OnExitButtonHandler);
            _eventHandler = GetComponent<WwiseEventHandler>();
        }

        private void OnExitButtonHandler()
        {
            if (_exitPressCount >= 1)
            {
                Application.Quit();
            }
            else
            {
                _exitPressCount++;
                _eventHandler.PostEvent();
            }
        }

    }

}