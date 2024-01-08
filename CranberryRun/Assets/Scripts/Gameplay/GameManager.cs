using System;
using Gameplay.Characters.Player;
using Gameplay.EndLevel;
using UnityEngine;
using Zenject;
using Task = System.Threading.Tasks.Task;

namespace Gameplay
{

    public class GameManager : MonoBehaviour
    {

        public bool IsGameStopped { get; private set; }
        private int _restartTimeMilis;

        private WwiseWinLose _winLoseAudio;
    
        [Inject] private PlayerCollision _playerCollision;
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private EndTrigger _endTrigger;
        [Inject] private EndLevelManager _endLevelManager;
        [Inject] private SceneLevelManager _sceneLevelManager;
        [Inject] private LoseLevelUI _loseLevelUI;

        [SerializeField]
        private float _restartTime;

        public Action OnGameEnded = delegate {  };

        public void Awake()
        {
            _winLoseAudio = GetComponent<WwiseWinLose>();
            _playerCollision.OnObstacleHit += TryLoseLevel;
            _endTrigger.OnEndTriggerPassed += TryWinLevel;
            _restartTimeMilis = (int)(_restartTime * 1000f);
        }

        public void OnDestroy()
        {
            _playerCollision.OnObstacleHit -= TryLoseLevel;
            _endTrigger.OnEndTriggerPassed -= TryWinLevel;
        }

        private void TryWinLevel()
        {
            if (!CanWin())
            {
                return;
            }

            IsGameStopped = true;
            _winLoseAudio.PlayWinSound();
            OnGameEnded.Invoke();
            _sceneLevelManager.SetCurrentSceneAsFinished();
            _playerMovement.StopMovement();
            _endLevelManager.OpenUI();
        }

        private void TryLoseLevel()
        {
            if (IsGameStopped) return;

            IsGameStopped = true;
            _winLoseAudio.PlayLoseSound();
            OnGameEnded.Invoke();
            _loseLevelUI.TurnOn();
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
            return !IsGameStopped;
        }

        public void PauseGame()
        {
            Debug.Log("Game was paused");
        }

        private void Update()
        {
            if (Input.GetKey("escape"))
            {
                _sceneLevelManager.ChangeToMainMenu();
            }
        }
    }

}