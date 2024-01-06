using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainMenu
{

    public class MainMenuManager : MonoBehaviour
    {

        [SerializeField]
        private Button _startButton;

        [Inject] private SceneLevelManager _sceneLevelManager;

        private void Awake()
        {
            _startButton.onClick.AddListener(StartPlay);
        }

        private void StartPlay()
        {
            _sceneLevelManager.StartCurrentPlayLevel();
        }
    }

}
