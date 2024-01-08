using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{

    public class ExitCounter : MonoBehaviour
    {
        private int _exitPressCount = 0;

        [SerializeField]
        private Button _exitButton;

        public void Awake()
        {
            _exitButton.onClick.AddListener(OnExitButtonHandler);
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
                //todo добавить проигрышь звука.
            }
        }

    }

}