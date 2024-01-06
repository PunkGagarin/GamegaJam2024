using Gameplay.EndLevel;
using Gameplay.Player;
using UnityEngine;
using Zenject;
using Task = System.Threading.Tasks.Task;

namespace Gameplay
{

    public class GameManager : MonoBehaviour
    {

        private bool _isGameStopped;
        private int _restartTimeMilis;

        [Inject] private PlayerCollision _playerCollision;
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private EndTrigger _endTrigger;
        [Inject] private EndLevelManager _endLevelManager;
        [Inject] private SceneLevelManager _sceneLevelManager;
        [Inject] private LoseLevelUI _loseLevelUI;

        [SerializeField]
        private float _restartTime;


        public void Awake()
        {
            _playerCollision.OnObstacleHit += OnObstacleHit;
            _endTrigger.OnEndTriggerPassed += TryWinLevel;
            _restartTimeMilis = (int)(_restartTime * 1000f);
        }

        public void OnDestroy()
        {
            _playerCollision.OnObstacleHit -= OnObstacleHit;
            _endTrigger.OnEndTriggerPassed -= TryWinLevel;
        }

        private void TryWinLevel()
        {
            if (!CanWin())
            {
                Debug.LogError("Trying win level while game is already over");
                return;
            }

            _isGameStopped = true;
            _playerMovement.StopMovement();
            _endLevelManager.OpenUI();
        }

        private void OnObstacleHit()
        {
            if (_isGameStopped) return;

            _loseLevelUI.TurnOn();
            _isGameStopped = true;
            RestartWithDelay(_restartTimeMilis);
        }

        private async void RestartWithDelay(int delayMilis)
        {
            await Task.Delay(delayMilis);
            Restart();
        }

        private void Restart()
        {
            _sceneLevelManager.RestartCurrentLevel();
        }

        public bool CanWin()
        {
            return !_isGameStopped;
        }

        public void PauseGame()
        {
            Debug.Log("Game was paused");
        }
    }

}